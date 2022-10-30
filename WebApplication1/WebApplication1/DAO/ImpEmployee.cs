using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.DAO
{
    public class ImpEmployee:IEmployee
    {
        private Model1 db = new Model1();
        public IEnumerable<Employee> getAllEmp()
        {
            var emp = from e in db.Employees
                      join d in db.Departments
                      on e.DepartmentId equals d.Id
                      select e;

            return emp.ToList();
            //return Json(new { Data = JsonConvert.SerializeObject(emp) },JsonRequestBehavior.AllowGet);
        }
    }
}