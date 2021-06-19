using System.Collections.Generic;
using API.Models.Employees;

namespace API.Models.Interfaces.Employees
{
    public interface IGetAllEmployees
    {
         List<Employee> GetAllEmployees();
    }
}