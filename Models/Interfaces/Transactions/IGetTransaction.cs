using API.Models.DataTransactions;

namespace API.Models.Interfaces.Transactions
{
    public interface IGetTransaction
    {
        Transaction GetTransactions(int id);
    }
}