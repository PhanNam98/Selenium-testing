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
    
    public partial class Redirect_url
    {
        public string id_testcase { get; set; }
        public int id_url { get; set; }
        public string current_url { get; set; }
        public string redirect_url_test { get; set; }
    
        public virtual Test_case Test_case { get; set; }
    }
}
