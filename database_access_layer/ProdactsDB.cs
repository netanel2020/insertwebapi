using insertwebapi.Models;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace insertwebapi.database_access_layer
{
    public class ProdactsDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        public void addProdacts(Prodacts cs)
        {
            
            SqlCommand com = new SqlCommand("sp_prodact_add", con);
            com.CommandType = CommandType.StoredProcedure;
          //   com.Parameters.AddWithValue("@PRDID", );
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