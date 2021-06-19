using MySql.Data.MySqlClient;

namespace API.Models.MyCart
{
    public class DeleteItemFromCart
    {
        public void DeleteFromCart(int invID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            System.Console.WriteLine(invID);
            //Removes an item from the cart
            string stm = "DELETE FROM cart WHERE invID = @invID";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            System.Console.WriteLine("item deleted");
        }
    }
}