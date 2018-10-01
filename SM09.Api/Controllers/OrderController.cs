using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM09.Common.DTO;
using SM09.Common.Entities;
using SM09.Common.Interface;
using SM09.DataAccess.Repositories;

namespace SM09.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager manager;

        public OrderController(IOrderManager manager)
        {
            this.manager = manager;
        }
        
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return manager.GetAll();
        }

        [HttpGet("/api/PrintInvoice")]
        public DTOOrder PrintInvoice(int Id) {
            return manager.PrintInvoice(Id);
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public Order Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Category
        [HttpPost]
        public void Post(Order order)
        {
            manager.Create(order);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
