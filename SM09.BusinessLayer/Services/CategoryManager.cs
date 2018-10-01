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
        IUnitOfWork unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Category entity)
        {
            unitOfWork.Categories.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Category entity)
        {
            entity.Active = false;
            unitOfWork.Categories.Update(entity);
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public Category Get(int Id)
        {
            return unitOfWork.Categories.Get(Id);
        }

        public IEnumerable<Category> GetAll()
        {
            return unitOfWork.Categories.GetAll();
        }

        public void Update(Category entity)
        {
            unitOfWork.Categories.Update(entity);
            unitOfWork.SaveChanges();
        }

       
    }
}
