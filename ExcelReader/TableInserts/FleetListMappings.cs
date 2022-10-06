using ExcelReader.DbModel;
using GIGLS.Core.Enums;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelReader.TableInserts
{
    public class FleetListMappings
    {
        public static void Run()
        {
            List<Fleet> fleetExcel = new List<Fleet>();
            PopulateFleetListFromExcel(fleetExcel);

            Console.WriteLine("end...FleetListMappings");
        }

        private static void PopulateFleetListFromExcel(List<Fleet> fleetExcel)
        {
            var fleetMakeSet = new HashSet<string>();
            var fleetModelSet = new HashSet<string>();
            var fleetPartnerSet = new HashSet<string>();

            ////////////////////// access excel file
            var filePath = @"C:\D\Work\docs\new\FLEET LIST.xlsx";
            SLDocument sl = new SLDocument(filePath, "Sheet1");
            for (int row = 3; row <= 52; row++)
            {
                var isAdded = false;

                //////////////1.1 fleetMake
                var fleetMake = new FleetMake();
                var fleetMakeName = sl.GetCellValueAsString(row, 3);
                isAdded = fleetMakeSet.Add(fleetMakeName);
                if (isAdded)
                {
                    using (var db = new TestingDBContext())
                    {
                        fleetMake = new FleetMake
                        {
                            MakeName = fleetMakeName,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            IsDeleted = false,
                        };
                        db.FleetMake.Add(fleetMake);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (var db = new TestingDBContext())
                    {
                        fleetMake = db.FleetMake.Single(s => s.MakeName == fleetMakeName);
                    }
                }


                ///////////1.2 fleetModel
                var fleetModel = new FleetModel();
                var fleetModelName = sl.GetCellValueAsString(row, 5);
                isAdded = fleetModelSet.Add(fleetModelName);
                if (isAdded)
                {
                    using (var db = new TestingDBContext())
                    {
                        fleetModel = new FleetModel
                        {
                            ModelName = fleetModelName,
                            MakeId = fleetMake.MakeId,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            IsDeleted = false,
                        };
                        db.FleetModel.Add(fleetModel);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (var db = new TestingDBContext())
                    {
                        fleetModel = db.FleetModel.Single(s => s.ModelName == fleetModelName);
                    }
                }


                ///////////1.3 fleetPartner
                var partner = new Partner();
                var fleetPartnerName = sl.GetCellValueAsString(row, 4);
                isAdded = fleetPartnerSet.Add(fleetPartnerName);
                if (isAdded)
                {
                    using (var db = new TestingDBContext())
                    {
                        partner = new Partner
                        {
                            PartnerName = fleetPartnerName,
                            DateCreated = DateTime.Now,
                            DateModified = DateTime.Now,
                            IsDeleted = false,
                        };
                        db.Partner.Add(partner);
                        db.SaveChanges();
                    }
                }
                else
                {
                    using (var db = new TestingDBContext())
                    {
                        partner = db.Partner.Single(s => s.PartnerName == fleetPartnerName);
                    }
                }


                //2 fleetType
                var fleetType = FleetType.Vehicle;
                if (fleetModelName.Trim() == "TRUCK")
                {
                    fleetType = FleetType.Truck;
                }
                else if (fleetModelName.Trim() == "VAN")
                {
                    fleetType = FleetType.Van;
                }
                else if (fleetModelName.Trim() == "SALON CAR")
                {
                    fleetType = FleetType.SalonCar;
                }
                else if (fleetModelName.Trim() == "MINI TRUCK")
                {
                    fleetType = FleetType.MiniTruck;
                }

                //Capacity
                var capacityStr = sl.GetCellValueAsString(row, 6);
                int capapcity = 0;
                int.TryParse(capacityStr.Replace("TONS", ""), out capapcity);


                //3. populate Fleet
                var fleet = new Fleet()
                {
                    RegistrationNumber = sl.GetCellValueAsString(row, 2),
                    Capacity = capapcity,   //int.Parse(sl.GetCellValueAsString(row, 6)),

                    FleetType = (int)fleetType,
                    FleetMake_MakeId = fleetMake.MakeId,
                    ModelId = fleetModel.ModelId,
                    PartnerId = partner.PartnerId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    IsDeleted = false,
                    Status = true
                };
                fleetExcel.Add(fleet);
            }


            ///////////// save to DB
            using (var db = new TestingDBContext())
            {
                db.Fleet.AddRange(fleetExcel);
                db.SaveChanges();
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

        
    }
}
