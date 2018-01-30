using ExcelReader.DbModel;
using ExcelReader.TableInserts;
using GIGLS.Core.Enums;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZTest;

namespace ExcelReader
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyAndWallet.Run();
            StateServiceCentreAndAll.Run();
            SpecialDomesticPackagePrice.Run();
            DomesticRouteZoneMapUtil.Run();
            DomesticZonePriceUtil.Run();
            EcommerceTarrif.Run();
            EcommerceTarrifRETURN.Run();
            HaulageMapppings.Run();
            FleetListMappings.Run();
        }

    }
}
