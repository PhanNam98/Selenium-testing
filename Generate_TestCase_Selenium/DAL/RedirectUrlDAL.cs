using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class RedirectUrlDAL
    {
        public RedirectUrlDAL() { }

        public bool insert_RedirectUrlTest(Redirect_url newRedirect_Url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Redirect_url.Add(newRedirect_Url);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool update_RedirectUrlTest(Redirect_url oldRedirect_Url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    db.Redirect_url.Attach(oldRedirect_Url);
                    db.Entry(oldRedirect_Url).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool update_RedirectUrlTest(string id_testcase, int id_url, string redirect)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    var oldRedirect_Url = get_RedirectUrlTest(id_testcase, id_url);
                    oldRedirect_Url.redirect_url_test = redirect;
                    db.Redirect_url.Attach(oldRedirect_Url);
                    db.Entry(oldRedirect_Url).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch { }
            return false;
        }
        public bool update_RedirectUrl(string id_testcase, int id_url, string redirect)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
            {
                var oldRedirect_Url = get_RedirectUrlTest(id_testcase, id_url);
                if (oldRedirect_Url == null)
                {
                    oldRedirect_Url = new Redirect_url() { id_testcase = id_testcase, id_url = id_url, redirect_url_test = "" , current_url = redirect};
                    db.Redirect_url.Add(oldRedirect_Url);
                }
                else
                {
                    oldRedirect_Url.current_url = redirect;
                    db.Redirect_url.Attach(oldRedirect_Url);
                    db.Entry(oldRedirect_Url).State = System.Data.Entity.EntityState.Modified;
                }
              
                db.SaveChanges();
                return true;
            }
            }
            catch { }
            return false;
        }
        public Redirect_url get_RedirectUrlTest(string id_testcase, int id_url)
        {
            try
            {
                using (ElementDBEntities db = new ElementDBEntities())
                {
                    return db.Redirect_url.Where(p => p.id_testcase == id_testcase && p.id_url == id_url).SingleOrDefault();

                }
            }
            catch { }
            return null;
        }
    }
}
