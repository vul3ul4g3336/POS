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
        public static void Add(Item item)
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
        }
        private static FlowLayoutPanel CreatePanel(string name, string price, string count, string subtotal)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            label1.Text = (name);
            label2.Text = (price);
            label3.Text = (count);
            label4.Text = (subtotal);
            flowLayoutPanel.Controls.Add(label1);
            flowLayoutPanel.Controls.Add(label2);
            flowLayoutPanel.Controls.Add(label3);
            flowLayoutPanel.Controls.Add(label4);
            flowLayoutPanel.Width = 500;
            flowLayoutPanel.Height = 50;
            return flowLayoutPanel;
        }
        public static List<FlowLayoutPanel> ShowPanel()
        {
            List<FlowLayoutPanel> panel = new List<FlowLayoutPanel>();

            FlowLayoutPanel titlePanel = CreatePanel("品名", "單價", "數量", "小計");
            panel.Add(titlePanel);
            for (int i = 0; i < list.Count; i++)
            {
                FlowLayoutPanel flowLayoutPanel =
                 CreatePanel($"{list[i].Name}", $"{list[i].Price}", $"{list[i].Count}", $"{list[i].SubTotal}");
                panel.Add(flowLayoutPanel);
            }

            return panel;
        }
    }
}
