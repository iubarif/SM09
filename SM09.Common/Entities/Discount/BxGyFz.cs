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
    public class BxGyFz : BaseEntity,IProductDiscount // DiscountForProduct, 
    {
        public DiscountForProduct DiscountForProduct { get; }

        public int MinimumUnites { get; set; }
        public int OfferUnites { get; set; }
        public int DiscountInPercent { get; set; }
        
        public BxGyFz(DiscountForProduct discountForProduct, int x, int y, int z) // : base(discountForProduct)            
        {
            DiscountForProduct = discountForProduct;
            this.MinimumUnites = x;
            this.OfferUnites = y;
            this.DiscountInPercent = z;
        }

        public string GetDiscountClassName()
        {
            return this.GetType().Name;
        }
    }
}
