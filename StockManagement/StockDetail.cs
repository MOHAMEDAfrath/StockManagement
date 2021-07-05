using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockManagement
{
    class StockDetail
    {
        public LinkedList<Stocks> stocks = new LinkedList<Stocks>();

    }
   
    class Stocks
    {

        public string accountholdername
        {
            get;
            set;
        }

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
