using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Result_Url
    {
        [Key]
        [StringLength(100)]
        public string id_result { get; set; }
        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        public string test_url { get; set; }
        public string return_url { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TestDate { get; set; }

        [ForeignKey(nameof(id_result))]
        [InverseProperty(nameof(Running_process.Result_Url))]
        public virtual Running_process id_resultNavigation { get; set; }
    }
}
