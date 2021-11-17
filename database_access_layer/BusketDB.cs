using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using insertwebapi.Models;

namespace insertwebapi.database_access_layer
{
    public class BusketDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void addBusket(Buskets csBuskets)
        {


        
            SqlCommand com = new SqlCommand("sp_Busket_add", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@ORDID", csOrders.ORDID);
            com.Parameters.AddWithValue("@BusketId", csBuskets.BusketId);//  i want to put here the user id from cookie
            com.Parameters.AddWithValue("@PRDID", csBuskets.PRDID);
            com.Parameters.AddWithValue("@DelItem", csBuskets.DelItem);
            com.Parameters.AddWithValue("@Quentity", csBuskets.Quentity);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            /*CREATE TABLE [dbo].[Orders] (
    [ORDID]             INT           NOT NULL,
    [NumberOfProdacts]  INT           NULL,
    [ProdactsNames]     VARCHAR (255) NULL,
    [ORDAmount]         VARCHAR (255) NULL,
    [ORDDastenyAddress] VARCHAR (255) NULL,
    [TotalCost]         INT           NULL,
    [USRID]             INT           NULL,
    [USRPaymentDeatals] VARCHAR (255) NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED ([ORDID] ASC),
    CONSTRAINT [FK_Orders_Users] FOREIGN KEY ([USRID]) REFERENCES [dbo].[Users] ([USRID])
);

*/
        }
    }
}