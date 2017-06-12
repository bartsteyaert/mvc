using System.Web.Mvc;

namespace MVC_Areas.Areas.Prive
{
    public class PriveAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Prive";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Prive_default",
                "Prive/{controller}/{action}/{id}",

                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] {"MVC_Areas.Areas.Prive.Controllers"}
            );
        }
    }
}