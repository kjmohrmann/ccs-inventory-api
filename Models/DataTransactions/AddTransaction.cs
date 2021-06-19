using System;
using API.Models.Interfaces.Transactions;
using API.Models.MyCart;
using MySql.Data.MySqlClient;

namespace API.Models.DataTransactions
{
    public class AddTransaction : IAddTransaction
    {
        public void AddNewTransaction(Cart myCart)
        {

            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            //creates the datetime
            string dateRented = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            //creates the datedue 
            DateTime dueDate = DateTime.Now.AddDays(30);
            string dateDue = dueDate.ToString("MM/dd/yyyy H:mm");
            string dateRetured = "01/01/1800 0:01";

            con.Open();
            //Adds the transaction to the database
            string stm = "INSERT INTO transaction(invID, empID, dateRented, dateDue, dateReturned) VALUES(@invID, @empID, @dateRented, @dateDue, @dateReturned)";
            using var cmd = new MySqlCommand(stm,con);
            cmd.Parameters.AddWithValue("@invID", myCart.invID);
            cmd.Parameters.AddWithValue("@empID", myCart.empID);
            cmd.Parameters.AddWithValue("@dateRented", dateRented);
            cmd.Parameters.AddWithValue("@dateDue", dateDue);
             cmd.Parameters.AddWithValue("@dateReturned", dateRetured);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            //Updates the inventory database to say that item is checked out
            cmd.CommandText = @"UPDATE inventory SET ischeckedout = @checkedOut WHERE invID = @invID";
            string checkedOut = "Yes";
            cmd.Parameters.AddWithValue("@checkedOut", checkedOut);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}