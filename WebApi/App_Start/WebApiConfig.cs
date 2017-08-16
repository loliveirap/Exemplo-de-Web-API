using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Avisos",
                routeTemplate: "api/aluno/{id}/avisos",
                defaults: new { Controller = "Avisos", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Historico",
                routeTemplate: "api/aluno/{id}/historico",
                defaults: new { Controller = "Historico", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Notas",
                routeTemplate: "api/aluno/{id}/notas",
                defaults: new { Controller = "Notas", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Pessoa",
                routeTemplate: "api/aluno/{id}/dadospessoais",
                defaults: new { Controller = "Pessoa", id = RouteParameter.Optional }
            );


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
