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
    [EnableCors(origins: "http://www.theporto.online", headers: "*", methods: "POST,GET,DELETE",SupportsCredentials = true)]
    public class ProdactController : ApiController
    {



        database_access_layer.ProdactsDB dblayer =new database_access_layer.ProdactsDB();

        string DeleteQuery = "DELETE FROM Prodacts WHERE PRDID=";
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
        [HttpGet]
        public string GetSearch(string s)
        {
            string query = "select * from Prodacts where PRDname like "+ 'N'+@"'"+ "%" + s +"%"+@"'";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

            SqlDataAdapter da = new SqlDataAdapter(query, con);
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
        //   select* from Prodacts where PRDname like N'%ח%'
        // GET api/values/5
        [Authorize]
       [HttpGet]
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
        [Authorize]
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
         */
        // DELETE api/values/5
        [Authorize]
        [HttpDelete]
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
