using API.Models.MyCart;

namespace API.Models.Interfaces.Transactions
{
    public interface IAddTransaction
    {
        void AddNewTransaction(Cart myCart);
    }
}