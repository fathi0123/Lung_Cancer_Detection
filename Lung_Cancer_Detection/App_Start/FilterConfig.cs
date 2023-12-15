using System.Web;
using System.Web.Mvc;

namespace Lung_Cancer_Detection
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
