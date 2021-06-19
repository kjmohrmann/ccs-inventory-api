using System.Collections.Generic;
using API.Models.Interfaces.Employees;
using MySql.Data.MySqlClient;

namespace API.Models.Employees
{
    public class ReadEmployeeData : IGetAllEmployees
    {
        public List<Employee> GetAllEmployees()
        {
            ConnectionString mycs = new ConnectionString();
            string cs = mycs.cs;
            using var con = new MySqlConnection(cs);
            con.Open();
            //Gets all employees from the database
            string stm = "SELECT * FROM employees";
            using var cmd = new MySqlCommand(stm,con);
            using MySqlDataReader rdr = cmd.ExecuteReader();
            List<Employee> myEmployees = new List<Employee>();
            while(rdr.Read())
            {
                //creates the list from the database
                myEmployees.Add(new Employee(){EmpID = rdr.GetInt32(0), EmpName = rdr.GetString(1), EmpEmail = rdr.GetString(2), EmpPassword = rdr.GetString(3), isAdmin = rdr.GetString(4)});    
            }
    
            return myEmployees;
        }
    }
}