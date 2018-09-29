using SM09.Common.Core;
using SM09.Common.Entities;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;

namespace SM09.BusinessLayer.Services
{
    public class MeasureOfUnitManager : IMeasureOfUnitManager
    {
        IUnitOfWork unitOfWork;

        public MeasureOfUnitManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(BaseEntity entity)
        {
            unitOfWork.MOUs.Add(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        public void Delete(BaseEntity entity)
        {
            MeasureOfUnit category = ConvertBaseEntity(entity);
            category.Active = false;
            unitOfWork.MOUs.Update(category);
            unitOfWork.SaveChanges();
        }

        public BaseEntity Get(int Id)
        {
            return unitOfWork.MOUs.Get(Id);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return unitOfWork.MOUs.GetAll();
        }


        public void Update(BaseEntity entity)
        {
            unitOfWork.MOUs.Update(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        private MeasureOfUnit ConvertBaseEntity(BaseEntity entity)
        {
            return (MeasureOfUnit)entity;
        }
    }
}
