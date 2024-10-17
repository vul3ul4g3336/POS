using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class Items_FreeDifferentItems : AStrategy
    {
        public Items_FreeDifferentItems(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {
            int countOfMainProduct = type.Discount.N_for_M.N;
            int countOfSecondaryProduct = type.Discount.N_for_M.M;
            Item mainProduct = list.FirstOrDefault(x => x.Name == type.Discount.N_for_M.Item1 && x.Count >= countOfMainProduct);
            Item secondaryProduct = list.FirstOrDefault(x => x.Name == type.Discount.N_for_M.Item2);

            if (mainProduct != null)
            {
                int freeProduct = mainProduct.Count / countOfMainProduct; //送幾個
                if (secondaryProduct == null)
                {
                    list.Add(new Item($"(優惠)贈送{type.Discount.N_for_M.Item2}", 0, freeProduct));
                }
                else if (freeProduct >= secondaryProduct.Count)
                {
                    int diff = freeProduct - secondaryProduct.Count;
                    list.Add(new Item($"(優惠)贈送{type.Discount.N_for_M.Item2}", secondaryProduct.Price * -1, secondaryProduct.Count));
                    if (diff != 0)
                    {
                        list.Add(new Item($"(優惠)贈送{type.Discount.N_for_M.Item2}", 0, diff));
                    }
                }
                else
                {
                    int diff = secondaryProduct.Count - freeProduct;
                    list.Add(new Item($"(優惠)贈送{type.Discount.N_for_M.Item2}", secondaryProduct.Price * -1, freeProduct));
                    //list.Add(new Item($"(優惠)贈送{type.Discount.N_for_M.Item2}", 0, diff));
                }

            }
        }
    }
}
