using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace insertwebapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
       // protected void Application_BeginRequest()
       //{
       //   HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
          
       // }
        protected void Application_Start()
        {
           GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
//GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Fo services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", p =>
//    {
//        p.AllowAnyOrigin()
//        .AllowAnyHeader()
//        .AllowAnyMethod()
//        .AllowCredentials();
//    });
//}); rmatters.XmlFormatter); 