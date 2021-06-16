using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using insertwebapi.Models;

namespace insertwebapi.Controllers
{
    public class ValuesController : ApiController
    {



        database_access_layer.DB dblayer =new database_access_layer.DB();
        

/*
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

      /*/  // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }
        /*/


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
               return Ok("something wnt wrong");

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
