using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUL
{
    public static class UrlBUL
    {
        static UrlDAL Url;
        static UrlBUL()
        {
            Url = new UrlDAL();
        }
        public static int insertURL(string url, string name)
        {

           return Url.insertURL(url, name);

        }
        public static int insertURL(Url newurl)
        {

            return Url.insertURL(newurl);

        }
        public static Url getURL(int id)
        {

            return Url.getURL(id);

        }
        public static Url getURL(string url)
        {

            return Url.getURL(url);

        }
    }
}
