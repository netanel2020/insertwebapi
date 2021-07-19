using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using insertwebapi.Models;

namespace insertwebapi.Controllers
{
    public class UsersController : ApiController
    {
        database_access_layer.UsersDB dblayer = new database_access_layer.UsersDB();

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
