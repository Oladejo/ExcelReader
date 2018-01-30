using ExcelReader.DbModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZTest
{
    public class SpecialDomesticPackagePrice
    {
        public static void Run()
        {
            AddSpecialDomesticPackage();
            Console.WriteLine("end...SpecialDomesticPackagePrice");
        }

        #region SpecialDomesticPackage
        public static void AddSpecialDomesticPackage()
        {
            List<SpecialDomesticZonePrice> specialDomesticZonePriceExcel = new List<SpecialDomesticZonePrice>();

            PopulateSpecialDomesticPackageFromExcel(specialDomesticZonePriceExcel);

        }

        private static void PopulateSpecialDomesticPackageFromExcel(List<SpecialDomesticZonePrice> specialDomesticZonePriceExcel)
        {
            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\new\GIGLS - SPECIAL PRICE ADDITION.xlsx";
            SLDocument sl = new SLDocument(filePath, "GIGLS - SPECIAL PRICE ADDITION");

            //1 - SpecialDomesticPackage
            var stringList = new HashSet<string>();
            var specialDomesticPackageList = new List<SpecialDomesticPackage>();
            for (int row = 2; row <= 261; row++)
            {
                //populate SpecialDomesticPackage
                var packageName = sl.GetCellValueAsString(row, 2);
                var isAdded = stringList.Add(packageName);
                SpecialDomesticPackage package = null;
                if (isAdded)
                {
                    //populate Station
                    package = new SpecialDomesticPackage()
                    {
                        Name = packageName,
                        Status = true,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    };
                    specialDomesticPackageList.Add(package);
                }
                else
                {
                    foreach (var item in specialDomesticPackageList)
                    {
                        if (item.Name == packageName)
                        {
                            package = item;
                            break;
                        }
                    }
                }

                //zoneId
                int zoneId = 0;
                var zoneName = sl.GetCellValueAsString(row, 4);
                using (var db = new GIGLSDbContext())
                {
                    var zone = db.Zone.SingleOrDefault(s => s.ZoneName == zoneName);
                    zoneId = zone.ZoneId;
                }

                //price
                var priceString = sl.GetCellValueAsString(row, 5);
                decimal price = 0;
                decimal.TryParse(priceString, out price);
                if(price == 0)
                {
                    priceString = sl.GetCellValueAsString(row, 6);
                    decimal.TryParse(priceString, out price);
                }

                //2. populate SpecialDomesticZonePrice
                var specialDomesticZonePrice = new SpecialDomesticZonePrice()
                {
                    SpecialDomesticPackage = package,
                    ZoneId = zoneId,
                    Price = price,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false
                };
                specialDomesticZonePriceExcel.Add(specialDomesticZonePrice);
            }

            ///////////////////////save to db
            using (var db = new GIGLSDbContext())
            {
                //1. add SpecialDomesticPackage to db
                db.SpecialDomesticPackage.AddRange(specialDomesticPackageList);
                db.SpecialDomesticZonePrice.AddRange(specialDomesticZonePriceExcel);
                db.SaveChanges();
            }

            ///////////////////Logger
            //Console.WriteLine("SpecialDomesticPackages...");
            //foreach (var specialDomesticPackage in specialDomesticPackageExcel)
            //{
            //    Console.WriteLine($"{specialDomesticPackage.Name}");
            //}
            //Console.WriteLine($"specialDomesticPackageExcel...Count: {specialDomesticPackageExcel.Count}");
        }
        #endregion SpecialDomesticPackage
    }
}
