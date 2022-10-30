using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;
using WebApplication1.DAL;
using WebApplication1.Repositories;
using System.Data.Entity;

namespace WebApplication1.ImplementRepositories
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        private readonly Model1 db;
        public EmployeeRepository()
        {
            this.db = new Model1();
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            // ADO.Net SQL to SQL
            var employee = from e in db.Employees
                           join d in db.Departments
                           on e.DepartmentId equals d.Id
                           select e;
            return employee.ToList();
        }

        public Employee GetEmployeeById(string id)
        {
            var employee = from e in db.Employees
                           where e.Id == id
                           select e;

            return employee.FirstOrDefault();
        }
        public Employee GetEmployeeByName(string name)
        {
            var employee = from e in db.Employees
                           where e.FName == name
                           select e;

            return employee.FirstOrDefault();
        }
        public void CreateEmployee(Employee employee)
        {
            db.Employees.Add(employee);
        }
        public void DeleteEmployee(string id)
        {
            var employee = from e in db.Employees
                           where e.Id == id
                           select e;
            db.Employees.Remove(employee.SingleOrDefault());
        }
        public void UpdateEmployee(Employee employee)
        {
            db.Entry(employee).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing) {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}