using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 飲料三杯100 : DiscountType
    {
        public 飲料三杯100(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            List<Item> drinks = list.Where(x => x.Name == "紅茶" || x.Name == "綠茶" || x.Name == "鮮奶").ToList();
            int TotalOfDrinks = drinks.Sum(x => x.Count); // 7 
            if (TotalOfDrinks >= 3)
            {

                int DiscountOfDrinks = TotalOfDrinks / 3; // 1=4/3;
                int total = drinks
                                .OrderBy(x => x.Price) // 3 1 3
                                .SelectMany(x => Enumerable.Repeat(new Item(x.Name, x.Price, 1), x.Count))
                                .ToList()// a a a b c c c 
                                .Take(DiscountOfDrinks * 3) // take (2
                                .Sum(x => x.Price);


                list.Add(new Item("(優惠) 飲料三杯100", DiscountOfDrinks * 100 - total, 1));

            }
        }
    }
}
