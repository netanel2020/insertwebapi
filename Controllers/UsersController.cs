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

    [EnableCors(origins: "https://www.theprotest.online", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UsersController : ApiController
    {
        database_access_layer.UsersDB dblayer = new database_access_layer.UsersDB();






        string query = "select * from Users  ";
        [HttpGet]
        [Authorize]
        public string Get()
        {
            // conect into db
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
            
            SqlDataAdapter da = new SqlDataAdapter(query, con);
//get the request result
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
        public IHttpActionResult addUsers([FromBody] Users csUsers)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblayer.addUsers(csUsers);
                return Ok("success");
            }
            catch
            {
                return Ok("something went wrong");

            }

        }


    }
}
