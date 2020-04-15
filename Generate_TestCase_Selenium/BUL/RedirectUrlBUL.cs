using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
namespace BUL
{
    public static class RedirectUrlBUL
    {
        static RedirectUrlDAL redirectUrlDAL;
        static RedirectUrlBUL() 
        {
            redirectUrlDAL = new RedirectUrlDAL();
        }

        public static bool Insert_RedirectUrlTest(Redirect_url newRedirect_Url)
        {
            return redirectUrlDAL.insert_RedirectUrlTest(newRedirect_Url);
        }
        public static bool Update_RedirectUrlTest(Redirect_url newRedirect_Url)
        {
            return redirectUrlDAL.update_RedirectUrlTest(newRedirect_Url);
        }
        public static bool Update_RedirectUrlTest(string id_testcase, int id_url, string redirect)
        {
            return redirectUrlDAL.update_RedirectUrlTest(id_testcase,  id_url, redirect);
        }
        public static bool Update_RedirectUrl(string id_testcase, int id_url, string redirect)
        {
            return redirectUrlDAL.update_RedirectUrl(id_testcase, id_url, redirect);
        }
        public static Redirect_url Get_RedirectUrlTest(string id_testcase, int id_url)
        {
            return redirectUrlDAL.get_RedirectUrlTest(id_testcase, id_url);
        }

    }
}
