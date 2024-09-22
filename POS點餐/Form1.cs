using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace POS點餐
{
    public partial class Form1 : Form
    {

        string[] foodChoices = { "雞排飯$90", "雞腿飯$100", "魚排飯$80", "鰻魚飯$110", "排骨飯$85" };
        string[] snackChoices = { "洋蔥圈$50", "雞塊$60", "薯條$40", "薯餅$50" };
        string[] soupChoices = { "玉米濃湯$40", "鮮菇濃湯$50", "綠豆湯$30" };
        string[] drinkChoices = { "紅茶$40", "綠茶$40", "鮮奶$50" };
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sum = 0;
            sum += flowLayoutPanel1.OrderConfirm();
            sum += flowLayoutPanel2.OrderConfirm();
            sum += flowLayoutPanel3.OrderConfirm();
            sum += flowLayoutPanel4.OrderConfirm();
            label1.Text = sum.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string input = "HelloWorld12345";
            Console.WriteLine(input.CalcNumberCountFromString());


            flowLayoutPanel1.CheckBoxDisplay(foodChoices, CheckBoxCheckedChange, ValueChange);
            flowLayoutPanel2.CheckBoxDisplay(snackChoices, CheckBoxCheckedChange, ValueChange);
            flowLayoutPanel3.CheckBoxDisplay(soupChoices, CheckBoxCheckedChange, ValueChange);
            flowLayoutPanel4.CheckBoxDisplay(drinkChoices, CheckBoxCheckedChange, ValueChange);
        }

        private void RenderDetail(List<FlowLayoutPanel> panels)
        {
            flowLayoutPanel5.Controls.Clear();
            foreach (FlowLayoutPanel panel in panels)
            {
                flowLayoutPanel5.Controls.Add(panel);
            }
        }

        private Item CreateItem(string input, int count)
        {
            string text = input.Split('$')[0].ToString(); //產品名
            string text2 = input.Split('$')[1].ToString(); //產品價錢
            int price = int.Parse(text2);
            int number = count;   //數量
            int total = int.Parse(text2) * number; //總金額

            Item item = new Item(text, price, number);
            return item;
        }

        public void CheckBoxCheckedChange(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown numeric = (NumericUpDown)checkBox.Parent.Controls[1];
            if (checkBox.Checked)
            {
                numeric.Value = numeric.Value == 0 ? 1 : numeric.Value;
            }
            else
            {
                numeric.Value = 0;
            }

            Item item = CreateItem(checkBox.Text, (int)numeric.Value);
            Order.Add(item);
            RenderDetail(Order.ShowPanel());


        }

        public void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;
            CheckBox checkBox = (CheckBox)numeric.Parent.Controls[0];

            checkBox.Checked = numeric.Value != 0 ? true : false;

            Item item = CreateItem(checkBox.Text, (int)numeric.Value);
            Order.Add(item);
            RenderDetail(Order.ShowPanel());
        }



    }
}
