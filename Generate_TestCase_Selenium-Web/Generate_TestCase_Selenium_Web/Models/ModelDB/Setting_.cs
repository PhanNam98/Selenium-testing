using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Setting_
    {
        [Key]
        public string Id_User { get; set; }
        [StringLength(20)]
        public string Browser { get; set; }
        public bool? SendResultToMail { get; set; }

        [InverseProperty("IdNavigation")]
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
