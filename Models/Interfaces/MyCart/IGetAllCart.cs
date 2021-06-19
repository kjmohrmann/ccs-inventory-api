using System.Collections.Generic;
using API.Models.MyCart;

namespace API.Models.Interfaces.MyCart
{
    public interface IGetAllCart
    {
        List<Cart> GetAllCart();
    }
}