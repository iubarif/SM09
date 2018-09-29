using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class Order: BaseEntity
    {
        public string Note { get; set; }
        public List<LineItem> LineItems { get; set; }

        public Order()
        {
            LineItems = new List<LineItem>();
        }
    }
}
