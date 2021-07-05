using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace StockManagement
{
    //Implemented a interface
    class StockManagement : IStockManagementFunctions
    {
        List<List<string>> stockavailability = new List<List<string>>();
        StockDetail stockDetail;
        public StockManagement()
        {
            stockavailability.Add(new List<string> { "TCS", "10" });
            stockavailability.Add(new List<string> { "Infy", "12"});
            stockavailability.Add(new List<string> { "wipro", "9"});
        }
        public void DisplayAvailableSharesToBuy()
        {
            for (int i = 0; i < stockavailability.Count; i++)
            {
                Console.WriteLine("The available shares to buy:");
                Console.WriteLine("{0} : {1}", stockavailability[i][0], stockavailability[i][1]);
            }
        }
        /// <summary>
        /// Checks the specified company is available to buy.
        /// </summary>
       
        public int Check(string company, int amount)
        {
            int finalamount;
            for(int i = 0; i < stockavailability.Count; i++)
            {
                if (stockavailability[i][0] != company) 
                {
                    finalamount = 0;
                }
                else
                {
                    stockavailability[i][1] = Convert.ToString(Convert.ToInt32(stockavailability[i][1])-1);
                    finalamount = amount;
                }
            }
            return amount;
         }
        /// <summary>
        /// Stocks the account.
        /// </summary>
        
        public void StockAccount(string filepath)
        {
            
            stockDetail = JsonConvert.DeserializeObject<StockDetail>(File.ReadAllText(filepath));
            DisplayTheStocks(stockDetail.stocks);

        }
        /// <summary>
        /// Displays the stocks.
        /// </summary>
        
        public void DisplayTheStocks(LinkedList<Stocks> stocks)
        {
            foreach (var stock in stocks)
            {

                Console.WriteLine("The Account Holder name : {0}", stock.accountholdername);
                Console.WriteLine("The Stocks are :");
                Console.WriteLine("Stock name: {0}", stock.name);
                Console.WriteLine("Shares: {0}", stock.noofshares);
                Console.WriteLine("Stock price: {0}", stock.price);
                Console.WriteLine(" ");

            }

        }
        /// <summary>
        /// Buys the specified share.
        /// </summary>
       
        public void Buy(int amount, string company)
        {
            int value = Check(company, amount);
            AddStockAccount(stockDetail.stocks, company, amount);
            
        }
        /// <summary>
        /// Sells the specified share.
        /// </summary>
        
        public void Sell(int amount,string company)
        {
            Stocks stocks1 = new Stocks();
            int value = 0;
            foreach (var member in stockDetail.stocks)
            {
                if (member.name == company)
                {
                    Console.WriteLine("Updated"+member.name);
                    value = member.noofshares;
                    stockDetail.stocks.Remove(member);
                    stocks1.accountholdername = "Ram";
                    stocks1.name = company;
                    stocks1.noofshares = value -1;
                    stocks1.price = amount;
                    break;
                }
                
            }
            stockDetail.stocks.AddLast(stocks1);
            File.WriteAllText(@"C:\Users\afrat\source\repos\StockManagement\StockManagement\StockDetails.json", JsonConvert.SerializeObject(stockDetail));


        }

        /// <summary>
        /// Adds the stock account.
        /// </summary>
        public void AddStockAccount(LinkedList<Stocks> stocks,string company,int amount)
        {
            Stocks stocks1 = new Stocks();
            int value = 0;
            foreach (var member in stocks)
            {
                if (member.name == company)
                {
                    Console.WriteLine("Updated");
                    value = member.noofshares;
                    stocks.Remove(member);
                    stocks1.accountholdername = "Ram";
                    stocks1.name = company;
                    stocks1.noofshares = value + 1;
                    stocks1.price = amount;
                    break;
                }
                else
                {
                    stocks1.accountholdername = "Ram";
                    stocks1.name = company;
                    stocks1.noofshares = 1;
                    stocks1.price = amount;

                }
            }
                stocks.AddLast(stocks1);
                File.WriteAllText(@"C:\Users\afrat\source\repos\StockManagement\StockManagement\StockDetails.json", JsonConvert.SerializeObject(stockDetail));

            





        }
        public void CalculateTotalForEachShare(LinkedList<Stocks> stocks)
        {
            int valueofthisstock = 0;
            foreach (var stock in stocks)
            {
                if (stock.name != null && stock.price != 0)
                {
                    valueofthisstock = stock.noofshares * stock.price;
                    Console.WriteLine("The Stock Price for {0} is {1}", stock.name, valueofthisstock);
                }

            }
        
        }
        public double ValueofShareAccount(LinkedList<Stocks> stocks)
        {
            double totalstock = 0;
            foreach (var stock in stocks)
            {

                totalstock += (double)stock.noofshares * stock.price;
            }
                return totalstock;
        }


    }
}
