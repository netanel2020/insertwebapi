using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using insertwebapi.Models;

namespace insertwebapi.Controllers
{
    public class OrdersController : ApiController
    {
        database_access_layer.OrdersDB dblayer = new database_access_layer.OrdersDB();

        // POST api/values
        [HttpPost]
        public IHttpActionResult addOrders([FromBody] Orders csOrders)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                dblayer.addOrders(csOrders);
                return Ok("success");
            }
            catch
            {
                return Ok("something went wrong");

            }

        }
        /*CREATE PROC sp_Orders_add

	@ORDID INT ,
    @NumberOfProdacts int,
    @ProdactsNames varchar(255),
    @ORDAmount varchar(255),
    @ORDDastenyAddress VARCHAR (255),
    @TotalCost int,
    @USRID int,
    @USRPaymentDeatals  VARCHAR (255)
AS
begin
	insert into Orders values(
	@ORDID ,
    @NumberOfProdacts ,
    @ProdactsNames ,
    @ORDAmount ,
    @ORDDastenyAddress ,
    @TotalCost ,
    @USRID  ,
    @USRPaymentDeatals  
	)
end*/

    }
}
