using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using WebApplication1.Models;
namespace WebApplication1.Repositories
{
    public interface IDepartmentRepository : IDisposable
    {
        IEnumerable<Department> GetAllDepartment();
        Department GetDepartmentById(string id);
        Department GetDepartmentByName(string name);

        void CreateDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(string id);
        void Save();
    }
}
