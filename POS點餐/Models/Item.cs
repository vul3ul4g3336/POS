using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐
{
    internal class Item
    {
        public String Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int SubTotal
        {
            get
            {
                return Price * Count;
            }
        }

        public Item(String ItemName, int Price, int Qty)
        {
            this.Name = ItemName;
            this.Price = Price;
            this.Count = Qty;
        }
    }
}
