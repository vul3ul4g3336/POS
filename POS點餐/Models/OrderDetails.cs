using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐
{
    internal class OrderDetails
    {
        public FlowLayoutPanel flowLayoutPanel;
        public int total;
        public OrderDetails(FlowLayoutPanel panel, int total)
        {
            this.flowLayoutPanel = panel;
            this.total = total;
        }

    }
}
