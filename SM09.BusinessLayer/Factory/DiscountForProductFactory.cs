using SM09.Common.Entities;
using SM09.Common.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SM09.BusinessLayer.Factory
{
    public class DiscountForProductFactory
    {
        private DiscountForProduct _discountProduct;
        public DiscountForProductFactory(DiscountForProduct discountProduct)
        {
            _discountProduct = discountProduct;
        }

        //public IProductDiscount ProductDiscount() {

        //    switch (_discountProduct.Type) {
        //        case ProductDiscountType.type1:
        //            return null; // new IProductDiscount(); 
        //        case ProductDiscountType.type2:
        //            return null; // new IProductDiscount(); 
        //        case ProductDiscountType.type3:
        //            return null; // new IProductDiscount(); 
        //        default:
        //            return null;

        //    };
        //}
    }
}
