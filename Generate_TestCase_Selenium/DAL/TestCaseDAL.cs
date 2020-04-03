﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class TestCaseDAL
    {
        public TestCaseDAL() { }
        public TestCaseDAL(int id_url) { }

        public bool insert_Testcase(Test_case newTestcase)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Test_case.Add(newTestcase);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }

    }
}
