using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
namespace WebApplication1.Controllers
{
    public class DefaultController : Controller
    {
        private Model1 db = new Model1();

        // GET: Default
        public ActionResult Index()
        {
            // ADO.Net 
            var emp = from e in db.Employees
                      join d in db.Departments
                      on e.DepartmentId equals d.Id
                      select e;

            return View(emp.ToList());
        }
    }
}