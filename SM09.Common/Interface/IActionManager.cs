using SM09.Common.Core;
using System.Collections.Generic;

namespace SM09.Common.Interface
{
    public interface IActionManager<T> where T : BaseEntity 
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(int Id);        
    }
}
