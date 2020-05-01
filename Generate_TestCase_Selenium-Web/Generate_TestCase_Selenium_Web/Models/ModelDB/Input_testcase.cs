using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Input_testcase
    {
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        [StringLength(100)]
        public string id_element { get; set; }
        [Key]
        public int id_url { get; set; }
        public int test_step { get; set; }
        public string xpath { get; set; }
        public string value { get; set; }
        [StringLength(50)]
        public string action { get; set; }

        [ForeignKey("id_element,id_url")]
        [InverseProperty(nameof(Element.Input_testcase))]
        public virtual Element id_ { get; set; }
        [ForeignKey("id_testcase,id_url")]
        [InverseProperty(nameof(Test_case.Input_testcase))]
        public virtual Test_case id_Navigation { get; set; }
    }
}
