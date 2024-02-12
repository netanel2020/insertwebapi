using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using insertwebapi.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration;
using insertwebapi.database_access_layer;
using System.Web.Http.Cors;

namespace insertwebapi.Controllers
{
    
    [EnableCors(origins: "https://www.theprotest.online", headers: "*", methods: "*", SupportsCredentials = true)]
    public class AuthController : ApiController
    {
        database_access_layer.UsersDB dblayer = new database_access_layer.UsersDB();
        

        [HttpGet]
        public void get()
        {


        }
        // post api/<controller>/
        //[DisableCors]
        [HttpPost]
        public Object PostToken([FromBody]  AuthClass csAUTH)
        {
           
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            string query = "select * from Users where USPass =" + @"'" + csAUTH.pass1+ @"'" + " AND USRPhone =" + @"'" + csAUTH.USRPhone1 + @"'";
            string query2 = query;
                
            SqlDataAdapter da = new SqlDataAdapter(query ,con);
            DataTable DT = new DataTable();
            da.Fill(DT);
            if (DT.Rows.Count > 0)
            {
                string key = "my_secret_key_12345";
                string USRIDfromDB = DT.Rows[0]["USRID"].ToString();
                
              var issuer = "https://www.theprotest.online";  //normally this will be your site URL    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Create a List of Claims, Keep claims name short    string abc= dt.Rows[0]["column name"].ToString();
                var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("name", DT.Rows[0]["USRName"].ToString()));
                permClaims.Add(new Claim("userid", USRIDfromDB)); 
                permClaims.Add(new Claim("busketID", USRIDfromDB));
                permClaims.Add(new Claim("admin", DT.Rows[0]["Admin"].ToString()));
                //Create Security Token object by giving required parameters    {{"alg":"HS256","typ":"JWT"}.{"jti":"90e58fd3-7740-452a-888b-f97620556425","valid":"1","name":"'0500000000'","USRID":"1023","exp":1637057148,"iss":"127.0.0.1","aud":"127.0.0.1"}}
                var token = new JwtSecurityToken(issuer, //Issure    
                            issuer,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddHours(0.5),
                            signingCredentials: credentials);
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return  jwt_token ;
            }
            else
            {
                return "no data found";
            }
          
        }
        //post api/<controller>/
        [HttpPost]
        public String GetName1()
        {
            if (User.Identity.IsAuthenticated)
            {
                
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }
         [Authorize]
        [HttpPost]
        public Object GetName2()
        {
            
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                var busketId = claims.Where(p => p.Type == "busketID").FirstOrDefault()?.Value;
                var isAdmin = claims.Where(p => p.Type == "admin").FirstOrDefault()?.Value;
                return new
                {
                    name = name,
                    busketid = busketId,
                    isadmin=isAdmin
                };

            }
            return "this identity is null";
        }

    }
}