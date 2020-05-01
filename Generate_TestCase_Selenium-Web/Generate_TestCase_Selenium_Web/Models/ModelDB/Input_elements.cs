using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Input_elements
    {
        [Key]
        [StringLength(50)]
        public string id_input { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(50)]
        public string class_name { get; set; }
        [Required]
        [StringLength(50)]
        public string type { get; set; }
        [StringLength(50)]
        public string value { get; set; }
        [Required]
        [StringLength(50)]
        public string id_form { get; set; }
        public int? minlength { get; set; }
        public int? maxlength { get; set; }
        public bool? required { get; set; }
        [Column("readonly")]
        public bool? _readonly { get; set; }
        public float? max { get; set; }
        public float? min { get; set; }
        public bool? multiple { get; set; }
        public string xpath { get; set; }
        [Key]
        public int id_url { get; set; }

        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Input_elements))]
        public virtual Url id_urlNavigation { get; set; }
    }
}
