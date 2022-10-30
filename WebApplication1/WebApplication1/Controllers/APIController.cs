using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.DTO;
using WebApplication1.DAO;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    
    public class APIController : ApiController
    {
        private DAO.ImpEmployee imp;
        private Model1 db = new Model1();
        //[Route("api/[controller]")]
        // GET api/<controller>
        //public async Task<IHttpActionResult> GetEmp()
        public IEnumerable<Employee> GetAllEmp()
        {
            var emp = from e in db.Employees
                      join d in db.Departments
                      on e.DepartmentId equals d.Id
                      select e;

            return emp.ToList();
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}