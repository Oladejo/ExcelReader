using ExcelReader.DbModel;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZTest
{
    public class StateServiceCentreAndAll
    {
        public static void Run()
        {
            AddZone();
            AddStates();
            AddServiceCenter();
            Console.WriteLine("end...StateServiceCentreAndAll");
        }

        #region Zone
        private static void AddZone()
        {
            ///////////////////////save to db
            using (var db = new TestingDBContext())
            {
                var zones = new List<Zone>();

                for (int i = 1; i <= 4; i++)
                {
                    zones.Add(new Zone()
                    {
                        ZoneName = "Zone " + i,
                        Status = true,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    });
                }

                //4. add Zone to db
                db.Zone.AddRange(zones);
                db.SaveChanges();
            }
        }
        #endregion Zone

        #region state
        public static void AddStates()
        {
            List<State> stateExcel = new List<State>();

            PopulateStateFromExcel(stateExcel);
            SaveStateExcelToDB(stateExcel);

        }

        private static void PopulateStateFromExcel(List<State> stateExcel)
        {
            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\GIGL - Copy\STS Descriptions For Efe .xlsx";
            SLDocument sl = new SLDocument(filePath, "State and Code");
            for (int row = 2; row <= 38; row++)
            {
                var stateName = sl.GetCellValueAsString(row, 10);

                //populate state
                var state = new State()
                {
                    StateCode = stateName.Substring(0, 3),
                    StateName = stateName,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false
                };
                stateExcel.Add(state);
            }

            /////////////////Logger
            //Console.WriteLine("States...");
            //foreach (var state in stateExcel)
            //{
            //    Console.WriteLine($"{state.StateCode} : {state.StateName}");
            //}
            //Console.WriteLine($"stateExcel...Count: {stateExcel.Count}");
        }

        private static void SaveStateExcelToDB(List<State> stateExcel)
        {
            ///////////////////////save to db
            using (var db = new TestingDBContext())
            {
                ////2. get list from db
                //var stateDB = db.State.ToList();

                //var statesNotInDB = stateExcel.Where(a =>
                //    !stateDB.Any(b => a.StateName == b.StateName));


                //4. add State to db
                db.State.AddRange(stateExcel);
                db.SaveChanges();
            }
        }
        #endregion state

        #region ServiceCenter
        public static void AddServiceCenter()
        {
            List<ServiceCentre> serviceCentreExcel = new List<ServiceCentre>();

            PopulateServiceCentreFromExcel(serviceCentreExcel);

        }

        private static void PopulateServiceCentreFromExcel(List<ServiceCentre> serviceCentreExcel)
        {
            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\new\GIGLS SERVICE CENTERS.xlsx";
            SLDocument sl = new SLDocument(filePath, "GIGLS - Welcome To GIG Logistic");

            //1 - Station
            var stationStringList = new HashSet<string>();
            var stationList = new List<Station>();
            for (int row = 2; row <= 71; row++)
            {
                //populate Station
                var StationName = sl.GetCellValueAsString(row, 4);
                var isAdded = stationStringList.Add(StationName);
                Station station = null;
                if (isAdded)
                {
                    //populate Station
                    station = new Station()
                    {
                        StateId = 1,
                        StationName = StationName,
                        StationCode = StationName,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        IsDeleted = false
                    };
                    stationList.Add(station);
                }
                else
                {
                    foreach (var item in stationList)
                    {
                        if (item.StationName == StationName)
                        {
                            station = item;
                            break;
                        }
                    }
                }

                //2. populate ServiceCentre
                var serviceCentre = new ServiceCentre()
                {
                    Station = station,
                    Code = sl.GetCellValueAsString(row, 3),
                    Name = sl.GetCellValueAsString(row, 2),
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    IsActive = true
                };
                serviceCentreExcel.Add(serviceCentre);
            }

            ///////////////////////save to db
            using (var db = new TestingDBContext())
            {
                //1. add Statiob to db
                db.Station.AddRange(stationList);
                db.ServiceCentre.AddRange(serviceCentreExcel);
                db.SaveChanges();
            }

            //update Station Code
            filePath = @"C:\D\Work\docs\GIGL - Copy\GIGL RATES AND ZONES.xlsx";
            sl = new SLDocument(filePath, "ZONES AND CODES");

            using (var db = new TestingDBContext())
            {
                for (int row = 5; row <= 48; row++)
                {
                    var stationCode = sl.GetCellValueAsString(row, 1);
                    var stationName = sl.GetCellValueAsString(row, 2);

                    var station = db.Station.SingleOrDefault(s => s.StationName == stationName);
                    if (station != null)
                    {
                        station.StationCode = stationCode;
                    }
                }

                //1. update Station in db
                db.SaveChanges();
            }





            /////////////////Logger
            //Console.WriteLine("ServiceCentres...");
            //foreach (var serviceCentre in serviceCentreExcel)
            //{
            //    Console.WriteLine($"{serviceCentre.Code} : {serviceCentre.Name}");
            //}
            //Console.WriteLine($"serviceCentreExcel...Count: {serviceCentreExcel.Count}");
        }
        #endregion ServiceCenter
    }
}
