using System.Collections.Generic;
using API.Models.Interfaces;
using MySql.Data.MySqlClient;

namespace API.Models
{
    public class ReadItemData : IGetAllItems, IGetItem
    {
        public List<Item> GetAllItems()
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //gets all items sorted by name
            string stm = "SELECT * FROM inventory ORDER BY invTitle ASC;";
            using var cmd = new MySqlCommand(stm,con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Item> myItems = new List<Item>();
            while(rdr.Read())
            {
                //creates the list from the database
                myItems.Add(new Item(){invID = rdr.GetInt32(0), invTitle = rdr.GetString(1), condition = rdr.GetString(2), price = rdr.GetInt32(3), imgID = rdr.GetString(4), ischeckedout = rdr.GetString(5)});    
            }

    
            return myItems;
        }

        public Item GetItem(int invID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            //Gets a specific item
            con.Open();
            string stm = "SELECT * FROM inventory WHERE invID = @invID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Item(){invID = rdr.GetInt32(0), invTitle = rdr.GetString(1), condition = rdr.GetString(2), price = rdr.GetDouble(3), imgID = rdr.GetString(4), ischeckedout = rdr.GetString(5)};
            
        }
    }
}