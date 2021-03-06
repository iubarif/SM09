﻿using SM09.Common.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Interface
{
    public interface IProductDiscountManager// : IActionManager<IProductDiscount>
    {
        decimal CalculateDiscount(LineItem lineItem);
    }
}
