using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐
{
    internal abstract class DiscountType
    {

        public List<Item> list = null;
        public DiscountType(List<Item> list)
        {
            this.list = list;
        }

        public abstract void DiscountOff();

    }
}
