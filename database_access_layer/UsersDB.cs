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
    public class UsersDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void addUsers(Users csUsers)
        {
            SqlCommand com = new SqlCommand("sp_Users_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@USPass", csUsers.USPass);
            com.Parameters.AddWithValue("@USRname", csUsers.USRname);
            com.Parameters.AddWithValue("@USRlastName", csUsers.USRlastName);
            com.Parameters.AddWithValue("@USRaddres", csUsers.USRaddres);
            com.Parameters.AddWithValue("@City", csUsers.City);
            com.Parameters.AddWithValue("@USRTitle", csUsers.USRTitle);
            com.Parameters.AddWithValue("@USRPhone", csUsers.USRPhone);
            com.Parameters.AddWithValue("@USRPaymentDeatals", csUsers.USRPaymentDeatals);
   
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            /*CREATE PROC sp_Users_add

	@ORDID INT not null,
    @NumberOfProdacts int,
    @ProdactsNames varchar(255),
    @ORDAmount varchar(255),
    @ORDDastenyAddress VARCHAR (255),
    @TotalCost int,
    @USRID int,
    @USRPaymentDeatals int
AS
begin
	insert into Users values(
		@ORDID ,
    @NumberOfProdacts ,
    @ProdactsNames ,
    @ORDAmount ,
    @ORDDastenyAddress ,
    @TotalCost ,
    @USRID ,
    @USRPaymentDeatals  
	)
end*/
        }
    }
}