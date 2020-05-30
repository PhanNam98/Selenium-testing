using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Test_element_Result_test
    {
        [Key]
        [StringLength(100)]
        public string id_test_elements { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        [StringLength(100)]
        public string id_result { get; set; }
        public string xpath { get; set; }
        public string value { get; set; }
        public string value_test { get; set; }

        [ForeignKey("id_result,id_testcase")]
        [InverseProperty(nameof(Result_testcase.Test_element_Result_test))]
        public virtual Result_testcase id_ { get; set; }
    }
}
