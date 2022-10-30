using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApplication1.App_Start
{
    public class WebAPIConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            /*            routes.MapHttpRoute(
               name: "api",
               routeTemplate: "api/{controller}",
               defaults: new { controller = "API" }
            );
                        routes.MapHttpRoute(
                           name: "api website",
                           routeTemplate: "api/{controller}/{action}",
                           defaults: new { controller = "API", action = "GetEmp" }
                       );*/
            var json = config.Formatters.JsonFormatter;
            json.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

/*            config.Routes.MapHttpRoute(
                name: "DefaultAPI",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "API", action = "GetAllEmp", id = RouteParameter.Optional }
                );
            config.Routes.MapHttpRoute(
                name: "API",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "API", id = RouteParameter.Optional }
                );*/
        }
    }
}