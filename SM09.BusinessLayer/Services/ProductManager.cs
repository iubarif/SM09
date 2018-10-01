using SM09.Common.Core;
using SM09.Common.Entities;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;

namespace SM09.BusinessLayer.Services
{
    public class ProductManager : IProductManager
    {
        IUnitOfWork unitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(Product entity)
        {
            unitOfWork.Products.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(Product entity)
        {
            entity.Active = false;
            unitOfWork.Products.Update(entity);
        }

        public Product Get(int Id)
        {
            return unitOfWork.Products.Get(Id);
        }

        public IEnumerable<Product> GetAll()
        {
            return unitOfWork.Products.GetAll();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(Product entity)
        {
            unitOfWork.Products.Update(entity);
            unitOfWork.SaveChanges();
        }
    }
}
