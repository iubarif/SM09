using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.DTO
{
    public class DTOLineItem
    {
        public string Name { get; set; }
        public int TotalUnites { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal LineItemTotal { get; set; }
    }
}
