using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandApp.MVC.Models
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter Full Name")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Must be between 1 and 20 characters", MinimumLength = 1)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(20, ErrorMessage = "Must be between 1 and 20 characters", MinimumLength = 1)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}