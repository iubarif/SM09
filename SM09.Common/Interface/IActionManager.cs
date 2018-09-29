using SM09.Common.Core;
using System.Collections.Generic;

namespace SM09.Common.Interface
{
    public interface IActionManager
    {
        void Create(BaseEntity entity);
        void Update(BaseEntity entity);
        void Delete(BaseEntity entity);
        IEnumerable<BaseEntity> GetAll();
        BaseEntity Get(int Id);        
    }
}
