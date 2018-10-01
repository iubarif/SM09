using Moq;
using SM09.BusinessLayer.Services;
using SM09.Common.Entities;
using SM09.Common.Entities.Discount;
using SM09.DataAccess;
using SM09.DataAccess.Core;
using SM09.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace XUnitTestProject
{
    public class UnitTest1
    {
        //[Fact]
        //public void Test_BxGyFz()
        //{
        //    var category = new Category() { Id = 1, Name="General", Active = true}; 
        //    var mou = new MeasureOfUnit() { Id = 1, MOU = "Pc", Active = true };

        //    var priceId = new Guid();
        //    var product = new Product() {
        //        Id =1, CategoryId = 1, Category = category, Name = "Good Pen",
        //        MOU = mou, MOUId = mou.Id,Price = 5,PriceId = priceId, Active = true};

        //    var discountForProduct = new DiscountForProduct()
        //    {
        //        Id = 1,
        //        Active = true,
        //        Name = "B 2 G 1 F Free",
        //        Product = product,
        //        ProductId = product.Id
        //    };

        //    var discount = new BxGyFz(discountForProduct, x:2, y:1, z:50);

        //    var order = new Order() { Id = 1 };

        //    var lineItem = new LineItem() { Id = 1, Product = product, ProductId = product.Id,PriceId = priceId,OrderId = order.Id, Order = order, Unit = 4};
        //    order.LineItems.Add(lineItem);

        //    var discountedPrice = discount.AfterDiscountPrice(order);

        //    Assert.Equal(13.33M, decimal.Round(discountedPrice,2,MidpointRounding.AwayFromZero));
        //    //Assert.Equal(20.00M, decimal.Round(discountedPrice, 2, MidpointRounding.AwayFromZero));
        //    //Assert.Equal(10.00M, decimal.Round(discountedPrice, 2, MidpointRounding.AwayFromZero));
        //    //Assert.Equal(16.66M, decimal.Round(discountedPrice, 2, MidpointRounding.AwayFromZero));
        //}


        [Fact]
        public void TestMethod2()
        {
            // var moq = new Mock<>();
            // var manager = new 
            // moq.set

            // Create Manager
            //var moqDBFactory = new Mock<IDbFactory>();
            var moqUOW = new Mock<IUnitOfWork>();

            moqUOW.Object.Categories = new CategoryRepository(moqUOW.Object.GetDataContext());

            moqUOW.Setup(u => u.Categories).Returns(moqUOW.Object.Categories);

            var category = new Category() { Id = 1, Name = "Food", Description = "NA", CreatedBy = "AM", UpdatedBy = "AM" };

            // var uwo = new UnitOfWork(moqDBFactory.Object);
            var categoryManager = new CategoryManager(moqUOW.Object);
            categoryManager.Create(category);


            var x = categoryManager.GetAll();
            // moqManager.Object.Create()
            // x = x;
        }

        [Fact]
        public void TestMethod3()
        {
            var MOUs = new List<MeasureOfUnit>()
                {
                    new MeasureOfUnit() { Id = 1, MOU="Pc"}
                };


            var Products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "SM Pen",
                    MOUId = 1,
                    MOU = MOUs.Find(m => m.Id == 1),
                    Price = 2.0m,
                    PriceId = Guid.NewGuid()
                },
                new Product()
                {
                    Id = 2,
                    Name = "SM Note Book",
                    MOUId = 1,
                    MOU = MOUs.Find(m => m.Id == 1),
                    Price = 5.0m,
                    PriceId = Guid.NewGuid()
                }
            };

            var discount4Product = new DiscountForProduct() {
                Id = 1,
                Name = "Buy 3 Get 1 For free",
                ActiveTill = DateTime.Now.AddDays(2),
                Product = Products.Find(p => p.Id ==1),
                ProductId = 1,
                ProductDiscount = new BxGyFz() {
                    Id = 1,
                    MinimumUnites = 3,
                    OfferUnites = 1,
                    DiscountInPercent = 100
                }

            };

            var prod1 = Products.Find(p => p.Id == 1);
            prod1.Discounts.Add(discount4Product);

            var order = new Order() {
                Id = 1,
                LineItems = new List<LineItem>(){
                    new LineItem(){
                        Id = 1,
                        Product = prod1,
                        ProductId = 1,
                        Unit = 5,                        
                    }
                }
            };            
        }

    }
}
