using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Redirect_url
    {
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        public int id_url { get; set; }
        [Required]
        public string current_url { get; set; }
        public string redirect_url_test { get; set; }

        [ForeignKey("id_testcase,id_url")]
        [InverseProperty(nameof(Test_case.Redirect_url))]
        public virtual Test_case id_ { get; set; }
    }
}
