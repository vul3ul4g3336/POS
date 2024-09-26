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
        // 鰻魚飯搭配鮮菇濃湯 150
        // 買兩個排骨飯送一碗綠豆湯
        // 雞排飯搭玉米濃湯打九折
        // 排骨飯加洋蔥圈加紅茶 150元
        // 飲料三杯100元
        // 鰻魚飯搭配洋蔥圈150元
        // 全場消費滿300折50
        // 全場消費打八折

        public static void DiscountOrder(List<Item> items, string discountType)
        {


            //switch (discountType)
            //{
            //    if()
            //}


            ShowPanel.ShowThePanel(items);
        }


    }
}
