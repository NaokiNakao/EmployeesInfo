using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class EmployeeModel
    {
        [Display(Name = "ID")]
        [Required(ErrorMessage = "The ID cannot be empty.")]
        [Range(100000, 999999, ErrorMessage = "Invalid range for ID.")]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "The First Name cannot be empty.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "The Last Name cannot be empty.")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "The Email Address cannot be empty.")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Location")]
        [Required(ErrorMessage = "The Location cannot be empty.")]
        public string Location { get; set; }
    }
}