using ExcelReader.DbModel;
using GIGLS.Core.Enums;
using SpreadsheetLight;
using System;
using System.Collections.Generic;

namespace ExcelReader
{
    public class CompanyAndWallet
    {
        public static void Run()
        {
            var excelList = LoadExcel();
            LoadDB(excelList);
            Console.WriteLine("end...CompanyAndWallet");
        }

        private static void LoadDB(List<Company> excelList)
        {
            // company
            using (var context = new TestingDBContext())
            {
                context.Company.AddRange(excelList);
                context.SaveChanges();
            }

            // wallet
            var walletList = new List<Wallet>();
            var count = 1;
            foreach (var item in excelList)
            {
                var walletNumber = "5" + count.ToString("000000");
                count++;

                var wallet = new Wallet()
                {
                    WalletNumber = walletNumber,
                    Balance = 0,
                    CustomerId = item.CompanyId,
                    CustomerType = (int)CustomerType.Company,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                };
                walletList.Add(wallet);
            }

            using (var context = new TestingDBContext())
            {
                context.Wallet.AddRange(walletList);
                context.SaveChanges();
            }
            
            var test = "";
        }

        private static List<Company> LoadExcel()
        {
            SLDocument sl = new SLDocument(@"C:\D\etl\excel_file\customers details.xlsx", "Sheet1");

            List<Company> companyList = new List<Company>();
            List<IndividualCustomer> individualCustomerList = new List<IndividualCustomer>();
            int col = 2;
            for (int row = 2; row <= 426; row++)
            {
                //get only active customers
                if(sl.GetCellValueAsInt32(row, 15) == 1)
                {
                    continue;
                }

                var customerType = sl.GetCellValueAsString(row, 5);
                if (customerType == "ECO")
                {
                    // corporate customer
                    var company = new Company
                    {
                        CompanyType = (int)CompanyType.Ecommerce,
                        Name = sl.GetCellValueAsString(row, 2),
                        Discount = sl.GetCellValueAsDecimal(row, 3),
                        Address = sl.GetCellValueAsString(row, 6),
                        City = sl.GetCellValueAsString(row, 7),
                        PhoneNumber = sl.GetCellValueAsString(row, 8),
                        Email = sl.GetCellValueAsString(row, 9),
                        CompanyStatus = 1, 
                        CustomerCode = sl.GetCellValueAsString(row, 16),
                        DateCreated = sl.GetCellValueAsDateTime(row, 13),
                        DateModified = DateTime.Now,
                    };
                    company.CompanyContactPerson.Add(new CompanyContactPerson
                    {
                        FirstName = sl.GetCellValueAsString(row, 10),
                        PhoneNumber = sl.GetCellValueAsString(row, 11),
                        Email = sl.GetCellValueAsString(row, 12),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    });

                    companyList.Add(company);
                }
                else if (customerType == "ACC")
                {
                    //ecommerce
                    var company = new Company
                    {
                        CompanyType = (int)CompanyType.Corporate,
                        Name = sl.GetCellValueAsString(row, 2),
                        Discount = sl.GetCellValueAsDecimal(row, 3),
                        Address = sl.GetCellValueAsString(row, 6),
                        City = sl.GetCellValueAsString(row, 7),
                        PhoneNumber = sl.GetCellValueAsString(row, 8),
                        Email = sl.GetCellValueAsString(row, 9),
                        CompanyStatus = 1, 
                        CustomerCode = sl.GetCellValueAsString(row, 16),
                        DateCreated = sl.GetCellValueAsDateTime(row, 13),
                        DateModified = DateTime.Now
                    };
                    company.CompanyContactPerson.Add(new CompanyContactPerson
                    {
                        FirstName = sl.GetCellValueAsString(row, 10),
                        PhoneNumber = sl.GetCellValueAsString(row, 11),
                        Email = sl.GetCellValueAsString(row, 12),
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now
                    });

                    companyList.Add(company);
                }
                else
                {

                }
            }


            //clean the created date
            var phoneNumberCount = 1;
            foreach (var item in companyList)
            {
                if ((DateTime.Now.Year - item.DateCreated.Year) > 50)
                {
                    item.DateCreated = new DateTime(2000, 1, 1);
                }

                //phone number
                if(string.IsNullOrWhiteSpace(item.PhoneNumber))
                {
                    item.PhoneNumber = phoneNumberCount.ToString("00000");
                    phoneNumberCount++;
                }
            }

            return companyList;
        }
    }
}
