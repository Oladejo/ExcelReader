using ExcelReader.DbModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.TableInserts
{
    public class EcommerceTarrifRETURN
    {
        public static void Run()
        {
            List<DomesticZonePrice> domesticZonePriceExcel = new List<DomesticZonePrice>();

            PopulateDomesticZonePriceListFromExcel(domesticZonePriceExcel);
            SaveDomesticZonePriceExcelToDB(domesticZonePriceExcel);

            Console.WriteLine("end...EcommerceTarrifRETURN");
        }

        private static void PopulateDomesticZonePriceListFromExcel(List<DomesticZonePrice> domesticZonePriceExcel)
        {
            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\new\ecomerce_tarif.xlsx";
            SLDocument sl = new SLDocument(filePath, "return tarriff");
            for (int row = 2; row <= 56; row++)
            {
                for (int col = 4; col <= 7; col++)
                {
                    var zoneName = sl.GetCellValueAsString(1, col);
                    var priceStr = sl.GetCellValueAsString(row, col);
                    if(priceStr.Trim() == "")
                    {
                        priceStr = "0";
                    }
                    priceStr = priceStr.Replace(" ", "").Replace("o", "0").
                        Replace("O", "0").Replace(",", "").
                        Replace("s", ".5").Replace("q", "1");

                    //populate DomesticZonePrice
                    var domesticZonePrice = new DomesticZonePrice()
                    {
                        Price = decimal.Parse(priceStr),
                        Weight = decimal.Parse(sl.GetCellValueAsString(row, 2)),
                        Zone = new Zone() { ZoneName = zoneName },
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false,
                        RegularEcommerceType = 2
                    };
                    domesticZonePriceExcel.Add(domesticZonePrice);
                }
            }

            /////////////////Logger
            //Console.WriteLine("DomesticZonePrice...");
            //foreach (var dmzPrice in domesticZonePriceExcel)
            //{
            //    Console.WriteLine($"{dmzPrice.Weight} : {dmzPrice.Zone.ZoneName}" +
            //        $" : {dmzPrice.Price}");
            //}
            //Console.WriteLine($"DomesticZonePrice...Count: {domesticZonePriceExcel.Count}");
        }

        private static void SaveDomesticZonePriceExcelToDB(List<DomesticZonePrice> domesticZonePriceExcel)
        {
            ///////////////////////save to db
            using (var db = new TestingDBContext())
            {
                //2. get list from db
                var zonesDB = db.Zone.ToList();

                //3. add DomesticZonePrice to list
                List<DomesticZonePrice> dmzPriceForDB = new List<DomesticZonePrice>();
                foreach (var dm in domesticZonePriceExcel)
                {
                    var zoneFromDb = zonesDB.Single(x => x.ZoneName.Contains(dm.Zone.ZoneName.Trim()));

                    dmzPriceForDB.Add(new DomesticZonePrice()
                    {
                        Weight = dm.Weight,
                        Price = dm.Price,
                        ZoneId = zoneFromDb.ZoneId,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false,
                        RegularEcommerceType = dm.RegularEcommerceType
                    });
                }

                //4. add DomesticZonePrice to db
                db.DomesticZonePrice.AddRange(dmzPriceForDB);
                db.SaveChanges();
            }
        }

    }
}
