using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IEmployeeRepository: IDisposable
    {
        IEnumerable<Employee> GetAllEmployee();
        Employee GetEmployeeById(string id);
        Employee GetEmployeeByName(string name);

        void CreateEmployee(Employee employee);
        void DeleteEmployee(string id);
        void UpdateEmployee(Employee employee);
        void Save();
    }
}
