using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Running_process
    {
        public Running_process()
        {
            Result_AlertMessage = new HashSet<Result_AlertMessage>();
            Result_Url = new HashSet<Result_Url>();
            Result_testcase = new HashSet<Result_testcase>();
        }

        [Key]
        [StringLength(100)]
        public string id_process { get; set; }
        [StringLength(100)]
        public string id_schedule { get; set; }
        [StringLength(450)]
        public string id_user { get; set; }
        [StringLength(10)]
        public string status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? start_time { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? end_time { get; set; }
        [StringLength(200)]
        public string message { get; set; }

        [ForeignKey(nameof(id_schedule))]
        [InverseProperty(nameof(Test_schedule.Running_process))]
        public virtual Test_schedule id_scheduleNavigation { get; set; }
        [ForeignKey(nameof(id_user))]
        [InverseProperty(nameof(AspNetUsers.Running_process))]
        public virtual AspNetUsers id_userNavigation { get; set; }
        [InverseProperty("id_resultNavigation")]
        public virtual ICollection<Result_AlertMessage> Result_AlertMessage { get; set; }
        [InverseProperty("id_resultNavigation")]
        public virtual ICollection<Result_Url> Result_Url { get; set; }
        [InverseProperty("id_resultNavigation")]
        public virtual ICollection<Result_testcase> Result_testcase { get; set; }
    }
}
