using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Models.MyCart;
using API.Models.DataTransactions;
using API.Models.Interfaces.Transactions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ccs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class transactionController : ControllerBase
    {
        // GET: api/transaction
        [EnableCors("AnotherPolicy")]
        [HttpGet]
        public List<Transaction> Get()
        {
            //Gets all transactions
            IGetAllTransactions readObject = new ReadTransaction();
            return readObject.GetAllTransactions();
        }

        // // GET: api/transaction/5
        // [EnableCors("AnotherPolicy")]
        // [HttpGet("{id}", Name = "Get")]
        // public Transaction Get(int id)
        // {
        //     IGetTransaction readObject = new ReadTransaction();
        //     return readObject.GetTransactions(id);
        // }

        // ADD: api/transaction
        [EnableCors("AnotherPolicy")]
        [HttpPost]
        public void Post([FromBody] Cart myCart )
        {
            //Adds a new transaction
            IAddTransaction insertObject = new AddTransaction();
            insertObject.AddNewTransaction(myCart);
        }

        // UPDATE: api/inventory/5
        [EnableCors("AnotherPolicy")]
        [HttpPut]
        // [HttpPut]
        public void Put([FromBody] int transactionID)
        {
            //Updates transaction with return date
            IUpdateTransaction updateObject = new UpdateTransaction();
            updateObject.UpdateTransactionData(transactionID);
            
        }


        // DELETE: api/ApiWithActions/5
        [EnableCors("AnotherPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
