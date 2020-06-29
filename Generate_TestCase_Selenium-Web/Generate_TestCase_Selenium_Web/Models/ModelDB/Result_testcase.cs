using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Result_testcase
    {
        public Result_testcase()
        {
            Input_Result_test = new HashSet<Input_Result_test>();
            Test_element_Result_test = new HashSet<Test_element_Result_test>();
        }

        [Key]
        [StringLength(100)]
        public string id_result { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        public int id_url { get; set; }
        [StringLength(50)]
        public string Result { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TestDate { get; set; }
        public string Log_message { get; set; }

        [ForeignKey("id_testcase,id_url")]
        [InverseProperty(nameof(Test_case.Result_testcase))]
        public virtual Test_case id_ { get; set; }
        [ForeignKey(nameof(id_result))]
        [InverseProperty(nameof(Running_process.Result_testcase))]
        public virtual Running_process id_resultNavigation { get; set; }
        [InverseProperty("id_Navigation")]
        public virtual ICollection<Input_Result_test> Input_Result_test { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Test_element_Result_test> Test_element_Result_test { get; set; }
    }
}
