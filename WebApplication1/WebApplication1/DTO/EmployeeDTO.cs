using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.DTO
{
    public class EmployeeDTO
    {
        public string Id { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }
     
        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int Salary { get; set; }

        // Foreign Key
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}