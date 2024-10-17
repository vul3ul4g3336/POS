using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Models
{
    internal class MenuModel
    {


        public MenuType[] Menu { get; set; }
        public StrategyType[] Strategies { get; set; }


        public class MenuType
        {
            public string TypeName { get; set; }
            public Food[] Foods { get; set; }
        }

        public class Food
        {
            public string Name { get; set; }
            public int price { get; set; }
        }

        public class StrategyType
        {
            public string Name { get; set; }
            public string Strategy { get; set; }
            public Discount Discount { get; set; }
        }

        public class Discount
        {
            public N_For_M N_for_M { get; set; }
            public N_For_Discountoff N_for_discountOff { get; set; }
            public Setofmeal SetOfMeal { get; set; }
            public Set Set { get; set; }
            public Discoutofset DiscoutOfSet { get; set; }
            public Shoppingfestival ShoppingFestival { get; set; }
        }

        public class N_For_M
        {
            public string Item1 { get; set; }
            public string Item2 { get; set; }
            public int N { get; set; }
            public int M { get; set; }
        }

        public class N_For_Discountoff
        {
            public string Item { get; set; }
            public int Amount { get; set; }
            public int discoutOff { get; set; }
            public int price { get; set; }
        }

        public class Setofmeal
        {
            public string[] Item { get; set; }
            public int Count { get; set; }
            public int price { get; set; }
        }

        public class Set
        {
            public string[] Item { get; set; }
            public int price { get; set; }
        }

        public class Discoutofset
        {
            public string[] Item { get; set; }
            public float discount { get; set; }
        }

        public class Shoppingfestival
        {
            public int price { get; set; }
            public float discoutOff { get; set; }
            public int discount { get; set; }
        }

    }
}
