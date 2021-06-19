using System.Collections.Generic;

namespace API.Models.Interfaces
{
    public interface IGetAllItems
    {
        List<Item> GetAllItems();
    }
}