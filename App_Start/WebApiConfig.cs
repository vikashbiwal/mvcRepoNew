using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPITest
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
              name: "customRoute1",
              routeTemplate: "api/designation/",
              defaults: new { controller = "EmployeeApi", action = "getDesignations" }

          );
            config.Routes.MapHttpRoute(
               name: "customRoute",
               routeTemplate: "api/EmployeeApi/Employees/",
               defaults: new { controller = "EmployeeApi", action = "Employees" }

           );


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }

            //);
            config.Routes.MapHttpRoute(
                 name: "DefaultApi2",
                 routeTemplate: "api/{controller}/{action}/{id}",
                 defaults: new { id = RouteParameter.Optional }

             );
           
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
        }
    }
}
