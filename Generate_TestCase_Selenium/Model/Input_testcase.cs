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
    
    public partial class Input_testcase
    {
        public string id_testcase { get; set; }
        public string id_element { get; set; }
        public int id_url { get; set; }
        public string xpath { get; set; }
        public string value { get; set; }
        public string action { get; set; }
    
        public virtual Element Element { get; set; }
        public virtual Test_case Test_case { get; set; }
    }
}