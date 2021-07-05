using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement
{
    //Interface with Stockmanagement functions.
    interface IStockManagementFunctions
    {
        void DisplayTheStocks(List<Stocks> stocks);
        void CalculateTotalForEachShare(List<Stocks> stocks);
        double ValueofShareAccount(List<Stocks> stocks);

        void StockAccount(string filepath);
        void Buy(int amount, string company);
        void Sell(int amount, string company);

    }
}
