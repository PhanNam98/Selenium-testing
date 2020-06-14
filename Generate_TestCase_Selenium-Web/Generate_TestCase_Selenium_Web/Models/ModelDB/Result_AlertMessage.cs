using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Result_AlertMessage
    {
        [Key]
        [StringLength(100)]
        public string id_result { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        public string message { get; set; }
        public string test_message { get; set; }

        [ForeignKey(nameof(id_result))]
        [InverseProperty(nameof(Running_process.Result_AlertMessage))]
        public virtual Running_process id_resultNavigation { get; set; }
    }
}
