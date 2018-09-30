using SM09.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.DTO
{
    public class DTOOrder
    {
        
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal InvoiceDiscount { get; set; }
        public decimal TotalWithoutDiscount { get; set; }
        public decimal Total { get; set; }

        public List<DTOLineItem> LineItems { get; set; }

        public DTOOrder()
        {
            LineItems = new List<DTOLineItem>();
        }
    }
}
