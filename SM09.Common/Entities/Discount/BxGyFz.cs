using SM09.Common.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SM09.Common.Core;

namespace SM09.Common.Entities.Discount
{
    /// <summary>
    /// Buy X (unit) and Get Y (Unit) for Z (price)
    /// Ex: Buy 3 pens and Get 2 for 50% discount
    /// If you want to give Y unit for Free, then set Z = 0;
    /// </summary>
    public class BxGyFz : BaseEntity, IProductDiscount
    {
        public DiscountForProduct DiscountForProduct { get; }

        private readonly int x;
        private readonly int y;        
        private readonly int z;
        
        public BxGyFz(DiscountForProduct discountForProduct, int x, int y, int z)
        {
            DiscountForProduct = discountForProduct;
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public decimal AfterDiscountPrice(Order order)
        {
            var totalUnits = order.LineItems
                .Where(o => o.Product.Id == DiscountForProduct.ProductId)
                .Select(ol => ol.Unit).Sum();

            var p = DiscountForProduct.Product.Price;

            if (z > 0 && z <= 100)
            {
                var withDiscountUnitPriceFormula = ((p * x) + ((p - (p * z / 100)) * y)) / (x + y);
                return totalUnits * withDiscountUnitPriceFormula;
            }
            else {
                // Means no discount provided
                return totalUnits * p;
            }

            //var withDiscountUnitPrice = ((p * x)  + ((p- (p * z/100)) * y))/(x+y);

            //decimal totalPrice = totalUnits * p;
            //decimal discountedPrice = 0m;
            
            //while (totalUnits - (x + y) > -1)
            //{
            //    discountedPrice += (x + y) * withDiscountUnitPrice;

            //    totalUnits -= (x + y);
            //}

            //if (totalUnits > 0)
            //{
            //    discountedPrice += totalUnits * p;
            //}

            //return discountedPrice > 0 ? discountedPrice : totalPrice;            
        }
    }
}
