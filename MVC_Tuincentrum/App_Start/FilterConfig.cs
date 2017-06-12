using System.Data.Entity.Core;
using System.Web;
using System.Web.Mvc;

namespace MVC_Tuincentrum
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            HandleErrorAttribute myHandleErrorAttribute = new HandleErrorAttribute();
            myHandleErrorAttribute.View = "DatabaseError";
            myHandleErrorAttribute.ExceptionType = typeof(EntityException);
            myHandleErrorAttribute.Order = 1;
            filters.Add(myHandleErrorAttribute);
            filters.Add(new HandleErrorAttribute());
        }
    }
}
