using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace BUL
{
    public static class FormBUL
    {
        static FormDAL Url;
        static FormBUL()
        {
            Url = new FormDAL();
        }
        public static int insert_Form(Form_elements newForm)
        {

            return Url.insert_Form(newForm);

        }
        public static List<Form_elements> get_ListForm_ByIdUrl(int id)
        {

            return Url.get_ListForm_ByIdUrl(id);

        }
        public static Form_elements get_Form_ByIdForm(string idForm,int idUrl)
        {

            return Url.get_Form_ByIdForm(idForm,idUrl);

        }
    }
}
