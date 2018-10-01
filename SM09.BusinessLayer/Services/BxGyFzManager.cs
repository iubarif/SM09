using SM09.Common.Core;
using SM09.Common.Entities;
using SM09.Common.Entities.Discount;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SM09.BusinessLayer.Services
{
    class BxGyFzManager : IProductDiscountManager
    {
        private readonly IUnitOfWork unitOfWork;

        public BxGyFzManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        // The appropriate discount object will be selected by a factory class
        public decimal CalculateDiscount(LineItem lineItem)//(Order order, Product product)
        {
            //var totalUnits = order.LineItems
            //    .Where(o => o.Product.Id == product.Id)
            //    .Select(ol => ol.Unit).Sum();

            var totalUnits = lineItem.Unit;
            var product = lineItem.Product;

            var unitPrice = product.Price;

            // If there are multiple active discounts available for a single product,
            // Then the application will only take the top one.
            var BxGyFDiscountItem  = unitOfWork.BxGyFzDiscounts.GetAll()
                .Where(i => i.DiscountForProduct.Active == true && i.DiscountForProduct.ProductId == product.Id)
                .Take(1).FirstOrDefault();

            if (BxGyFDiscountItem != null)
            {
                var withDiscountUnitPriceFormula = (
                    (unitPrice * BxGyFDiscountItem.MinimumUnites) 
                    + ((unitPrice - (unitPrice * BxGyFDiscountItem.DiscountInPercent/ 100)) * BxGyFDiscountItem.OfferUnites)) 
                    / (BxGyFDiscountItem.MinimumUnites + BxGyFDiscountItem.OfferUnites);

                return totalUnits * (unitPrice - withDiscountUnitPriceFormula);
            }

            return 0;
        }

        public void Create(BaseEntity entity)
        {
            unitOfWork.BxGyFzDiscounts.Add(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        public void Delete(BaseEntity entity)
        {
            BxGyFz bxGyFz = ConvertBaseEntity(entity);
            bxGyFz.DiscountForProduct.Active = false;
            unitOfWork.BxGyFzDiscounts.Update(bxGyFz);
        }

        public BaseEntity Get(int Id)
        {
            return unitOfWork.BxGyFzDiscounts.Get(Id);
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return unitOfWork.BxGyFzDiscounts.GetAll();
        }

        public void Update(BaseEntity entity)
        {
            unitOfWork.BxGyFzDiscounts.Update(ConvertBaseEntity(entity));
            unitOfWork.SaveChanges();
        }

        private BxGyFz ConvertBaseEntity(BaseEntity entity)
        {
            return (BxGyFz)entity;
        }
    }
}
