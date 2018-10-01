using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SM09.Common.Entities;
using SM09.Common.Interface;
using SM09.DataAccess.Repositories;

namespace SM09.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager manager;

        public ProductController(IProductManager manager)
        {
            this.manager = manager;
        }
        
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return manager.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public Product Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Category
        [HttpPost]
        public void Post(Product product)
        {
            manager.Create(product);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(Product product)
        {
            manager.Update(product);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Product product)
        {
            manager.Delete(product);
        }
    }
}
