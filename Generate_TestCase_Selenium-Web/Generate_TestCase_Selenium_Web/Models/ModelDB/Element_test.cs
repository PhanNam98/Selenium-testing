using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Element_test
    {
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        public int id_url { get; set; }
        [Key]
        [StringLength(100)]
        public string id_element { get; set; }
        [Required]
        [StringLength(50)]
        public string xpath { get; set; }
        public string xpath_full { get; set; }
        public string value_return { get; set; }
        public string value_test { get; set; }
        [StringLength(50)]
        public string class_name { get; set; }

        [ForeignKey("id_testcase,id_url")]
        [InverseProperty(nameof(Test_case.Element_test))]
        public virtual Test_case id_ { get; set; }
    }
}
