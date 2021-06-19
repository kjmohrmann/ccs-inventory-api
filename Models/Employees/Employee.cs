namespace API.Models.Employees
{
    public class Employee
    {

        public string EmpName {get; set;}
        public int EmpID {get; set;}
        public string EmpEmail {get; set;}
        public string EmpPassword {get; set;}
        public string isAdmin {get; set;}

        public Employee()
        {

        }
    }
}