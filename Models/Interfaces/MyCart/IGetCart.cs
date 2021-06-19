using API.Models.MyCart;

namespace API.Models.Interfaces.MyCart
{
    public interface IGetCart
    {
        Cart GetCart(int invID);
    }
}