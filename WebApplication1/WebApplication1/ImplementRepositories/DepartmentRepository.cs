using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.Repositories;
namespace WebApplication1.ImplementRepositories
{
    public class DepartmentRepository : IDepartmentRepository, IDisposable
    {
        private readonly Model1 db;

        public DepartmentRepository()
        {
            this.db = new Model1();
        }

        public IEnumerable<Department> GetAllDepartment()
        {
            var department = from d in db.Departments
                             select d;

            return department.ToList();
        }
        public Department GetDepartmentById(string id)
        {

            var department = from d in db.Departments
                             where d.Id == id
                             select d;

            return department.FirstOrDefault();
        }
        public Department GetDepartmentByName(string name)
        {

            var department = from d in db.Departments
                             where d.Name == name
                             select d;

            return department.FirstOrDefault();
        }
        public void CreateDepartment(Department department)
        {
            db.Departments.Add(department);
        }
        public void UpdateDepartment(Department department)
        {
            db.Entry(department).State = EntityState.Modified;
        }
        public void DeleteDepartment(string id)
        {
            var department = from d in db.Departments
                             where d.Id == id
                             select d;

            db.Departments.Remove(department.SingleOrDefault());
        }
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
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