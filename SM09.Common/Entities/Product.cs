using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int MOUId { get; set; }
        public MeasureOfUnit MOU { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public Guid PriceId { get; set; }
        public bool Active { get; set; } = true;
        public List<DiscountForProduct> Discounts { get; set; }


    }
}
