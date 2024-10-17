using POS點餐.Discounts;
using POS點餐.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static POS點餐.Models.MenuModel;

namespace POS點餐
{
    internal class DisCount
    {

        public static void DiscountOrder(List<Item> items, StrategyType discountType)
        {
            items = items.Where(x => !x.Name.Contains("(優惠)")).ToList();
            Type t = Type.GetType("POS點餐.Strategy." + discountType.Strategy);
            AStrategy type = (AStrategy)Activator.CreateInstance(t, new object[] { items, discountType });


            DiscountContext context = new DiscountContext(type);
            context.Discount();

            ShowPanel.ShowThePanel(items);
        }


    }
}
