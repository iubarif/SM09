using SM09.Common.Interface;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities.Discount
{
    /// <summary>
    /// Buy X (unit) and Get Y (Unit) for Z (price)
    /// Ex: Buy 3 pens and Get 2 for 50% discount
    /// If you want to give Y unit for Free, then set Z = 0;
    /// </summary>
    public class BxGyFz : DiscountForProduct, IProductDiscount
    {
        private int _x;
        private int _y;
        private int _z;

        public BxGyFz(int x, int y, int z)
        {
            _x = x;
            _y = y;
            _z = z;
        }

        public decimal AfterDiscountPrice(Order order)
        {
            var totalUnits = order.LineItems
                .Where(o => o.Product.Id == this.Product.Id)
                .Select(ol => ol.Unit).Sum();

            var p = this.Product.Price;

            var withDiscountUnitPrice = ((p * _x)  + ((p- (p * _z/100)) * _y))/(_x+_y);

            decimal totalPrice = totalUnits * p;
            decimal discountedPrice = 0m;
            
            while (totalUnits - (_x + _y) > -1)
            {
                discountedPrice += (_x + _y) * withDiscountUnitPrice;

                totalUnits -= (_x + _y);
            }

            return discountedPrice > 0 ? discountedPrice : totalPrice;            
        }
    }
}
