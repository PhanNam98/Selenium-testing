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
        public static List<Element> get_List_Elt_Type_Submit(int id_url)
        {

            return elementDAL.get_List_Elt_Type_Submit(id_url);

        }
        public static List<Element> get_List_Button_Not_Type_Submit(int id_url)
        {

            return elementDAL.get_List_Button_Not_Type_Submit(id_url);

        }
        
        public static List<Element> get_List_Elt_Type_Submit(int id_url,string id_form)
        {

            return elementDAL.get_List_Elt_Type_Submit(id_url,id_form);

        }
      
        public static List<Element> get_List_Input_Tag_Type(int id_url,string type, string id_form)
        {
            return elementDAL.get_List_Input_Tag_Type(id_url,type,id_form);
        }
        public static List<Element> get_List_Input_Tag_Type(int id_url, string type)
        {
            return elementDAL.get_List_Input_Tag_Type(id_url,type);
        }
        public static List<Element> get_List_Element_Tag_Type(int id_url,string tag, string type, string id_form)
        {
            return elementDAL.get_List_Element_Tag_Type(id_url,tag, type, id_form);
        }
        public static List<Element> get_List_Element_Tag_Type(int id_url, string tag, string type)
        {
            return elementDAL.get_List_Element_Tag_Type(id_url,tag, type);
        }
        public static List<Element> get_List_Element_Tag(int id_url, string tag, string id_form)
        {
            return elementDAL.get_List_Element_Tag(id_url, tag, id_form);
        }
        public static List<Element> get_List_Element_Tag(int id_url, string tag)
        {
            return elementDAL.get_List_Element_Tag(id_url, tag);
        }
    }
}
