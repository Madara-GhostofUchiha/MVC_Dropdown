using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Dropdown.Models
{
    //[Table("tbl_user")]
    public class Employee
    {
        public int EmployeeId { get; set; }       
        public string Name { get; set; }    
        public string Email { get; set; }
        public string Username  { get; set;}
        public string Password { get; set;} 
    }
}