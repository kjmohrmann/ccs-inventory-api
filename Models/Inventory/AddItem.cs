using API.Models.Interfaces.Inventory;
using MySql.Data.MySqlClient;

namespace API.Models.Inventory
{
    public class AddItem : IAddItem
    {
        public void AddNewItem(Item myItem)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "select SQLite_Version()";
            using var cmd = new MySqlCommand(stm,con);
            //Adds the item to the database
            cmd.CommandText = @"INSERT INTO inventory(invTitle, invCondition, price, imgID, ischeckedout) VALUES(@invTitle, @condition, @price, @imgID, @ischeckedout)";
            cmd.Parameters.AddWithValue("@invTitle", myItem.invTitle);
            cmd.Parameters.AddWithValue("@price", myItem.price);
            cmd.Parameters.AddWithValue("@condition", myItem.condition);
            cmd.Parameters.AddWithValue("@ischeckedout", "No");
            cmd.Parameters.AddWithValue("@imgID", myItem.imgID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}