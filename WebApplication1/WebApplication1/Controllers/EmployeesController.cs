using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.DTO;
using WebApplication1.Repositories;
using WebApplication1.ImplementRepositories;

namespace WebApplication1.Controllers
{
    public class EmployeesController : Controller
    {

        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController() : this(new EmployeeRepository())
        {
        }

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employee = this.employeeRepository.GetAllEmployee();

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        //GET: Employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult GetEmployeeByName(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeByName(name);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        // GET: Employees/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FName,LName,DateOfBirth,Address,City,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.CreateEmployee(employee);
                employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FName,LName,DateOfBirth,Address,City,Salary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeRepository.UpdateEmployee(employee);
                employeeRepository.Save();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = employeeRepository.GetEmployeeById(id);
            employeeRepository.DeleteEmployee(id);
            employeeRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            employeeRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
