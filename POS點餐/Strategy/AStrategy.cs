using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POS點餐.Models.MenuModel;

namespace POS點餐.Strategy
{
    internal abstract class AStrategy
    {

        public List<Item> list = null;
        public StrategyType type = null;
        public AStrategy(List<Item> list, StrategyType type)
        {
            this.list = list;
            this.type = type;
        }

        public abstract void DiscountOff();
    }
}
