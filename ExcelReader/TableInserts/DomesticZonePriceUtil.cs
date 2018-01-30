using ExcelReader.DbModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZTest
{
    public class DomesticZonePriceUtil
    {

        public static void Run()
        {
            List<DomesticZonePrice> domesticZonePriceExcel = new List<DomesticZonePrice>();

            PopulateDomesticZonePriceListFromExcel(domesticZonePriceExcel);
            SaveDomesticZonePriceExcelToDB(domesticZonePriceExcel);

            Console.WriteLine("end...DomesticZonePriceUtil");
        }

        private static void PopulateDomesticZonePriceListFromExcel(List<DomesticZonePrice> domesticZonePriceExcel)
        {
            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\GIGL - Copy\GIGL RATES AND ZONES.xlsx";
            SLDocument sl = new SLDocument(filePath, "RATES");
            for (int row = 8; row <= 27; row++)
            {
                for (int col = 4; col <= 7; col++)
                {
                    var zoneName = sl.GetCellValueAsString(7, col);

                    //populate DomesticZonePrice
                    var domesticZonePrice = new DomesticZonePrice()
                    {
                        Price = decimal.Parse(sl.GetCellValueAsString(row, col)),
                        Weight = decimal.Parse(sl.GetCellValueAsString(row, 2)),
                        Zone = new Zone() { ZoneName = zoneName },
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
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
            using (var db = new GIGLSDbContext())
            {
                //2. get list from db
                var zonesDB = db.Zone.ToList();

                //3. add DomesticZonePrice to list
                List<DomesticZonePrice> dmzPriceForDB = new List<DomesticZonePrice>();
                foreach (var dm in domesticZonePriceExcel)
                {
                    var zoneFromDb = zonesDB.Single(x => x.ZoneName.Contains(dm.Zone.ZoneName));

                    dmzPriceForDB.Add(new DomesticZonePrice()
                    {
                        Weight = dm.Weight,
                        Price = dm.Price,
                        ZoneId = zoneFromDb.ZoneId,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    });
                }

                //4. add DomesticZonePrice to db
                db.DomesticZonePrice.AddRange(dmzPriceForDB);
                db.SaveChanges();
            }
        }

    }
}
