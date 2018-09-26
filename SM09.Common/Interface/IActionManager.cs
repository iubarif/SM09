using SM09.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.Common.Interface
{
    public interface IActionManager
    {
        void Create(BaseEntity entity);
        void Update(BaseEntity entity);
        void Delete(BaseEntity entity);
        IEnumerable<BaseEntity> GetAll();
        // IUnitOfWork UnitOfWork { get; }
        void SaveChanges();
    }
}
