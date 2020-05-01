using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Test_case
    {
        public Test_case()
        {
            Element_test = new HashSet<Element_test>();
            Input_testcase = new HashSet<Input_testcase>();
        }

        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        public int id_url { get; set; }
        [StringLength(200)]
        public string description { get; set; }
        [StringLength(50)]
        public string result { get; set; }
        public bool? is_test { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Test_case))]
        public virtual Url id_urlNavigation { get; set; }
        [InverseProperty("id_")]
        public virtual Redirect_url Redirect_url { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Element_test> Element_test { get; set; }
        [InverseProperty("id_Navigation")]
        public virtual ICollection<Input_testcase> Input_testcase { get; set; }
    }
}
