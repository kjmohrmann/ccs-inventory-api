using System.Collections.Generic;
using API.Models.Interfaces.MyCart;
using MySql.Data.MySqlClient;

namespace API.Models.MyCart
{
    public class ReadCart : IGetAllCart, IGetCart
    {
        public List<Cart> GetAllCart()
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //Gets all items from the cart as well as the things that go with the item
            string stm = "SELECT * FROM cart c INNER JOIN inventory i ON c.invID = i.invID";
            using var cmd = new MySqlCommand(stm,con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Cart> myCart = new List<Cart>();
            while(rdr.Read())
            {
                //creates the list from the database
                myCart.Add(new Cart(){cartID = rdr.GetInt32(0), empID = rdr.GetInt32(1), invID = rdr.GetInt32(2), invTitle = rdr.GetString(4), condition = rdr.GetString(5), price = rdr.GetInt32(6), imgID = rdr.GetString(7), ischeckedout = rdr.GetString(8)}); 
            }
            return myCart;
        }

        public Cart GetCart(int invID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            //Gets a specific emp
            con.Open();
            string stm = "SELECT * FROM cart WHERE invID = @invID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            return new Cart(){cartID = rdr.GetInt32(0), empID = rdr.GetInt32(1)};
            
        }
    }
}