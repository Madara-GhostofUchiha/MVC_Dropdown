using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace MVC_Dropdown.Models
{
    public class DropdownModel
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Please enter the student name.")]
        public string Name { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please enter the email address.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please select the gender.")]
        public string Gender { get; set; }

        [Display(Name = "Subject")]
        [Required(ErrorMessage = "Please select the subject.")]
        public string Subject { get; set; }
    }
}