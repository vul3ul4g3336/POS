using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 兩排骨送一綠豆湯 : DiscountType
    {
        public 兩排骨送一綠豆湯(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            Item rice = list.FirstOrDefault(x => x.Name == "排骨飯" && x.Count >= 2);
            Item soup = list.FirstOrDefault(x => x.Name == "綠豆湯");

            if (rice != null)
            {
                int freeSoup = rice.Count / 2;
                if (soup.Count == 0)
                {
                    list.Add(new Item("(優惠)贈送綠豆湯", 0, freeSoup));
                }
                if (freeSoup > soup.Count)
                {
                    int diff = freeSoup - soup.Count;
                    list.Add(new Item("(優惠)贈送綠豆湯", soup.Price * -1, soup.Count));
                    list.Add(new Item("(優惠)贈送綠豆湯", 0, diff));

                }
                else
                {
                    int diff = soup.Count - soup.Count;
                    list.Add(new Item("(優惠)贈送綠豆湯", soup.Price * -1, soup.Count));
                    list.Add(new Item("(優惠)贈送綠豆湯", 0, diff));
                }

            }

        }
    }
}
