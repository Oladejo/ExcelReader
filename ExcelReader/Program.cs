using ExcelReader.TableInserts;
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
