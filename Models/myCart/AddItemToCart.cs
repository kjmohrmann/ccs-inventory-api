using API.Models.Interfaces.MyCart;
using MySql.Data.MySqlClient;

namespace API.Models.MyCart
{
    public class AddItemToCart : IAddItemToCart
    {
        public void AddNewItemToCart(int invID, int empID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            System.Console.WriteLine(invID);
            //Adds the item to the cart database
            string stm = "INSERT INTO cart (invId, empID) VALUES(@invID, @empID)";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Parameters.AddWithValue("@empID", empID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}