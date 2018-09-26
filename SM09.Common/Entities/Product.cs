﻿using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Entities
{
    public class Product: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MeasureOfUnit MOU { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public Guid PriceId { get; set; }
        public bool Active { get; set; } = true;

    }
}