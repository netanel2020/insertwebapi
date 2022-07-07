using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Web.Http.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

[assembly: OwinStartup(typeof(insertwebapi.Startup))]

namespace insertwebapi
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public void configureservices(IServiceCollection services)
        {
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
        }
        //public void Configure(IWebApplictionBuilder app, IWebHostEnviroment env)
        //{
        //   
        //}
        public void Configuration(IAppBuilder app )
        {
           
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://www.theporto.online", //some string, normally web url,  
                        ValidAudience = "https://www.theporto.online",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_12345"))
                    }
                });
        }
    }
}
