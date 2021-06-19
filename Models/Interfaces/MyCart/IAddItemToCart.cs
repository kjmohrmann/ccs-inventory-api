namespace API.Models.Interfaces.MyCart
{
    public interface IAddItemToCart
    {
        void AddNewItemToCart(int invID, int empID);
    }
}