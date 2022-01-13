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

namespace insertwebapi.Controllers
{
    [EnableCors(origins: "*", headers: " *", methods: "*")]
    public class ProdactController : ApiController
    {



        database_access_layer.ProdactsDB dblayer =new database_access_layer.ProdactsDB();
        

        [HttpGet]
        public string Get()
        {
             string query = "select * from Prodacts";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable DT = new DataTable();
            da.Fill(DT);
            if (DT.Rows.Count>0)
            {
 return JsonConvert.SerializeObject(DT);
                
            }
            else
            {
                return "no data found";
            }
        }

       // GET api/values/5
        public string Get(int id)
        {
            string query = "select * from Prodacts where PRDID=  ";
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(query + id, con);
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
        public IHttpActionResult addProdact([FromBody] Prodacts cs)
        {

            try
            {
                if (!ModelState.IsValid){ 
                    return BadRequest(ModelState);
                }
                dblayer.addProdacts(cs);
                return Ok("success");
           }
            catch
            {
               return Ok("something went wrong");

          }

        }
/*
        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
*/
    }
}
