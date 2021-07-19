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
    public class DB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void addProdacts(Prodacts cs)
        {
            SqlCommand com = new SqlCommand("sp_prodact_add", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@PRDID", cs.PRDID);
            com.Parameters.AddWithValue("@PRDname", cs.PRDname);
            com.Parameters.AddWithValue("@PRDAttribute", cs.PRDAttribute);
            com.Parameters.AddWithValue("@PRDTitle", cs.PRDTitle);
            com.Parameters.AddWithValue("@PRDCategory", cs.PRDCategory);
            com.Parameters.AddWithValue("@PRDPrice", cs.PRDPrice);
            com.Parameters.AddWithValue("@PRDCost", cs.PRDCost);
            com.Parameters.AddWithValue("@PRDImage", cs.PRDImage);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

    
    }
}