using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using insertwebapi.Models;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Configuration;
using insertwebapi.database_access_layer;
using System.Web.Http.Cors;
using System.Security.Claims;

namespace insertwebapi.Controllers
{
    [EnableCors(origins: "http://www.theporto.online", headers: "*", methods: "*", SupportsCredentials = true)]
    public class BusketController : ApiController
    {

        database_access_layer.BusketDB dblayer = new database_access_layer.BusketDB();
       
        string query = "SELECT * FROM Prodacts FULL OUTER JOIN Busket ON Prodacts.PRDID =Busket.PRDID WHERE Busket.BusketId=";

        string GetQuery = "select * from Busket"; 
        string DeleteQuery = "DELETE FROM Busket WHERE ItemId=";
        // GET api/<controller>
        //    [Authorize]
        [HttpGet]
        public string Get(int id)
        {
           /* if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> claims = identity.Claims;
                }
                */
          
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(query+id, con);
            DataTable DT = new DataTable();
            da.Fill(DT);
            if (DT.Rows.Count > 0)
            {

                return JsonConvert.SerializeObject(DT);

            }
            else
            {
                return "no data found";
            } /*
            }
            else
            {
                return "Invalid";
            }*/
        }

        // GET api/<controller>
        public string Get()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(GetQuery, con);
            DataTable DT = new DataTable();
            da.Fill(DT);
            if (DT.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(DT);

            }
            else
            {
                return "no data found";
            }
        }

        // POST api/values
        [HttpPost]
        public IHttpActionResult addBusket([FromBody] Buskets csBuskets)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblayer.addBusket(csBuskets);
                return Ok("success");
            }
            catch
            {
                return Ok("something went wrong");

            }
        }
            // PUT api/<controller>/5
            public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid prodact id");

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(DeleteQuery+id, con);
            DataTable DT = new DataTable();
            da.Fill(DT);
           
           

            return Ok();

        }
    }
}
/*
     







        

        }
        

    }
}
*/