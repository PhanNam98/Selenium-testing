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

        [ForeignKey(nameof(Id_User))]
        [InverseProperty(nameof(AspNetUsers.Setting_))]
        public virtual AspNetUsers Id_UserNavigation { get; set; }
    }
}
