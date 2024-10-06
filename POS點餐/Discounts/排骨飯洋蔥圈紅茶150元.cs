using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 排骨飯洋蔥圈紅茶150元 : DiscountType
    {
        public 排骨飯洋蔥圈紅茶150元(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            List<Item> foods = list.Where(x => x.Name == "排骨飯" || x.Name == "洋蔥圈" || x.Name == "紅茶").ToList();
            if (foods.Count == 3)
            {
                int qty = foods.Min(x => x.Count);
                int diff = 150 - foods.Sum(x => x.Price);
                list.Add(new Item("(優惠)排骨飯套餐 (洋蔥圈 + 紅茶)", diff, 1));
            }
        }
    }
}
