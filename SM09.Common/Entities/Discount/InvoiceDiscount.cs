using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities.Discount
{
    public class InvoiceDiscount: BaseEntity
    {
        public decimal MinimumSpend { get; set; }
        public decimal Discount { get; set; }
        public bool InPercent { get; set; }
        public bool Active { get; set; }
        public DateTime ActiveTill { get; set; }

    }
}
