using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
    public class TestElementDAL
    {
        public TestElementDAL ()
        {

        }
        public bool insert_TestElement(Element_test newElement)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Element_test.Add(newElement);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool Update_TestElement(Element_test newElement)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Element_test.Attach(newElement);
                    db.Entry(newElement).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool Delete_TestElement(Element_test oldElement)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Element_test.Attach(oldElement);
                    db.Element_test.Remove(oldElement);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public List<Element_test> get_ElementTest_ByIdTestcase(string id_testcase, int id_url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    return db.Element_test.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).ToList();

                }
            }
            catch { }
            return null;
        }
        public bool update_ValueResult_Testcase(int id_url, string id_testcase, string valueresult)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {

                    var testcase = db.Element_test.Where(p => p.id_url == id_url && p.id_testcase == id_testcase).SingleOrDefault();
                    testcase.value_return = valueresult;
                    db.Element_test.Attach(testcase);
                    db.Entry(testcase).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {

            }
            return false;
        }
    }
}
