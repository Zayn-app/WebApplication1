﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Full name is required")]
        public string FirstName { get; set; }


        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Full name is required")]
        public string LastName { get; set; }


        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
