using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Select_tag
    {
        [Key]
        [StringLength(50)]
        public string id_select { get; set; }
        [StringLength(50)]
        public string id_form { get; set; }
        [Key]
        public int id_url { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        public string xpath { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Select_tag))]
        public virtual Url id_urlNavigation { get; set; }
    }
}
