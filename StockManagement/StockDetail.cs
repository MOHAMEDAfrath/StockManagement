using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockManagement
{
    class StockDetail
    {
        public List<Stocks> stocks = new List<Stocks>();

    }
    class Stocks
    {
        public string name
        {
            get;
            set;
        }
        public int noofshares
        {
            get;
            set;
        }
        public int price
        {
            get;
            set;
        }
    }
}
