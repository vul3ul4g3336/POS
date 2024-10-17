using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class N_Item_M_DollarsOff : AStrategy
    {
        public N_Item_M_DollarsOff(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {
            Item food = list.FirstOrDefault(x => x.Name == type.Discount.N_for_discountOff.Item && x.Count >= type.Discount.N_for_discountOff.Amount);
            if (food != null)
            {
                int diff = type.Discount.N_for_discountOff.price - food.Price * type.Discount.N_for_discountOff.Amount;
                int discountOfGGPai = food.Count / type.Discount.N_for_discountOff.Amount; // 幾個折扣

                list.Add(new Item($"(優惠){type.Name}", diff, discountOfGGPai));
            }
        }
    }
}
