using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Button_tag
    {
        [Key]
        [StringLength(50)]
        public string id_button { get; set; }
        [Required]
        [StringLength(10)]
        public string type { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string value { get; set; }
        [StringLength(50)]
        public string id_form { get; set; }
        [Key]
        public int id_url { get; set; }
        public string xpath { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Button_tag))]
        public virtual Url id_urlNavigation { get; set; }
    }
}
