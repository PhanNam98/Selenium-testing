using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public static class ElementBUL
    {
        static ElementDAL elementDAL;
        static ElementBUL()
        {
            elementDAL = new ElementDAL();
        }
        public static int insert_Element(Element newElement )
        {

            return elementDAL.insert_Element(newElement);

        }
        public static Element get_Element(int id_url, string id_elt)
        {

            return elementDAL.get_Element(id_url, id_elt);

        }
        public static List<Element> get_ListElement(int id_url)
        {

            return elementDAL.get_ListElement(id_url);

        }
        public static int insert_List_Element(List<Element> listnewElement)
        {

            return elementDAL.insert_List_Element(listnewElement);

        }
    }
}
