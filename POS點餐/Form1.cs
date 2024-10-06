using POS點餐.Discounts;
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
        //        不打折

        List<KeyValueModel> discounts = new List<KeyValueModel>()
        {
            new KeyValueModel("不打折","WithoutDiscount"),
            new KeyValueModel("雞腿飯買二送一","雞腿飯買二送一"),
            new KeyValueModel("雞排飯買三個250(折20)","雞排飯3個折20"),
            new KeyValueModel("買兩個排骨飯送一碗綠豆湯","兩排骨送一綠豆湯"),
            new KeyValueModel("雞排飯搭玉米濃湯打九折","雞排飯搭玉米湯九折"),
            new KeyValueModel("排骨飯加洋蔥圈加紅茶 150元","排骨飯洋蔥圈紅茶150元"),
            new KeyValueModel("飲料三杯100元","飲料三杯100"),
            new KeyValueModel("鰻魚飯搭配洋蔥圈150元","鰻魚飯洋蔥圈150元"),
            new KeyValueModel("全場消費滿300折50","滿300折50"),
            new KeyValueModel("全場消費打八折","全場八折"),
        };
        public Form1()
        {
            InitializeComponent();

            PanelEvent.ReceiveInfo += PanelEvent_ReceiveInfo;
            comboBox1.DataSource = discounts;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";

        }

        private void PanelEvent_ReceiveInfo(object sender, OrderDetails e)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(e.flowLayoutPanel);
            label1.Text = e.total.ToString();
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
            flowLayoutPanel1.CheckBoxDisplay(foodChoices, CheckBoxCheckedChange, ValueChange);
            flowLayoutPanel2.CheckBoxDisplay(snackChoices, CheckBoxCheckedChange, ValueChange);
            flowLayoutPanel3.CheckBoxDisplay(soupChoices, CheckBoxCheckedChange, ValueChange);
            flowLayoutPanel4.CheckBoxDisplay(drinkChoices, CheckBoxCheckedChange, ValueChange);
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
            Order.Add(item, comboBox1.SelectedValue.ToString());



        }

        public void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;
            CheckBox checkBox = (CheckBox)numeric.Parent.Controls[0];

            checkBox.Checked = numeric.Value != 0 ? true : false;

            Item item = CreateItem(checkBox.Text, (int)numeric.Value);
            Order.Add(item, comboBox1.SelectedValue.ToString());

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is string)
            {
                Order.OrderDiscount(comboBox1.SelectedValue.ToString());

            }


        }


    }
}








