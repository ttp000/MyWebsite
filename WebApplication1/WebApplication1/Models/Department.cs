using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public virtual ICollection<Employee> Employees { get; set; }
    }
}