using SM09.Common.Core;
using SM09.Common.Entities;
using SM09.Common.Entities.Discount;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;

namespace SM09.BusinessLayer.Services
{
    public class InvoiceDiscountManager : IInvoiceDiscountManager
    {
        IUnitOfWork unitOfWork;

        public InvoiceDiscountManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public decimal CalculateInvoiceDiscount(decimal orderTotal, InvoiceDiscount discount)
        {
            if (orderTotal >= discount.MinimumSpend)
            {
                if (!discount.InPercent)
                    return discount.Discount;
                else                
                    return orderTotal * (discount.Discount / 100);
            }
            else
                return 0;

        }

        public void Create(BaseEntity entity)
        {
            unitOfWork.InvoiceDiscounts.Add(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        public void Delete(BaseEntity entity)
        {
            InvoiceDiscount invoiceDiscount = ConvertBaseEntity(entity);
            invoiceDiscount.Active = false;
            unitOfWork.InvoiceDiscounts.Update(invoiceDiscount);
        }

        public BaseEntity Get(int Id)
        {
            return unitOfWork.InvoiceDiscounts.Get(Id);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return unitOfWork.Categories.GetAll();
        }

       
        public void Update(BaseEntity entity)
        {
            unitOfWork.InvoiceDiscounts.Update(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        private InvoiceDiscount ConvertBaseEntity(BaseEntity entity) {
            return (InvoiceDiscount)entity;
        }
    }
}
