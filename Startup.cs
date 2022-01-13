using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Web.Http.Cors;


[assembly: OwinStartup(typeof(insertwebapi.Startup))]

namespace insertwebapi
{
    public class Startup
    {
        
        public void Configuration(IAppBuilder app)
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
                        ValidIssuer = "http://localhost:4200", //some string, normally web url,  
                        ValidAudience = "http://localhost:4200",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my_secret_key_12345"))
                    }
                });
        }
    }
}
