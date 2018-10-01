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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager manager;

        public CategoryController(ICategoryManager manager)
        {
            this.manager = manager;
        }
        
        // GET: api/Category
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return manager.GetAll();
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public Category Get(int id)
        {
            return manager.Get(id);
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] string value)
        {
            throw new NotImplementedException();
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
