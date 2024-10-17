using POS點餐.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐
{
    internal class DiscountContext
    {
        private AStrategy type;

        public DiscountContext(AStrategy type)
        {
            this.type = type;
        }
        public void Discount()
        {
            type.DiscountOff();
        }
    }
}
