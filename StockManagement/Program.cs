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
            Console.WriteLine("Enter 1 to Display Stocks");
            Console.WriteLine("Enter 2 to Calculate values for each stocks");
            Console.WriteLine("Enter 3 to Calculate total values of stocks");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    stockManagement.DisplayTheStocks(stockDetail.stocks);
                    break;
                case 2:
                    stockManagement.CalculateTotalForEachShare(stockDetail.stocks);
                    break;
                case 3:
                    stockManagement.CalculateTotalForEachShare(stockDetail.stocks);
                    stockManagement.CalculateTotalShare(stockDetail.stocks);
                    break;
            }

        }
    }
}
