using ExcelReader.DbModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.TableInserts
{
    public class HaulageMapppings
    {
        public static void Run()
        {
            SaveHaulageDistanceMappingToDB();
            SaveHaulageDistanceMappingPriceToDB();

            Console.WriteLine("end...HaulageMapppings");
        }

        #region HaulageDistanceMappingPrice
        private static void SaveHaulageDistanceMappingPriceToDB()
        {
            var listToSave = GetHaluageDistancePriceFromExcel();
            using (var context = new GIGLSDbContext())
            {
                context.HaulageDistanceMappingPrice.AddRange(listToSave);
                context.SaveChanges();
                //Console.WriteLine("Save completed successfully.");
            }
        }

        private static List<HaulageDistanceMappingPrice> GetHaluageDistancePriceFromExcel()
        {
            var list = new List<HaulageDistanceMappingPrice>();

            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\GIGL - Copy\Standard Haulage Tariff.xlsx";
            SLDocument sl = new SLDocument(filePath, "Rate");
            for (int row = 4; row <= 7; row++)
            {
                var start = 0;
                var end = 0;

                if (row == 4)
                {
                    start = 0;
                    end = 150;
                }
                if (row == 5)
                {
                    start = 151;
                    end = 500;
                }
                if (row == 6)
                {
                    start = 501;
                    end = 700;
                }
                if (row == 7)
                {
                    start = 701;
                    end = int.MaxValue;
                }


                for (int col = 3; col <= 7; col++)
                {
                    decimal tonne = 0;

                    if (col == 3)
                    {
                        tonne = 5;
                    }
                    if (col == 4)
                    {
                        tonne = 10;
                    }
                    if (col == 5)
                    {
                        tonne = 15;
                    }
                    if (col == 6)
                    {
                        tonne = 20;
                    }
                    if (col == 7)
                    {
                        tonne = 30;
                    }

                    Haulage haulage = GetHaulage(tonne);

                    var priceStr = sl.GetCellValueAsString(row, col);
                    decimal.TryParse(priceStr, out decimal price);
                    //Console.WriteLine($"Price: {price}");

                    list.Add(
                        new HaulageDistanceMappingPrice()
                        {
                            Price = price,
                            StartRange = start,
                            EndRange = end,
                            HaulageId = haulage.HaulageId,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now
                        }
                        );

                }
            }

            //1. from excel
            //Console.WriteLine("From Excel...");
            //foreach (var item in list)
            //{
            //    Console.WriteLine($"{item.StartRange} : {item.EndRange} : " +
            //        $"{item.HaulageId} : {item.Price}");
            //}

            return list;
        }

        private static Haulage GetHaulage(decimal tonne)
        {
            Haulage haulage = null;

            using (var context = new GIGLSDbContext())
            {
                haulage = context.Haulage.FirstOrDefault(s => s.Tonne.Equals(tonne));

                if (haulage == null)
                {
                    haulage = new Haulage
                    {
                        Tonne = tonne,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Status = true
                    };

                    // save to db
                    context.Haulage.Add(haulage);
                    context.SaveChanges();
                }
            }
            return haulage;
        }
        #endregion

        #region HaulageDistanceMapping
        private static void SaveHaulageDistanceMappingToDB()
        {
            var listToSave = GetStationExcelListThatMatch();
            using (var context = new GIGLSDbContext())
            {
                var entityList = new List<HaulageDistanceMapping>();
                foreach (var item in listToSave)
                {
                    var entity = new HaulageDistanceMapping
                    {
                        DepartureId = item.Station.StationId,
                        DestinationId = item.Station1.StationId,
                        Distance = item.Distance,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        Status = true
                    };

                    if (entity.DepartureId > 0 && entity.DestinationId > 0)
                    {
                        entityList.Add(entity);
                    }
                }

                context.HaulageDistanceMapping.AddRange(entityList);
                context.SaveChanges();
            }
        }

        private static List<HaulageDistanceMapping> GetStationExcelListThatMatch()
        {
            //1.
            var stationExcelList = GetHaulageDistanceMappingsFromExcel();
            var stationDBList = GetStationsFromDB();

            //2.
            var stationExcelListThatMatch = new List<HaulageDistanceMapping>();
            var stationExcelListThatDoNotMatch = new List<HaulageDistanceMapping>();
            var stationDBListThatMatch = new HashSet<string>();
            var stationDBListThatDoNotMatch = new HashSet<string>();

            //3.
            var found = false;
            foreach (var excelItem in stationExcelList)
            {
                found = false;
                foreach (var dbItem in stationDBList)
                {
                    // set the departure
                    if (excelItem.Station.StationName.Trim().Split(' ').First() == dbItem.StationName ||
                        excelItem.Station.StationName.Trim().Split(' ').First() == dbItem.StationCode)
                    {
                        excelItem.Station = dbItem;
                        found = true;
                    }

                    // set the departure
                    if (excelItem.Station1.StationName.Trim().Split(' ').First() == dbItem.StationName ||
                        excelItem.Station1.StationName.Trim().Split(' ').First() == dbItem.StationCode)
                    {
                        excelItem.Station1 = dbItem;
                    }
                }

                if (found)
                {
                    stationExcelListThatMatch.Add(excelItem);
                }
                else
                {
                    stationExcelListThatDoNotMatch.Add(excelItem);
                }
            }

            //4. 
            //Console.WriteLine("\n\nList That Match...");
            //foreach (var item in stationExcelListThatMatch)
            //{
            //    Console.WriteLine($"{item.Station.StationName} : {item.Station1.StationName} :" +
            //        $" {item.Distance} : {item.Station.StationId} : {item.Station1.StationId}");
            //}

            //Console.WriteLine("\n\nList That Do Not Match...");
            //foreach (var item in stationExcelListThatDoNotMatch)
            //{
            //    Console.WriteLine($"{item.Station.StationName} : {item.Station1.StationName} :" +
            //        $" {item.Distance}");
            //}

            //5.
            foreach (var item in stationExcelListThatMatch)
            {
                stationDBListThatMatch.Add(item.Station.StationName);
            }

            foreach (var item in stationExcelListThatDoNotMatch)
            {
                stationDBListThatDoNotMatch.Add(item.Station.StationName);
            }


            //save to DB stations not in the system
            foreach (var stationName in stationDBListThatDoNotMatch)
            {
                using (var db = new GIGLSDbContext())
                {
                    //populate Station
                    var station = new Station()
                    {
                        StateId = 1,
                        StationName = stationName,
                        StationCode = stationName,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    };

                    //1. add Statiob to db
                    db.Station.Add(station);
                    db.SaveChanges();
                }
            }

            //Console.WriteLine($"stationExcelList: {stationExcelList.Count}");
            //Console.WriteLine($"stationExcelListThatMatch: {stationExcelListThatMatch.Count}");
            //Console.WriteLine($"stationExcelListThatDoNotMatch: {stationExcelListThatDoNotMatch.Count}");

            //Console.WriteLine("\n\nStations That Match");
            //foreach (var item in stationDBListThatMatch)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //Console.WriteLine("\n\nStations That Do Not Match");
            //foreach (var item in stationDBListThatDoNotMatch)
            //{
            //    Console.WriteLine(item);
            //}

            return stationExcelList;    // stationExcelListThatMatch;
        }

        private static List<Station> GetStationsFromDB()
        {
            var stations = new List<Station>();
            using (var context = new GIGLSDbContext())
            {
                stations = context.Station.ToList();
            }

            //2. from DB
            //Console.WriteLine("\n\nFrom DB...");
            //foreach (var item in GetStationsFromDB())
            //{
            //    Console.WriteLine($"{item.StationName}");
            //}

            return stations;
        }

        private static List<HaulageDistanceMapping> GetHaulageDistanceMappingsFromExcel()
        {
            var list = new List<HaulageDistanceMapping>();

            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\GIGL - Copy\Standard Haulage Tariff.xlsx";
            SLDocument sl = new SLDocument(filePath, "Milleage Table");
            for (int row = 2; row <= 42; row++)
            {
                for (int col = 2; col <= 42; col++)
                {
                    int.TryParse(sl.GetCellValueAsString(row, col), out int distance);

                    list.Add(
                        new HaulageDistanceMapping()
                        {
                            Station = new Station
                            {
                                StationName = sl.GetCellValueAsString(row, 1)
                            },
                            Station1 = new Station
                            {
                                StationName = sl.GetCellValueAsString(1, col)
                            },
                            Distance = distance
                        }
                        );
                }
            }

            //1. from excel
            //Console.WriteLine("From Excel...");
            //foreach (var item in GetHaulageDistanceMappingsFromExcel())
            //{
            //    Console.WriteLine($"{item.Station.StationName} : {item.Station1.StationName} :" +
            //        $" {item.Distance}");
            //}

            return list;
        }
        #endregion HaulageDistanceMapping
    }
}
