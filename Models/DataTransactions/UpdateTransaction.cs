using System;
using API.Models.Interfaces.Transactions;
using MySql.Data.MySqlClient;

namespace API.Models.DataTransactions
{
    public class UpdateTransaction : IUpdateTransaction
    {
        public void UpdateTransactionData(int transactionID)
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = "select MySQL_Version()";
            using var cmd = new MySqlCommand(stm,con);
            string dateReturned = DateTime.Now.ToString("MM/dd/yyyy H:mm");
            //Updates the transaction with the date returned
            cmd.CommandText = @"UPDATE transaction SET dateReturned = @dateReturned WHERE transactionID = @transactionID";
            cmd.Parameters.AddWithValue("@dateReturned", dateReturned);
            cmd.Parameters.AddWithValue("@transactionID", transactionID);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

        }
    }
}