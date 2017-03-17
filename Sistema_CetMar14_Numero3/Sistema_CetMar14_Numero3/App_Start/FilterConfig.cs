using System.Web;
using System.Web.Mvc;

namespace Sistema_CetMar14_Numero3
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
