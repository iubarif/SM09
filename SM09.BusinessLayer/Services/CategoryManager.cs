﻿using SM09.Common.Core;
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

        public void Create(BaseEntity entity)
        {
            unitOfWork.Categories.Add(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        public void Delete(BaseEntity entity)
        {
            Category category = ConvertBaseEntity(entity);
            category.Active = false;
            unitOfWork.Categories.Update(category);
        }

        public BaseEntity Get(int Id)
        {
            return unitOfWork.Categories.Get(Id);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return unitOfWork.Categories.GetAll();
        }

       
        public void Update(BaseEntity entity)
        {
            unitOfWork.Categories.Update(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        private Category ConvertBaseEntity(BaseEntity entity) {
            return (Category)entity;
        }
    }
}
