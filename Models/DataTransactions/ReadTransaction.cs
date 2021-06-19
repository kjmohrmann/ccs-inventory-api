using System;
using System.Collections.Generic;
using API.Models.Interfaces.Transactions;
using MySql.Data.MySqlClient;

namespace API.Models.DataTransactions
{
    public class ReadTransaction: IGetAllTransactions, IGetTransaction
    {
        public List<Transaction> GetAllTransactions()
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //joins the transaction with the item and employee tables
            string stm = "SELECT * FROM transaction t INNER JOIN inventory i ON t.invID = i.invID INNER JOIN employees e ON t.empID = e.employeeID";
            using var cmd = new MySqlCommand(stm,con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Transaction> myTransactions = new List<Transaction>();
            while(rdr.Read())
            {
                //creates the list from the database
                myTransactions.Add(new Transaction(){transactionID = rdr.GetInt32(0), invID = rdr.GetInt32(1), empID = rdr.GetInt32(2), dateRented = rdr.GetString(3), dateDue = rdr.GetString(4), dateReturned = rdr.GetString(5), invTitle = rdr.GetString(7), condition = rdr.GetString(8), imgID = rdr.GetString(10), empName = rdr.GetString(13)});    
            }

            return myTransactions;
        }
   

        public Transaction GetTransactions(int invID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            //Gets a specific transaction
            con.Open();
            string stm = "SELECT * FROM transaction WHERE invID = @invID";
            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@invID", invID);
            cmd.Prepare();
            using MySqlDataReader rdr = cmd.ExecuteReader();

            rdr.Read();
            return new Transaction(){transactionID = rdr.GetInt32(0), invID = rdr.GetInt32(1), empID = rdr.GetInt32(2), dateRented = rdr.GetString(4), dateDue = rdr.GetString(5)};
            
        }

    }
}