using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐
{
    internal static class Extension
    {
        // "無法改動的類別" 的擴充功能
        public static int CalcNumberCountFromString(this string str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    count++;
                }
            }

            return count;
        }

        public static void CheckBoxDisplay(this FlowLayoutPanel flowLayout, string[] str, EventHandler CheckedChanged, EventHandler ValueChanged)
        {

            for (int i = 0; i < str.Length; i++)
            {
                FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
                NumericUpDown numericUpDown = new NumericUpDown();
                CheckBox checkBox = new CheckBox();
                flowLayoutPanel.Controls.Add(checkBox);
                flowLayoutPanel.Controls.Add(numericUpDown);

                checkBox.CheckedChanged += CheckedChanged;
                numericUpDown.ValueChanged += ValueChanged;

                checkBox.Text = str[i];

                flowLayout.Controls.Add(flowLayoutPanel);
                flowLayoutPanel.Height = 30;
                numericUpDown.Width = 50;
            }
        }

        public static int OrderConfirm(this FlowLayoutPanel flowLayoutPanel)
        {
            int sum = 0;
            foreach (FlowLayoutPanel x in flowLayoutPanel.Controls)
            {
                CheckBox checkBox = (CheckBox)x.Controls[0];
                NumericUpDown numeric = (NumericUpDown)x.Controls[1];
                if (checkBox.Checked)
                {
                    int num = (int)numeric.Value;
                    sum += int.Parse(checkBox.Text.Split('$')[1]) * num;
                }

            }
            return sum;
        }
    }
}
