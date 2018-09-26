using Microsoft.EntityFrameworkCore;
using SM09.Common.Entities;

namespace SM09.DataAccess
{
    public class DataContext: DbContext
    {
        public virtual void Save()
        {
            base.SaveChanges();
        }

        #region Entities representing Database Objects
        public DbSet<Category> Category { get; set; }
        public DbSet<MeasureOfUnit> MeasureOfUnit { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductHistory> ProductHistory { get; set; }        
        #endregion
    }
}
