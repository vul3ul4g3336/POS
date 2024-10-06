using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 雞腿飯買二送一 : DiscountType
    {
        public 雞腿飯買二送一(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            Item food = list.FirstOrDefault(x => x.Name == "雞腿飯" && x.Count >= 2);
            if (food != null)
            {
                list.Add(new Item("(優惠)雞腿飯買二送一", 0, food.Count / 2));
            }
        }
    }
}
