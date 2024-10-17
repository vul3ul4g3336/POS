using Newtonsoft.Json;
using POS點餐.Discounts;
using POS點餐.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static POS點餐.Models.MenuModel;
using static System.Net.Mime.MediaTypeNames;

namespace POS點餐
{
    public partial class Form1 : Form
    {

        StrategyType[] strategies = null;


        public Form1()
        {
            InitializeComponent();

            PanelEvent.ReceiveInfo += PanelEvent_ReceiveInfo;


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String filePath = ConfigurationManager.AppSettings["Menu"];
            StreamReader reader = new StreamReader(filePath);
            string menuContent = reader.ReadToEnd();
            MenuModel model = JsonConvert.DeserializeObject<MenuModel>(menuContent);
            strategies = model.Strategies;
            comboBox1.DataSource = strategies;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Strategy";
            foreach (MenuType menu in model.Menu)
            {
                FlowLayoutPanel Panel = new FlowLayoutPanel();
                Panel.HorizontalScroll.Maximum = 0;
                Panel.AutoScroll = false;
                Panel.VerticalScroll.Visible = false;
                Panel.AutoScroll = true;

                Label label = new Label();
                label.Text = menu.TypeName;
                Panel.Controls.Add(label);
                Panel.Width = MenuContainer.Width / 2 - 20;
                label.Width = Panel.Width;
                Panel.Height = MenuContainer.Height / 2;
                Panel.CheckBoxDisplay(menu.Foods, CheckBoxCheckedChange, ValueChange);

                MenuContainer.Controls.Add(Panel);
            }
        }


        private void PanelEvent_ReceiveInfo(object sender, OrderDetails e)
        {
            flowLayoutPanel5.Controls.Clear();
            flowLayoutPanel5.Controls.Add(e.flowLayoutPanel);
            label1.Text = e.total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int sum = 0;
            //sum += flowLayoutPanel1.OrderConfirm();
            //sum += flowLayoutPanel2.OrderConfirm();
            //sum += flowLayoutPanel3.OrderConfirm();
            //sum += flowLayoutPanel4.OrderConfirm();
            //label1.Text = sum.ToString();
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

            StrategyType type = strategies.First(x => x.Name == comboBox1.Text);
            Order.Add(item, type);





        }

        public void ValueChange(object sender, EventArgs e)
        {
            NumericUpDown numeric = (NumericUpDown)sender;
            CheckBox checkBox = (CheckBox)numeric.Parent.Controls[0];

            checkBox.Checked = numeric.Value != 0 ? true : false;

            Item item = CreateItem(checkBox.Text, (int)numeric.Value);

            StrategyType type = strategies.First(x => x.Name == comboBox1.Text);
            Order.Add(item, type);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue is string)
            {
                string strategy = comboBox1.Text;
                StrategyType type = strategies.First(x => x.Name == strategy);

                Order.OrderDiscount(type);

            }


        }


    }
}








