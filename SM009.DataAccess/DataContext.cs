using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SM09.Common.Entities;

namespace SM09.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext(IConfiguration config) :base()
        {

        }

        public virtual void Save()
        {
            base.SaveChanges();
        }

        #region Entities representing Database Objects
        public DbSet<Category> Category { get; set; }
        public DbSet<MeasureOfUnit> MeasureOfUnit { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<LineItem> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductHistory> ProductHistory { get; set; }        
        #endregion
    }
}
