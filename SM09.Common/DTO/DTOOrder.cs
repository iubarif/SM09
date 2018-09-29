using SM09.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.DTO
{
    public class DTOOrder
    {
        public Order Order { get; set; }
        public decimal TotalCost { get; set; }
    }
}
