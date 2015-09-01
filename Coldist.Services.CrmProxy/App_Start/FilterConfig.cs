using System.Web;
using System.Web.Mvc;

namespace Coldist.Services.CrmProxy
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
