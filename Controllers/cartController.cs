using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models.MyCart;

namespace ccs_inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class cartController : ControllerBase
    {
        // GET: api/cart
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Cart> Get()
        {
            //Gets all items from cart
            ReadCart readObject = new ReadCart();
            return readObject.GetAllCart();
        }

        //GET: api/cart/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            ReadCart readObject = new ReadCart();
            return readObject.GetCart(id);
        }
        

        // POST: api/cart
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] int empID)
        {
            //Adds an employee id to the cart to track who is renting the item
            AddEmpToCart insertObject = new AddEmpToCart();
            insertObject.AddEmployeeToCart(empID);
        }

        // PUT: api/cart/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        public void Put([FromBody] Cart myCart)
        {
            //Adds item to the cart
            AddItemToCart insertObject = new AddItemToCart();
            insertObject.AddNewItemToCart(myCart.invID, myCart.empID);
        }

        // DELETE: api/cart
        [EnableCors("AnotherPolicy")]
        [HttpDelete]
        public void Delete([FromBody] int id)
        {
            //Removes item from cart
            System.Console.WriteLine("Made it to delete " + id);
            DeleteItemFromCart insertObject = new DeleteItemFromCart();
            insertObject.DeleteFromCart(id);
        }
    }
}