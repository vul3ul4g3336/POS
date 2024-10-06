using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace POS點餐
{
    internal class Order
    {
        static List<Item> list = new List<Item>();
        public static void Add(Item item, string type)
        {
            // 根據傳入的Item內容 判斷要做新增 修改數量 刪除 來維護你的List
            Item orderFood = list.FirstOrDefault(x => x.Name == item.Name);
            if (orderFood == null)
            {
                if (item.Count == 0)
                    return;
                list.Add(item);
            }
            else if (item.Count == 0)
            {
                list.Remove(orderFood);
            }
            else
            {
                orderFood.Count = item.Count;
            }
            OrderDiscount(type);

        }

        public static void OrderDiscount(string type)
        {
            DisCount.DiscountOrder(list,type);
        }


    }
}
