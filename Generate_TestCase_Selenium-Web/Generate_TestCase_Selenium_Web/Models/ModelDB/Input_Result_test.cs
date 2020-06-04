using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Input_Result_test
    {
        [Key]
        [StringLength(100)]
        public string id_result { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        [StringLength(100)]
        public string id_element { get; set; }
        public int? id_url { get; set; }
        public string value { get; set; }
        [StringLength(50)]
        public string action { get; set; }
        public int? step { get; set; }

        [ForeignKey("id_element,id_url")]
        [InverseProperty(nameof(Element.Input_Result_test))]
        public virtual Element id_ { get; set; }
        [ForeignKey("id_result,id_testcase")]
        [InverseProperty(nameof(Result_testcase.Input_Result_test))]
        public virtual Result_testcase id_Navigation { get; set; }
    }
}
