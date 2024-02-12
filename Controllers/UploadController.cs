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
using System.Web;
using System.IO;

namespace insertwebapi.Controllers
{
    [EnableCors(origins: "https://www.theprotest.online", headers: "*", methods: "*", SupportsCredentials = true)]
    public class UploadController : ApiController
    {
        database_access_layer.ProdactsDB dblayer = new database_access_layer.ProdactsDB();
        string deletebusket = "delete  from busket where PRDID =";
        string DeleteQuery = "DELETE FROM Prodacts WHERE PRDID=";
        [HttpGet]
        public void Get()
        {
        }
        [HttpGet]
        public void GetSearch(string s)
        {
        }

        // POST api/values
        // [Authorize]
        [HttpPost, Microsoft.AspNetCore.Mvc.DisableRequestSizeLimit]
        public IHttpActionResult post ()
        {
            
              //  HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;
                //var PathToSave=Path.com
               
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = "C:/inetpub/wwwroot/assets/prodacts/";
                    //var filename = httpRequest.filename[file]; //i want to reaname the file while requesting
                        postedFile.SaveAs(filePath+postedFile.FileName);
                        docfiles.Add(filePath);
                    }
                  //  result =
                return  Ok(200); 
                }
                else
                {
                return BadRequest();
            }



                //try
                //{
                //    if (!ModelState.IsValid)
                //    {
                //        return BadRequest(ModelState);
                //    }
                //    dblayer.addProdacts(cs);
                //    return Ok("success");
                //}
                //catch
                //{
                //    return Ok("something went wrong");

                //}

            
        }
        // DELETE api/values/5
            [Authorize]
            [HttpDelete]
            public void Delete()
            {
            }

    }
} 



//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Http;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using Microsoft.Net.Http.Headers;

//namespace insertwebapi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UploadController : ControllerBase
//    {
//        [HttpPost, ]
//        public IActionResult Upload()
//        {
//            try
//            {
//                var file = Request.Form.Files[0];
//                var folderName = Path.GetDirectoryName("C:/inetpub/wwwroot/assets/images");
//                //var PathToSave=Path.com
//                if (file.Length > 0)
//                {
//                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim(); //('"'); it  can caus a problem !!! you need to remove the " signs 

//                    var fullPath = Path.Combine(folderName, fileName.ToString());
//                    using (var stream = new FileStream(fullPath, FileMode.Create))
//                    {
//                        file.CopyTo(stream);
//                        return Ok(new { fullPath });
//                    }
//                }
//                else
//                {
//                  return  BadRequest("no file was send");
//                }
//            }
//            catch(Exception ex)
//            {
//                return StatusCode(500,$"internal server error:{ex}");
//            }
//        }
//    }
//}
