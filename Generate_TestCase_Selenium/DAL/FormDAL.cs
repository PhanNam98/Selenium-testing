using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace DAL
{
    public class FormDAL
    {
        public int insert_Form(Form_elements newform)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                try
                {
                    int isExist= db.Form_elements.Where(p => p.id_form == newform.id_form && p.id_url == newform.id_url).Count();
                    if (isExist == 0)
                    {
                        db.Form_elements.Add(newform);
                        db.SaveChanges();
                        return 0;
                    }
                    else return 1;
                }
                catch
                {
                    return -1;
                }

            }

        }
        public List<Form_elements> get_ListForm_ByIdUrl(int id_Url)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                return db.Form_elements.Where(p => p.id_url == id_Url).ToList();
            }

        }
        public Form_elements get_Form_ByIdForm(string idForm,int idUrl)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                return db.Form_elements.Where(p => p.id_form == idForm && p.id_url==idUrl).SingleOrDefault();
            }

        }
    }
}
