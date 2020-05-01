using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Form_elements
    {
        [Key]
        [StringLength(100)]
        public string id_form { get; set; }
        [StringLength(100)]
        public string name { get; set; }
        [Key]
        public int id_url { get; set; }
        public string xpath { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Form_elements))]
        public virtual Url id_urlNavigation { get; set; }
    }
}
