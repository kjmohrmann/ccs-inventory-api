using System.Collections.Generic;
using API.Models.DataTransactions;

namespace API.Models.Interfaces.Transactions
{
    public interface IGetAllTransactions
    {
        List<Transaction> GetAllTransactions();
    }
}