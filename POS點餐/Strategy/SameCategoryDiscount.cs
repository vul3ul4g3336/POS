using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Strategy
{
    internal class SameCategoryDiscount : AStrategy
    {
        public SameCategoryDiscount(List<Item> list, MenuModel.StrategyType type) : base(list, type)
        {
        }

        public override void DiscountOff()
        {
            List<Item> drinks = list.Where(x => type.Discount.SetOfMeal.Item.Contains(x.Name)).ToList();
            //List<Item> drinks = list.Where(x => x.Name == "紅茶" || x.Name == "綠茶" || x.Name == "鮮奶").ToList();
            int TotalOfDrinks = drinks.Sum(x => x.Count); // 7 
            if (TotalOfDrinks >= type.Discount.SetOfMeal.Count)
            {

                int DiscountOfDrinks = TotalOfDrinks / type.Discount.SetOfMeal.Count; // 1=4/3;
                int total = drinks
                                .OrderBy(x => x.Price) // 3 1 3
                                .SelectMany(x => Enumerable.Repeat(new Item(x.Name, x.Price, 1), x.Count))
                                .ToList()// a a a b c c c 
                                .Take(DiscountOfDrinks * type.Discount.SetOfMeal.Count) // take (2
                                .Sum(x => x.Price);


                list.Add(new Item($"(優惠) {type.Name}", DiscountOfDrinks * type.Discount.SetOfMeal.price - total, 1));

            }
        }
    }
}
