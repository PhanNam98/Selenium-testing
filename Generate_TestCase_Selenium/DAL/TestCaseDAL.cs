using System;
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
        public bool insert_ListTestcase(List<Test_case> newList)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Test_case.AddRange(newList);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
        public List<Test_case> get_ListTestcase(int id_url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                   
                    return db.Test_case.Where(p=>p.id_url==id_url).ToList();
                }
            }
            catch
            {

            }
            return null;
        }
        public string get_ResultTestcase(int id_url,string id_testcase)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {

                    return db.Test_case.Where(p => p.id_url == id_url && p.id_testcase==id_testcase).SingleOrDefault().result.ToString();
                }
            }
            catch
            {

            }
            return "";
        }

    }
}
