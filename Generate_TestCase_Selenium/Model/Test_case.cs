//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test_case
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test_case()
        {
            this.Element_test = new HashSet<Element_test>();
            this.Input_testcase = new HashSet<Input_testcase>();
        }
    
        public string id_testcase { get; set; }
        public int id_url { get; set; }
        public string description { get; set; }
        public string result { get; set; }
        public Nullable<bool> is_test { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Element_test> Element_test { get; set; }
        public virtual Redirect_url Redirect_url { get; set; }
        public virtual Url Url { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Input_testcase> Input_testcase { get; set; }
    }
}
