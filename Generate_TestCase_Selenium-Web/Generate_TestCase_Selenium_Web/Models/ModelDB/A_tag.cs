using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class A_tag
    {
        [Key]
        [StringLength(50)]
        public string id_a_tag { get; set; }
        [Required]
        public string href { get; set; }
        [Key]
        public int id_url { get; set; }
        public string title { get; set; }
        public string text_value { get; set; }
        public string xpath { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.A_tag))]
        public virtual Url id_urlNavigation { get; set; }
    }
}
