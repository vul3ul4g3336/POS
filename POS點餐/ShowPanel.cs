using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐
{
    internal class ShowPanel
    {
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
        public static FlowLayoutPanel ShowThePanel(List<Item> list)
        {
            FlowLayoutPanel container = new FlowLayoutPanel();
            container.Width = 500;
            container.Height = 500;
            FlowLayoutPanel titlePanel = CreatePanel("品名", "單價", "數量", "小計");
            container.Controls.Add(titlePanel);
            for (int i = 0; i < list.Count; i++)
            {
                FlowLayoutPanel flowLayoutPanel =
                 CreatePanel($"{list[i].Name}", $"{list[i].Price}", $"{list[i].Count}", $"{list[i].SubTotal}");
                container.Controls.Add(flowLayoutPanel);
            }
            PanelEvent.NotifyMessage(new OrderDetails(container, list.Sum(x => x.SubTotal)));
            return container;
        }
    }
}
