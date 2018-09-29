using SM09.Common.Core;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.BusinessLayer.Services
{
    public abstract class ActionManager : IActionManager
    {
        IUnitOfWork unitOfWork;

        public ActionManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create<T>(T entity) where T : BaseEntity
        {
            //T t = T(entity);
            _repository.Create<T>(entity);

            unitOfWork.
        }

        public void Delete<T>(T entity)
        {
            entity.Active = false;
            _repository.Update<Category>(category);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Category>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        private T ConvertBaseEntity<T>(BaseEntity entity)
        {
            return T(entity);
        }
    }
}
