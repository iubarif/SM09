using SM09.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess.Core
{
    public interface IUnitOfWork : IDisposable
    {
        CategoryRepository Categories { get; }
        MeasureOfUnitesRepository MOUs { get; }
        ProductRepository Products { get; }
        OrderRepository Orders { get; }
        LineItemRepository LineItems { get; }
        DiscountForProductRepository DiscountForProducts { get; }
        BxGyFzRepository BxGyFzDiscounts { get; }
        //BxGzRepository BxGzDiscounts { get; }
        InvoiceDiscountRepository InvoiceDiscounts { get; }

        void SaveChanges();
    }
}
