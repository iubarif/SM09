using SM09.DataAccess.Core;
using SM09.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        public readonly DataContext dataContext;

        public CategoryRepository Categories { get; set; }
        public MeasureOfUnitesRepository MOUs { get; private set; }
        public ProductRepository Products { get; private set; }
        public OrderRepository Orders { get; private set; }
        public LineItemRepository LineItems { get; private set; }
        public DiscountForProductRepository DiscountForProducts { get; private set; }
        public BxGyFzRepository BxGyFzDiscounts { get; private set; }
        // public BxGzRepository BxGzDiscounts { get; private set; }
        public InvoiceDiscountRepository InvoiceDiscounts { get; set; }

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            this.dataContext = dbFactory.GetDataContext;

            Categories = new CategoryRepository(this.dataContext);
            MOUs = new MeasureOfUnitesRepository(this.dataContext);
            Products = new ProductRepository(this.dataContext);
            Orders = new OrderRepository(this.dataContext);
            LineItems = new LineItemRepository(this.dataContext);
            DiscountForProducts = new DiscountForProductRepository(this.dataContext);
            BxGyFzDiscounts = new BxGyFzRepository(this.dataContext);
            //BxGzDiscounts = new BxGzRepository(this.dataContext);
            InvoiceDiscounts = new InvoiceDiscountRepository(this.dataContext);
        }

        public void SaveChanges()
        {
            dataContext.Save();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }

        public DataContext GetDataContext()
        {
            return dataContext;
        }
    }
}
