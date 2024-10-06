using POS點餐.Discounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐
{
    internal class DisCount
    {
        // 不打折

        //雞腿飯買二送一
        //雞排飯買三個250(折20)
        // 買兩個排骨飯送一碗綠豆湯
        // 雞排飯搭玉米濃湯打九折
        // 排骨飯加洋蔥圈加紅茶 150元
        // 飲料三杯100元
        // 鰻魚飯搭配洋蔥圈150元
        // 全場消費滿300折50
        // 全場消費打八折

        public static void DiscountOrder(List<Item> items, string discountType)
        {
            items = items.Where(x => !x.Name.Contains("(優惠)")).ToList();
            Type t = Type.GetType("POS點餐.Discounts." + discountType);
            object obj = Activator.CreateInstance(t, new object[] { items });
            DiscountType type = (DiscountType)obj;


            type.DiscountOff();

            ShowPanel.ShowThePanel(items);
        }
        //DiscountType type = null;
        //switch (discountType)
        //{
        //    case "鰻魚飯搭配洋蔥圈150元":
        //        type = new 鰻魚飯洋蔥圈150元(items);
        //        break;
        //    case "雞腿飯買二送一":
        //        type = new 雞腿飯買二送一(items);
        //        break;
        //    case "雞排飯買三個250(折20)":
        //        type = new 雞排飯3個折20(items);
        //        break;
        //    case "買兩個排骨飯送一碗綠豆湯":
        //        type = new 兩排骨送一綠豆湯(items);
        //        break;
        //    case "雞排飯搭玉米濃湯打九折":
        //        type = new 雞排飯搭玉米湯九折(items);
        //        break;
        //    case "排骨飯加洋蔥圈加紅茶 150元":
        //        type = new 排骨飯洋蔥圈紅茶150元(items);
        //        break;
        //    case "飲料三杯100元":
        //        type = new 飲料三杯100(items);
        //        break;
        //    case "全場消費滿300折50":
        //        type = new 滿300折50(items);
        //        break;
        //    case "全場消費打八折":
        //        type = new 全場八折(items);
        //        break;
        //    case "不打折":
        //        type = new WithoutDiscount(items);
        //        break;
        //}

    }
}
