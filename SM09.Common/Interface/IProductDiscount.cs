﻿using SM09.Common.Entities;
using System;

namespace SM09.Common.Interface
{
    public interface IProductDiscount
    {
        decimal AfterDiscountPrice(Order order);
    }
}
