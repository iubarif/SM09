using Microsoft.EntityFrameworkCore;
using SM09.Common.Core;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SM09.DataAccess
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DataContext context;
        protected DbSet<T> objectSet;

        public Repository(DataContext context)
        {
            this.context = context;
            objectSet = this.context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            objectSet.Add(entity);
            
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return objectSet.Where(predicate);
        }

        public T Get(int Id)
        {
            return objectSet.AsNoTracking().FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return objectSet.AsNoTracking().ToList();
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
