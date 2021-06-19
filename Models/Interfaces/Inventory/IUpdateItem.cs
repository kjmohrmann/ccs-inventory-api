namespace API.Models.Interfaces.Inventory
{
    public interface IUpdateItem
    {
        void UpdateItemCondition(int invID, string condition);
    }
}