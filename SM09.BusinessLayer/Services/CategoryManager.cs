using SM09.Common.Core;
using SM09.Common.Entities;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;

namespace SM09.BusinessLayer.Services
{
    public class CategoryManager : ICategoryManager
    {
        IRepository _repository;        
        IUnitOfWork _unitOfWork;

        public CategoryManager(IRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            Category category = ConvertBaseEntity(entity);
            _repository.Create<Category>(category);            
        }

        public void Delete(BaseEntity entity)
        {
            Category category = ConvertBaseEntity(entity);
            category.Active = false;
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

        private Category ConvertBaseEntity(BaseEntity entity) {
            return (Category)entity;
        }
    }
}
