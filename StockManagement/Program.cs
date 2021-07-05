using System;
using Newtonsoft.Json;
using System.IO;

namespace StockManagement
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Stock Management Program!");
            //JSON file path
            string filepath = @"C:\Users\afrat\source\repos\StockManagement\StockManagement\StockDetails.json";
            //Reading and converting JSON to Objects
            StockDetail stockDetail = JsonConvert.DeserializeObject<StockDetail>(File.ReadAllText(filepath));
            StockManagement stockManagement = new StockManagement();
            Console.WriteLine("Enter 1 to Display Stock Account");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    stockManagement.StockAccount(filepath);
                    while (true)
                    {
                        Console.WriteLine("Enter 1 Value for the stock account value");
                        Console.WriteLine("Enter 2 to buy a share");
                        Console.WriteLine("Enter 3 to sell a share");
                        Console.WriteLine("Enter 4 to print stock account report");
                        Console.WriteLine("Enter 5 to print Bought Stocks");
                        int ioption = Convert.ToInt32(Console.ReadLine());
                        switch (ioption)
                        {
                            case 1:
                                stockManagement.CalculateTotalForEachShare(stockDetail.stocks);
                                break;
                            case 2:
                                stockManagement.DisplayAvailableSharesToBuy();
                                Console.WriteLine("Enter amount: ");
                                int amount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter company name in which you want to buy share: ");
                                string companyname = Console.ReadLine();
                                stockManagement.Buy(amount,companyname);
                    
                                break;
                            case 3:
                                Console.WriteLine("Enter amount: ");
                                int sellamount = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter company name in which you want to sell  ");
                                string companysellname = Console.ReadLine();
                                stockManagement.Sell(sellamount, companysellname);
                                break;

                            case 4:
                                stockManagement.StockAccount(filepath);
                                break;
                            case 5:
                                stockManagement.BoughtShares();
                                break;
                            case 6:
                                return;
                        }
                    }
                    break;

            }
        

        }
    }
}
