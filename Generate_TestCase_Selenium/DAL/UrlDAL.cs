using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UrlDAL
    {
        
        public int insertURL(string url,string name)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                try
                {
                    Url newurl = new Url();
                    newurl.name = name;
                    newurl.url1 = url;
                    db.Urls.Add(newurl);
                    db.SaveChanges();
                    return newurl.id_url;
                }
                catch
                {
                    return -1;
                }
               
            }

        }
        public int insertURL(Url newurl)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                try
                {
                    
                    db.Urls.Add(newurl);
                    db.SaveChanges();
                    return newurl.id_url;
                }
                catch
                {
                    return -1;
                }

            }

        }
        public Url getURL(int id)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                return db.Urls.Where(p => p.id_url == id).SingleOrDefault();
            }

        }
        public Url getURL(string url)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                return db.Urls.Where(p => p.url1 == url).SingleOrDefault();
            }

        }
    }
}
