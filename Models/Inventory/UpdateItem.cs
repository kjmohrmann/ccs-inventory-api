using API.Models.Interfaces.Inventory;
using MySql.Data.MySqlClient;

namespace API.Models.Inventory
{
    public class UpdateItem : IUpdateItem
    {
        public void UpdateItemCondition(int invID, string condition)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "select MySQL_Version()";
            using var cmd = new MySqlCommand(stm,con);
            //Updates the item condition and availability in the database

            cmd.CommandText = @"UPDATE inventory SET ischeckedout = @checkedOut WHERE invID = @invID";
            string checkedOut = "No";
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Parameters.AddWithValue("@checkedOut", checkedOut);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"UPDATE inventory SET invCondition = @condition WHERE invID = @invID";
            cmd.Parameters.AddWithValue("@condition", condition);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            System.Console.WriteLine("Updated Item condition @ ischeckedout");
        }
        
    }
}