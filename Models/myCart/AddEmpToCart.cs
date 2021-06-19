using API.Models.Interfaces.MyCart;
using MySql.Data.MySqlClient;

namespace API.Models.MyCart
{
    public class AddEmpToCart : IAddEmpToCart
    {
        public void AddEmployeeToCart(int empID)
        {
            
            System.Console.WriteLine("Start database");
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //Cart table is created each time someone logs in 
            string stm= "DROP TABLE IF EXISTS cart";
            using var cmd = new MySqlCommand(stm,con);
            cmd.ExecuteNonQuery();

            //Creates the cart table
            cmd.CommandText = @"CREATE TABLE cart(cartID INT NOT NULL AUTO_INCREMENT, empID INT NULL, invID INT NULL, PRIMARY KEY (cartID));";
            cmd.ExecuteNonQuery();

            //Adds one cart item to save the empID for future additions to the cart
            cmd.CommandText = @"INSERT INTO cart (empID, invID) VALUES(@empID, @invID)";
            cmd.Parameters.AddWithValue("@empID", empID);
            cmd.Parameters.AddWithValue("@invID", 0);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}