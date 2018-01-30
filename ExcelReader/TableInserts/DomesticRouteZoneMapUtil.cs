using ExcelReader.DbModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ZTest
{
    public class DomesticRouteZoneMapUtil
    {

        public static void Run()
        {
            List<Station> stationsExcel = new List<Station>();
            List<DomesticRouteZoneMap> domesticRouteZoneMapsExcel = new List<DomesticRouteZoneMap>();

            PopulateDomesticRouteZoneMapListFromExcel(stationsExcel, domesticRouteZoneMapsExcel);
            SaveDomesticRouteZoneMapExcelToDB(stationsExcel, domesticRouteZoneMapsExcel);

            Console.WriteLine("end...DomesticRouteZoneMapUtil");
        }

        private static void PopulateDomesticRouteZoneMapListFromExcel(List<Station> stationsExcel, List<DomesticRouteZoneMap> domesticRouteZoneMapsExcel)
        {
            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\GIGL - Copy\GIGL RATES AND ZONES.xlsx";
            SLDocument sl = new SLDocument(filePath, "ZONES AND CODES");
            for (int row = 5; row <= 48; row++)
            {
                //populate Station
                var station_departure = new Station()
                {
                    StateId = 1,
                    StationCode = sl.GetCellValueAsString(row, 1),
                    StationName = sl.GetCellValueAsString(row, 2),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false
                };
                stationsExcel.Add(station_departure);

                for (int col = 3; col <= 46; col++)
                {
                    var station_destination = new Station()
                    {
                        StateId = 1,
                        StationName = sl.GetCellValueAsString(4, col),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    };

                    var zoneValue = sl.GetCellValueAsString(row, col);

                    //populate DomesticRouteZoneMap
                    var domesticRouteZoneMap = new DomesticRouteZoneMap()
                    {
                        Station = station_departure,
                        Station1 = station_destination,
                        Zone = new Zone() { ZoneName = zoneValue },
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false,
                        Status = true
                    };
                    domesticRouteZoneMapsExcel.Add(domesticRouteZoneMap);
                }
            }

            /////////////////Logger
            //Console.WriteLine("Stations...");
            //foreach (var st in stationsExcel)
            //{
            //    //Console.WriteLine($"{st.StationCode} : {st.StationName}");
            //}

            //Console.WriteLine("DomesticRouteZoneMaps...");
            //foreach (var drzms in domesticRouteZoneMapsExcel)
            //{
            //    Console.WriteLine($"{drzms.Station.StationName} : {drzms.Station1.StationName}" +
            //        $" : {drzms.Zone.ZoneName}");
            //}
            //Console.WriteLine($"DomesticRouteZoneMaps...Count: {domesticRouteZoneMapsExcel.Count}");
        }

        private static void SaveDomesticRouteZoneMapExcelToDB(List<Station> stationsExcel, List<DomesticRouteZoneMap> domesticRouteZoneMapsExcel)
        {
            ///////////////////////save to db
            using (var db = new GIGLSDbContext())
            {
                //1. add Stations to db
                List<Station> stationsToInsert = new List<Station>();
                var stationsInDB = db.Station.ToList();
                foreach(var item in stationsExcel)
                {
                    //var st = stationsInDB.Where(s => s.StationName.Contains(item.StationName) ||
                    //item.StationName.Contains(s.StationName)).Select(s => s);
                    var st = stationsInDB.FirstOrDefault(s => s.StationName == item.StationName);
                    if (st == null)
                    {
                        stationsToInsert.Add(item);
                    }
                }

                db.Station.AddRange(stationsToInsert);
                db.SaveChanges();

                //2. get list from db
                var zonesDB = db.Zone.ToList();
                var stationsDB = db.Station.ToList();

                //3. add DomesticRouteZoneMap to list
                List<DomesticRouteZoneMap> dzmForDB = new List<DomesticRouteZoneMap>();
                foreach (var dm in domesticRouteZoneMapsExcel)
                {
                    var zoneFromDb = zonesDB.Single(x => x.ZoneName.Contains(dm.Zone.ZoneName));
                    var stationDepartureFromDb = stationsDB.Single(x => x.StationName.Equals(dm.Station.StationName));
                    var stationDestinationFromDb = stationsDB.Single(x => x.StationName.Equals(dm.Station1.StationName));

                    dzmForDB.Add(new DomesticRouteZoneMap()
                    {
                        DepartureId = stationDepartureFromDb.StationId,
                        DestinationId = stationDestinationFromDb.StationId,
                        ZoneId = zoneFromDb.ZoneId,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false,
                        Status = true
                    });
                }

                //4. add DomesticRouteZoneMap to db
                db.DomesticRouteZoneMap.AddRange(dzmForDB);
                db.SaveChanges();
            }
        }

    }
}
