using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    //Implemented a interface
    class StockManagement : IStockManagementFunctions
    {
        public void DisplayTheStocks(List<Stocks> stocks)
        {
            foreach(var stock in stocks)
            {
                Console.WriteLine("The Stocks are :");
                Console.WriteLine("Stock name: {0}", stock.name);
                Console.WriteLine("Shares: {0}", stock.noofshares);
                Console.WriteLine("Stock price: {0}", stock.price);
                Console.WriteLine(" ");
            }

        }
       public void CalculateTotalForEachShare(List<Stocks> stocks)
        {
            int valueofthisstock = 0;
            foreach (var stock in stocks)
            {
                
                valueofthisstock = stock.noofshares * stock.price;
                Console.WriteLine("The Stock Price for {0} is {1}",stock.name,valueofthisstock);

            }
        
        }
        public void CalculateTotalShare(List<Stocks> stocks)
        {
            int totalstock = 0;
            foreach (var stock in stocks)
            {

                totalstock += stock.noofshares * stock.price;
            }
                Console.WriteLine("The total share price {0}",totalstock);

            


        }


    }
}
