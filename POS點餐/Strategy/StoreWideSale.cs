using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class StoreWideSale : AStrategy
    {
        public StoreWideSale(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {
            int price = list.Sum(x => x.SubTotal);
            if (price < type.Discount.ShoppingFestival.price) return;
            int discount = price / type.Discount.ShoppingFestival.price;
            list.Add(new Item("(優惠)滿300折50", type.Discount.ShoppingFestival.discount * (-1), discount));
        }
    }
}
