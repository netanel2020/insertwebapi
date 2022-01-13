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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BusketController : ApiController
    {

        database_access_layer.BusketDB dblayer = new database_access_layer.BusketDB();
       
        string query = "select * from Busket where BusketId=";

        string GetQuery = "select * from Busket";
        // GET api/<controller>
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
        public void Delete(int id)
        {
        }
    }
}
/*
     







        

        }
        

    }
}
*/