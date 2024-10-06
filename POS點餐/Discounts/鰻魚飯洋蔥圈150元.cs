using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 鰻魚飯洋蔥圈150元 : DiscountType
    {
        public 鰻魚飯洋蔥圈150元(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            //int mainFood = list.FirstOrDefault(x => x.Name == "鰻魚飯").Count;
            //int subFood = list.FirstOrDefault(x => x.Name == "洋蔥圈").Count;

            //if (mainFood >= 0 && subFood >= 0)
            //{
            //    int qty = Math.Min(mainFood, subFood);
            //    int mainFoodPrice = list.FirstOrDefault(x => x.Name == "鰻魚飯").Price;
            //    int subFoodPrice = list.FirstOrDefault(x => x.Name == "洋蔥圈").Price;

            //    int diffPrice = mainFoodPrice + subFoodPrice - 150;
            //    list.Add(new Item("(折扣)鰻魚飯套餐優惠", diffPrice * -1, qty));
            //}

            List<Item> foods = list.Where(x => x.Name == "鰻魚飯" || x.Name == "洋蔥圈").ToList();

            if (foods.Count == 2)
            {
                int qty = foods.Min(x => x.Count);
                int diff = foods.Sum(x => x.Price) - 150;
                list.Add(new Item("(折扣)鰻魚飯套餐優惠", diff * -1, qty));
            }


        }
    }
}
