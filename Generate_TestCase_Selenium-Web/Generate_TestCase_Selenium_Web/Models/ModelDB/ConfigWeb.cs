using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class ConfigWeb
    {
        [Key]
        public int id { get; set; }
        public int number_of_urls_per_user { get; set; }
        public int number_of_test_cases_running_concurrently { get; set; }
    }
}
