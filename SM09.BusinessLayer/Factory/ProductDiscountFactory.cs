using SM09.BusinessLayer.Services;
using SM09.Common.Entities;
using SM09.Common.Entities.Discount;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.BusinessLayer.Factory
{
    public class ProductDiscountFactory : IProductDiscountFactory
    {
        private DiscountForProduct _discountProduct;
        private readonly IUnitOfWork unitOfWork;

        public ProductDiscountFactory(DiscountForProduct discountProduct, IUnitOfWork unitOfWork)
        {
            _discountProduct = discountProduct;
            this.unitOfWork = unitOfWork;
        }

        public IProductDiscountManager GetProductDiscountObject(DiscountForProduct discountForProduct)
        {
            var discountType = discountForProduct.ProductDiscount.GetDiscountClassName();

            var type = discountType.GetType();
           
            if (discountType == nameof(BxGyFz)) {
                return new BxGyFzManager(unitOfWork);
            }

            return null;
        }        
    }
}
