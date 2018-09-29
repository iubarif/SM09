using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class MeasureOfUnit : BaseEntity
    {
        public string MOU { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true;
    }
}
