using System.Web;
using System.Web.Mvc;

namespace bpn_test_sso_netfwork_mvc_1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
