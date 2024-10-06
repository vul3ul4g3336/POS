using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 滿300折50 : DiscountType
    {
        public 滿300折50(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            int price = list.Sum(x => x.SubTotal);
            if (price < 300) return;
            int discount = price / 300;
            list.Add(new Item("(優惠)滿300折50", -50, discount));
        }
    }
}
