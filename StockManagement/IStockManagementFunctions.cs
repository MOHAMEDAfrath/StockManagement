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
        void CalculateTotalShare(List<Stocks> stocks);

    }
}
