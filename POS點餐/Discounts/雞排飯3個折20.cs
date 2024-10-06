using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 雞排飯3個折20 : DiscountType
    {
        public 雞排飯3個折20(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            Item food = list.FirstOrDefault(x => x.Name == "雞排飯" && x.Count >= 3);

            if (food != null)
            {
                int discountOfGGPai = food.Count / 3;
                list.Add(new Item("(優惠)雞排飯3個折20", -20, discountOfGGPai));
            }
        }
    }
}
