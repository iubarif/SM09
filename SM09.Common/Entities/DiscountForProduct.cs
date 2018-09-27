using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class DiscountForProduct : BaseEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        //public ProductDiscountType Type { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; } = true;
        public DateTime ActiveTill { get; set; }
    }
}
