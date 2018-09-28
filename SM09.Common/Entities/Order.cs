using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class Order: BaseEntity
    {
        public int Id { get; set; }
        public string Note { get; set; }
        public List<OrderDetail> LineItems { get; set; }

        public Order()
        {
            LineItems = new List<OrderDetail>();
        }
    }
}
