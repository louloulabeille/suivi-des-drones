using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suivi_des_drones.Core.Infrastructure.Web.Constraint
{
    public class MatriculeRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            bool retour = false;

            object? value = values[routeKey];
            retour  = value!=null && value.GetType() == typeof(string) && value.ToString()?.Length > 5;

            return retour;
        }
    }
}
