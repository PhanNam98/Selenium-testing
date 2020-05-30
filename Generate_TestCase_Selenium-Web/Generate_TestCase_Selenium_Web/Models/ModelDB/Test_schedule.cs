using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Test_schedule
    {
        public Test_schedule()
        {
            Running_process = new HashSet<Running_process>();
            Testcase_scheduled = new HashSet<Testcase_scheduled>();
        }

        [Key]
        [StringLength(100)]
        public string id_schedule { get; set; }
        [Required]
        [StringLength(450)]
        public string id_user { get; set; }
        [Required]
        [StringLength(10)]
        public string status { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [StringLength(100)]
        public string job_repeat_time { get; set; }

        [InverseProperty("id_scheduleNavigation")]
        public virtual ICollection<Running_process> Running_process { get; set; }
        [InverseProperty("id_scheduleNavigation")]
        public virtual ICollection<Testcase_scheduled> Testcase_scheduled { get; set; }
    }
}
