using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class BuyNGetMStrategy : AStrategy
    {
        public BuyNGetMStrategy(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {
            Item food = list.FirstOrDefault(x => x.Name == type.Discount.N_for_M.Item1 && x.Count >= type.Discount.N_for_M.N);
            if (food != null)
            {
                int countOfMainProduct = type.Discount.N_for_M.N;
                int countOfSecondaryProduct = type.Discount.N_for_M.M;
                list.Add(new Item($"(優惠){type.Name}", 0, (food.Count / countOfMainProduct) * countOfSecondaryProduct));
            }
        }
    }
}
