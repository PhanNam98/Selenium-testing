using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Project
    {
        public Project()
        {
            Url = new HashSet<Url>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(450)]
        public string Id_User { get; set; }
        [Required]
        [StringLength(450)]
        public string name { get; set; }
        [StringLength(450)]
        public string description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [ForeignKey(nameof(Id_User))]
        [InverseProperty(nameof(AspNetUsers.Project))]
        public virtual AspNetUsers Id_UserNavigation { get; set; }
        [InverseProperty("project_")]
        public virtual ICollection<Url> Url { get; set; }
    }
}
