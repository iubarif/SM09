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

        public void Create(MeasureOfUnit entity)
        {
            unitOfWork.MOUs.Add(entity);
            unitOfWork.SaveChanges();
        }

        public void Delete(MeasureOfUnit entity)
        {            
            entity.Active = false;
            unitOfWork.MOUs.Update(entity);
            unitOfWork.SaveChanges();
        }

        public MeasureOfUnit Get(int Id)
        {
            return unitOfWork.MOUs.Get(Id);
        }

        public IEnumerable<MeasureOfUnit> GetAll()
        {
            return unitOfWork.MOUs.GetAll();
        }


        public void Update(MeasureOfUnit entity)
        {
            unitOfWork.MOUs.Update(entity);
            unitOfWork.SaveChanges();
        }
    }
}
