using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Element
    {
        public Element()
        {
            Input_testcase = new HashSet<Input_testcase>();
        }

        [Key]
        [StringLength(100)]
        public string id_element { get; set; }
        [Key]
        public int id_url { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        [StringLength(100)]
        public string class_name { get; set; }
        [Required]
        [StringLength(20)]
        public string tag_name { get; set; }
        [StringLength(20)]
        public string type { get; set; }
        public string value { get; set; }
        public string href { get; set; }
        [StringLength(1000)]
        public string title { get; set; }
        [StringLength(100)]
        public string id_form { get; set; }
        public double? minlength { get; set; }
        public double? maxlength { get; set; }
        public bool? required { get; set; }
        public bool? read_only { get; set; }
        [StringLength(100)]
        public string max_value { get; set; }
        [StringLength(100)]
        public string min_value { get; set; }
        public bool? multiple { get; set; }
        [Required]
        public string xpath { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Element))]
        public virtual Url id_urlNavigation { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Input_testcase> Input_testcase { get; set; }
    }
}
