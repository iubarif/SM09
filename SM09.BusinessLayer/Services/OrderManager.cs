using SM09.Common.Core;
using SM09.Common.DTO;
using SM09.Common.Entities;
using SM09.Common.Interface;
using SM09.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace SM09.BusinessLayer.Services
{
    public class OrderManager : IOrderManager
    {
        private readonly IProductDiscountFactory prodDiscountFactory;
        private readonly IInvoiceDiscountManager invoiceDiscountManager;
        private readonly IUnitOfWork unitOfWork;

        public OrderManager(IProductDiscountFactory prodDiscountFactory,
            IInvoiceDiscountManager invoiceDiscountManager,
            IUnitOfWork unitOfWork)
        {
            this.prodDiscountFactory = prodDiscountFactory;
            this.invoiceDiscountManager = invoiceDiscountManager;
            this.unitOfWork = unitOfWork;
        }
        public void Create(Order order)
        {
            if (order.LineItems.Count == 0)
                throw new Exception("Not a valid order. No line items found");

            // Saves Order and Line items
            unitOfWork.Orders.Add(order);
            unitOfWork.SaveChanges();
            
        }

        public void Delete(Order entity)
        {
            throw new NotImplementedException();
        }

        public Order Get(int Id)
        {
            return unitOfWork.Orders.Get(Id);
        }

        public IEnumerable<Order> GetAll()
        {
            return unitOfWork.Orders.GetAll();
        }

        public DTOOrder PrintInvoice(int Id)
        {
            var order = unitOfWork.Orders.Get(Id);

            if (order == null)
                throw new Exception($"Order #{Id} not found.");

            var invoice = new DTOOrder();
            invoice.OrderId = order.Id;
            invoice.OrderDate = order.CreatedOn;

            var orderLines = order.LineItems;

            foreach (var line in orderLines) {
                var prod = line.Product;
                var invoiceLine = new DTOLineItem();

                invoiceLine.Name = prod.Name;
                invoiceLine.TotalUnites = line.Unit;
                invoiceLine.UnitPrice = prod.Price;

                var dicountObject = prod.Discounts
                    .Where(d => d.Active == true && d.ActiveTill <= DateTime.Now)
                    .FirstOrDefault();

                if (dicountObject == null)
                    invoiceLine.Discount = 0;
                else
                    invoiceLine.Discount = prodDiscountFactory
                        .GetProductDiscountObject(dicountObject)
                        .CalculateDiscount(line);

                invoiceLine.LineItemTotal = (line.Unit * prod.Price) - invoiceLine.Discount;
                invoice.LineItems.Add(invoiceLine);
            }

            invoice.TotalWithoutDiscount = invoice.LineItems.Select(l => l.LineItemTotal).Sum();

            var activeDiscount = unitOfWork.InvoiceDiscounts
                .Find(id => id.Active == true && id.ActiveTill <= DateTime.Now)
                .FirstOrDefault();

            if (activeDiscount == null)
            {
                invoice.InvoiceDiscount = 0;
                invoice.Total = invoice.TotalWithoutDiscount;
            }
            else
            {
                invoice.InvoiceDiscount = invoiceDiscountManager
                    .CalculateInvoiceDiscount(invoice.TotalWithoutDiscount, activeDiscount);

                invoice.Total = invoice.TotalWithoutDiscount - invoice.InvoiceDiscount;
            }


            return invoice;
        }

        public void Update(Order entity)
        {
            unitOfWork.Orders.Update(entity);
            unitOfWork.SaveChanges();
        }        
    }
}
