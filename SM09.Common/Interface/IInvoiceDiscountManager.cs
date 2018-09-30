using SM09.Common.Entities.Discount;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Interface
{
    public interface IInvoiceDiscountManager
    {
        decimal CalculateInvoiceDiscount(decimal orderTotal, InvoiceDiscount discount);
    }
}
