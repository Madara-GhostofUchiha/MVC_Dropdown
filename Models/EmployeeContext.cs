using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Dropdown.Models
{
    public class EmployeeContext:DbContext
    {
        public DbSet<Employee> Employeees { get; set; }
    }
}