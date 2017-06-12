using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace MVC_Tuincentrum
{
    public class QueryStringConstraint : IRouteConstraint
    {
        private string[] verwachteParameters;
        public QueryStringConstraint(string[] verwachteParameters)
        {
            this.verwachteParameters = verwachteParameters;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            foreach(string verwachteParameter in verwachteParameters)
            {
                if (!httpContext.Request.QueryString.AllKeys.Contains(verwachteParameter, StringComparer.OrdinalIgnoreCase))
                    return false;
            }
            return true;
        }
    }
}