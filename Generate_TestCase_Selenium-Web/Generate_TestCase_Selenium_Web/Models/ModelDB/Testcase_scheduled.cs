using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Testcase_scheduled
    {
        [Key]
        [StringLength(100)]
        public string id_schedule { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        public int? id_url { get; set; }

        [ForeignKey("id_testcase,id_url")]
        [InverseProperty(nameof(Test_case.Testcase_scheduled))]
        public virtual Test_case id_ { get; set; }
        [ForeignKey(nameof(id_schedule))]
        [InverseProperty(nameof(Test_schedule.Testcase_scheduled))]
        public virtual Test_schedule id_scheduleNavigation { get; set; }
    }
}
