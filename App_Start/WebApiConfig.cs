using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Microsoft.Owin.Security.OAuth;
namespace insertwebapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // Web API configuration and services    
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API configuration and services
            config.EnableCors();
            // Web API routes new EnableCorsAttribute("http://localhost:4200","*", "*") { SupportsCredentials = true }
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                 routeTemplate: "api/{controller}/{action}/{id}",//add action
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
