using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium_Web.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() : base() { }

        //public bool IsBlock { get; set; }
        public bool IsAdmin { get; set; }
        //public bool IsDelete { get; set; }
    }
}
