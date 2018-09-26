using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class OrderDetail: BaseEntity
    {
        public int Id { get; set; }
        public Order OrderId { get; set; }
        public Product ProductId { get; set; }
        public int Unit { get; set; }
        public Guid PriceId { get; set; }
    }
}
