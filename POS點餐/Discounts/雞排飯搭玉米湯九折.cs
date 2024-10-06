using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 雞排飯搭玉米湯九折 : DiscountType
    {
        public 雞排飯搭玉米湯九折(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            List<Item> food = list.Where(x => x.Name == "雞排飯" || x.Name == "玉米湯").ToList();
            if (food.Count == 2)
            {
                int qty = food.Min(x => x.Count);
                int diff = (food[0].Price + food[1].Price) / 10;
                list.Add(new Item("(優惠)雞排飯配玉米湯九折", diff * (-1), qty));
            }
        }
    }
}
