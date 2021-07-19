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
    public class OrdersDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void addOrders(Orders csOrders)
        {
            SqlCommand com = new SqlCommand("sp_Orders_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ORDID", csOrders.ORDID);
            com.Parameters.AddWithValue("@NumberOfProdacts", csOrders.NumberOfProdacts);
            com.Parameters.AddWithValue("@ProdactsNames", csOrders.ProdactsNames);
            com.Parameters.AddWithValue("@ORDAmount", csOrders.ORDAmount);
            com.Parameters.AddWithValue("@ORDDastenyAddress", csOrders.ORDDastenyAddress);
            com.Parameters.AddWithValue("@TotalCost", csOrders.TotalCost);
            com.Parameters.AddWithValue("@USRIID", csOrders.USRIID);
            com.Parameters.AddWithValue("@USRPaymentDDeatals", csOrders.USRPaymentDDeatals);
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