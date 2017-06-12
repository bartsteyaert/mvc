using System.Web.Mvc;

namespace MVC_Areas.Areas.Publiek
{
    public class PubliekAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Publiek";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Publiek_default",
                "Publiek/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new string[] {"MVC_Areas.Areas.Publiek.Controllers"}
            );
        }
    }
}