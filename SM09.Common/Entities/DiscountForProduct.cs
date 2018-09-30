using SM09.Common.Core;
using SM09.Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class DiscountForProduct : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public DateTime ActiveTill { get; set; }
        public IProductDiscount ProductDiscount { get; set; }

        public DiscountForProduct(DiscountForProduct discount)
        {
            this.Id = discount.Id;
            this.ProductId = discount.ProductId;
            this.Product = discount.Product;
            this.Name = discount.Name;
            this.Active = discount.Active;
            ActiveTill = discount.ActiveTill;
        }

    }
}
