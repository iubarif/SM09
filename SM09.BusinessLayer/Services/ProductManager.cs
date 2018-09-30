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

        public void Create(BaseEntity entity)
        {
            unitOfWork.Products.Add(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        public void Delete(BaseEntity entity)
        {
            Product product = ConvertBaseEntity(entity);
            product.Active = false;
            unitOfWork.Products.Update(product);
        }

        public BaseEntity Get(int Id)
        {
            return unitOfWork.Products.Get(Id);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return unitOfWork.Products.GetAll();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            unitOfWork.Products.Update(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        private Product ConvertBaseEntity(BaseEntity entity)
        {
            return (Product)entity;
        }
    }
}
