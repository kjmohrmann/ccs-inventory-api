using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Employees;
using API.Models.Interfaces.Employees;
using API.Models.MyCart;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeeController : ControllerBase
    {
        // GET: api/employee
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Employee> Get()
        {
            //Gets all employees
            IGetAllEmployees readObject = new ReadEmployeeData();
            return readObject.GetAllEmployees();
        }

        // // GET: api/employee/5
        // [EnableCors("AnotherPolicy")]
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST: api/employee
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public Cart Post([FromBody] int id)
        {
            ReadCart readObject = new ReadCart();
            return readObject.GetCart(id);
        }

        // PUT: api/employee/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
