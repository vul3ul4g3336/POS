using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 全場八折 : DiscountType
    {
        public 全場八折(List<Item> list) : base(list)
        {
        }

        public override void DiscountOff()
        {
            //int sum = 0;

            //for (int i = 0; i < list.Count; i++)
            //{
            //    sum += list[i].SubTotal;

            //}
            //int diff = 0;
            //Double CalcSum = (Double)sum; 
            //diff = (CalcSum- (sum / 10) * 8)  >= 0.5 ? (sum / 10) * 8 + 1 : (sum / 10) * 8;
            //diff = sum - diff;
            //list.Add(new Item("(折扣)八折優惠", diff * -1, 1));


            int diff = list.Sum(x => x.SubTotal) * 2 / 10 * -1;
            list.Add(new Item("(優惠)八折優惠", diff, 1));

        }
    }
}
