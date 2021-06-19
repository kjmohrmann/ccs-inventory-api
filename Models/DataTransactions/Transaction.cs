using System;

namespace API.Models.DataTransactions
{
    public class Transaction
    {
        public int transactionID {get; set;}
        public int invID {get; set;}
        public int empID {get; set;}
        public string dateRented {get; set;}
        public string dateDue {get; set;}
        public string dateReturned {get; set;}
        public string invTitle {get; set;}
        public string condition {get; set;}
        public string imgID {get; set;}
        public string empName {get; set;}


        public Transaction()
        {
        }
    }
}