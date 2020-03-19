using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generate_TestCase_Selenium.Models
{
    public class Form_element
    {
        public string name { get; set; }
        public string class_name { get; set; }
        public ObjectId _id { get; set; }
        public string element_id { get; set; }
        public string url_id { get; set; }
        public int __v { get; set; }
    }
}
