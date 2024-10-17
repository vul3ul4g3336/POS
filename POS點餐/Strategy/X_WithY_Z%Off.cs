using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class X_WithY_Z_Off : AStrategy
    {
        public X_WithY_Z_Off(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {
            List<Item> food = list.Where(x => type.Discount.DiscoutOfSet.Item.Contains(x.Name)).ToList();
            if (food.Count == type.Discount.DiscoutOfSet.Item.Length)
            {
                int qty = food.Min(x => x.Count);
                float diff = (food[0].Price + food[1].Price) * (1 - type.Discount.DiscoutOfSet.discount);
                int priceDiff = (int)diff;

                string foodsName = String.Join("搭", type.Discount.DiscoutOfSet.Item);
                list.Add(new Item($"(優惠){foodsName}打{type.Discount.DiscoutOfSet.discount * 100}%off", priceDiff * (-1), qty));
            }
        }
    }
}
