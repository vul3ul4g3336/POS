using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS點餐
{
    internal class PanelEvent
    {
        public static event EventHandler<OrderDetails> ReceiveInfo;

        public static void NotifyMessage(OrderDetails Panel)
        {
            ReceiveInfo.Invoke(null, Panel);
        }
    }
}
