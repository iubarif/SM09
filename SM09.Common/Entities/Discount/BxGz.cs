using SM09.Common.Interface;
using System.Linq;

namespace SM09.Common.Entities.Discount
{
    /// <summary>
    /// Buy X (unit) and Get Z% discount
    /// </summary>
    public class BxGz : DiscountForProduct, IProductDiscount
    {
        private int _x;
        private int _z;

        public BxGz(int x, int z)
        {
            _x = x;
            _z = z;
        }
        public decimal AfterDiscountPrice(Order order)
        {
            var totalUnits = order.LineItems
                .Where(o => o.Product.Id == this.Product.Id)
                .Select(ol => ol.Unit).Sum();

            var discountedUnitPrice = this.Product.Price - (this.Product.Price * _z / 100);

            decimal discountedPrice = totalUnits * this.Product.Price;

            if (totalUnits >= _x)
            {
                discountedPrice = totalUnits * discountedUnitPrice;
            }
            
            return discountedPrice;
        }
    }
}
