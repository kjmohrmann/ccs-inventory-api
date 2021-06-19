using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.Interfaces;
using API.Models.Interfaces.Inventory;
using API.Models.Inventory;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class inventoryController : ControllerBase
    {
        // GET: api/inventory
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Item> GetItem()
        {
            //Gets all items from inventory
            IGetAllItems readObject = new ReadItemData();
            return readObject.GetAllItems();
        }

        //GET: api/inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpGet("{id}", Name = "GetItem")]
        public Item Get(int id)
        {
            //Gets one item
            IGetItem readObject = new ReadItemData();
            return readObject.GetItem(id);
        }

        // POST: api/inventory
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void PostItem([FromBody] Item value)
        {
            //Adds a new item
            IAddItem insertObject = new AddItem();
            insertObject.AddNewItem(value);
        }

        // PUT: api/inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpPut("{id}")]
        // [HttpPut]
        public void UpdateItemCondition(int invID, [FromBody] tempItem myItem)
        {
            //Updates item condition
            IUpdateItem updateObject = new UpdateItem();
            updateObject.UpdateItemCondition(myItem.invID, myItem.condition);
        }

        // DELETE: api/inventory/postText
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void DeleteItem(int id)
        {
            //Deletes item
            IDelete deleteObject = new DeleteItem();
            deleteObject.Delete(id);
        }
    }
}
