using SM09.Common.Entities;
using SM09.Common.Entities.Discount;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test_BxGyFz()
        {
            var category = new Category() { Id = 1, Name="General", Active = true}; 
            var mou = new MeasureOfUnit() { Id = 1, MOU = "Pc", Active = true };

            var priceId = new Guid();
            var product = new Product() {
                Id =1, CategoryId = 1, Category = category, Name = "Good Pen",
                MOU = mou, MOUId = mou.Id,Price = 5,PriceId = priceId, Active = true};

            var discountForProduct = new DiscountForProduct()
            {
                Id = 1,
                Active = true,
                Name = "B 2 G 1 F Free",
                Product = product,
                ProductId = product.Id
            };

            var discount = new BxGyFz(discountForProduct, x:2, y:1, z:50);

            var order = new Order() { Id = 1 };

            var lineItem = new OrderDetail() { Id = 1, Product = product, ProductId = product.Id,PriceId = priceId,OrderId = order.Id, Order = order, Unit = 4};
            order.LineItems.Add(lineItem);

            var discountedPrice = discount.AfterDiscountPrice(order);

            Assert.Equal(13.33M, decimal.Round(discountedPrice,2,MidpointRounding.AwayFromZero));
            //Assert.Equal(20.00M, decimal.Round(discountedPrice, 2, MidpointRounding.AwayFromZero));
            //Assert.Equal(10.00M, decimal.Round(discountedPrice, 2, MidpointRounding.AwayFromZero));
            //Assert.Equal(16.66M, decimal.Round(discountedPrice, 2, MidpointRounding.AwayFromZero));
        }
    }
}
