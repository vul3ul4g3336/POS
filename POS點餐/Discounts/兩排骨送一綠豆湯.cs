using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS點餐.Discounts
{
    internal class 兩排骨送一綠豆湯 : DiscountType
    {
        private string A_product;
        private string B_product;
        private int CountOfA;
        private int CountOfB;
        public 兩排骨送一綠豆湯(List<Item> list,string A,string B,int A_Count,int B_Count) : base(list)
        {
            A_product = A;
            B_product = B;
            CountOfA = A_Count;
            CountOfB = B_Count;
        }

        public override void DiscountOff()
        {
            Item mainProduct = list.FirstOrDefault(x => x.Name == A_product && x.Count >= CountOfA);
            Item secondaryProduct = list.FirstOrDefault(x => x.Name == B_product);

            if (mainProduct != null)
            {
                int freeProduct = mainProduct.Count / CountOfA;
                if (secondaryProduct.Count == 0)
                {
                    list.Add(new Item($"(優惠)贈送{B_product}", 0, freeProduct));
                }
                if (freeProduct > secondaryProduct.Count)
                {
                    int diff = freeProduct - secondaryProduct.Count;
                    list.Add(new Item($"(優惠)贈送{B_product}", secondaryProduct.Price * -1, secondaryProduct.Count));
                    list.Add(new Item($"(優惠)贈送{B_product}", 0, diff));

                }
                else
                {
                    int diff = secondaryProduct.Count - secondaryProduct.Count;
                    list.Add(new Item($"(優惠)贈送{B_product}", secondaryProduct.Price * -1, secondaryProduct.Count));
                    list.Add(new Item($"(優惠)贈送{B_product}", 0, diff));
                }

            }

        }
    }
}
