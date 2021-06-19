using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class DeleteItem : IDelete
    {
        public void Delete(int invID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "select SQLite_Version()";
            using var cmd = new MySqlCommand(stm,con);
            //Deletes the item from the database
            cmd.CommandText = @"DELETE FROM inventory WHERE invID = @invID";
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}