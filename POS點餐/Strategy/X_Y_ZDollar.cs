using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class X_Y_ZDollar : AStrategy
    {
        public X_Y_ZDollar(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {

            List<Item> foods = list.Where(x => type.Discount.Set.Item.Contains(x.Name)).ToList();
            if (foods.Count == type.Discount.Set.Item.Length)
            {
                int qty = foods.Min(x => x.Count);
                int originPrice = foods.Sum(x => x.Price) * qty;
                int diff = qty * type.Discount.Set.price - originPrice;
                string foodString = String.Join("搭", type.Discount.Set.Item);
                list.Add(new Item($"(優惠){foodString} {type.Discount.Set.price}元", diff, 1));
            }
        }
    }
}
