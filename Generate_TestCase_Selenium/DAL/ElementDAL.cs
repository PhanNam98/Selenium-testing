using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ElementDAL
    {
        public int insert_Element(Element newElement)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {

                try
                {
                    db.Elements.Add(newElement);
                    db.SaveChanges();
                    return 1;
                }

                catch
                {
                    return -1;
                }

            }

        }
        public int insert_List_Element(List<Element> listnewElement)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {

                try
                {
                    foreach (var newElement in listnewElement)
                    {
                        db.Elements.Add(newElement);
                        db.SaveChanges();
                        
                    }
                    return 1;
                }

                catch
                {
                    return -1;
                }

            }

        }
        public Element get_Element(int id_url,string id_elt)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                return db.Elements.Where(p => p.id_url == id_url&& p.id_element== id_elt).SingleOrDefault();
            }

        }
        public List<Element> get_ListElement(int id_url)
        {

            using (ElementDBEntities db = new ElementDBEntities())
            {
                return db.Elements.Where(p => p.id_url == id_url).ToList();
            }

        }
    }
}
