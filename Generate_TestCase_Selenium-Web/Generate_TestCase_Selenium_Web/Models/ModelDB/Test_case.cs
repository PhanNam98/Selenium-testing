﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Generate_TestCase_Selenium_Web.Models.ModelDB
{
    public partial class Test_case
    {
        public Test_case()
        {
            Alert_message = new HashSet<Alert_message>();
            Element_test = new HashSet<Element_test>();
            Input_testcase = new HashSet<Input_testcase>();
            Inverseid_prerequisite_ = new HashSet<Test_case>();
            Result_testcase = new HashSet<Result_testcase>();
            Testcase_scheduled = new HashSet<Testcase_scheduled>();
        }

        [Key]
        [StringLength(100)]
        public string id_testcase { get; set; }
        [Key]
        public int id_url { get; set; }
        [StringLength(200)]
        public string description { get; set; }
        [StringLength(50)]
        public string result { get; set; }
        public bool? is_test { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }
        [StringLength(100)]
        public string id_prerequisite_testcase { get; set; }
        public int? id_prerequisite_url { get; set; }

        [ForeignKey("id_prerequisite_testcase,id_prerequisite_url")]
        [InverseProperty(nameof(Test_case.Inverseid_prerequisite_))]
        public virtual Test_case id_prerequisite_ { get; set; }
        [ForeignKey(nameof(id_url))]
        [InverseProperty(nameof(Url.Test_case))]
        public virtual Url id_urlNavigation { get; set; }
        [InverseProperty("id_")]
        public virtual Redirect_url Redirect_url { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Alert_message> Alert_message { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Element_test> Element_test { get; set; }
        [InverseProperty("id_Navigation")]
        public virtual ICollection<Input_testcase> Input_testcase { get; set; }
        [InverseProperty(nameof(Test_case.id_prerequisite_))]
        public virtual ICollection<Test_case> Inverseid_prerequisite_ { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Result_testcase> Result_testcase { get; set; }
        [InverseProperty("id_")]
        public virtual ICollection<Testcase_scheduled> Testcase_scheduled { get; set; }
    }
}
