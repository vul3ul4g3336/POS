using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class StoreWideSalePercentOff : AStrategy
    {
        public StoreWideSalePercentOff(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {

            int originTotal = list.Sum(x => x.SubTotal);
            double diff = originTotal * type.Discount.ShoppingFestival.discoutOff;
            int priceDiff = originTotal - (int)diff;

            list.Add(new Item($"(優惠){type.Name}", priceDiff * (-1), 1));
        }
    }
}
