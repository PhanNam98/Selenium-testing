using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace DAL
{
   public class InputTestcaseDAL
    {
       public InputTestcaseDAL()
        {

        }
        public bool insert_InputTestcase(Input_testcase newInput)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Input_testcase.Add(newInput);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool insert_ListInputTestcase(List<Input_testcase> newListInput)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Input_testcase.AddRange(newListInput);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
       
        public List<Input_testcase> get_InputTestcase_ByIdTestcase(string id_testcase,int id_url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                   return db.Input_testcase.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).OrderBy(p=>p.test_step).ToList();
                  
                }
            }
            catch { }
            return null;
        }
        public bool delete_InputTestElement(string id_testcase, int id_url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    var inputElement = get_InputTestcase_ByIdTestcase(id_testcase, id_url).SingleOrDefault();
                    db.Input_testcase.Attach(inputElement);
                    db.Input_testcase.Remove(inputElement);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool update_InputTestElement(Input_testcase oldElement)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Input_testcase.Attach(oldElement);
                    db.Entry(oldElement).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool update_ValueInputTestElement(int id_url,string id_testcase,string id_elment,string value)
        {
            //try
            //{
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    var elemnt=db.Input_testcase.Where(p=>p.id_testcase==id_testcase && p.id_url==id_url && p.id_element==id_elment).SingleOrDefault();
                    if(elemnt!=null)
                    {
                        elemnt.value = value;
                      
                    }
                db.Input_testcase.Attach(elemnt);
                db.Entry(elemnt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            //}
            //catch { }
            return false;
        }
    }
}
