using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class WithoutDiscount : DiscountType
    {
        public WithoutDiscount(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {

        }
    }
}
