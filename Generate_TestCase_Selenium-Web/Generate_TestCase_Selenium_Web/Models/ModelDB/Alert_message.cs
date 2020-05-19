using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Alert_message
    {
        [Key]
        [StringLength(10)]
        public string id_alert { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        public int id_url { get; set; }
        public string message { get; set; }

        [ForeignKey("id_testcase,id_url")]
        [InverseProperty(nameof(Test_case.Alert_message))]
        public virtual Test_case id_ { get; set; }
    }
}
