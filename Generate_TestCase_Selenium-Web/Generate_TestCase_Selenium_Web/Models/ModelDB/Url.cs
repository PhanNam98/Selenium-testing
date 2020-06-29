using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Url
    {
        public Url()
        {
            A_tag = new HashSet<A_tag>();
            Button_tag = new HashSet<Button_tag>();
            Element = new HashSet<Element>();
            Form_elements = new HashSet<Form_elements>();
            Input_elements = new HashSet<Input_elements>();
            Select_tag = new HashSet<Select_tag>();
            Test_case = new HashSet<Test_case>();
        }

        [Key]
        public int id_url { get; set; }
        [Required]
        [StringLength(50)]
        public string name { get; set; }
        [Required]
        [Column("url")]
        public string url1 { get; set; }
        public int project_id { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
        public bool? IsChange { get; set; }
        public string trigger_element { get; set; }

        [ForeignKey(nameof(project_id))]
        [InverseProperty(nameof(Project.Url))]
        public virtual Project project_ { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<A_tag> A_tag { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<Button_tag> Button_tag { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<Element> Element { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<Form_elements> Form_elements { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<Input_elements> Input_elements { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<Select_tag> Select_tag { get; set; }
        [InverseProperty("id_urlNavigation")]
        public virtual ICollection<Test_case> Test_case { get; set; }
    }
}
