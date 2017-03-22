using System.Web;
using System.Web.Mvc;
using VetTrainer.Authentication;

namespace VetTrainer
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CheckAuthorization());
        }
    }
}
