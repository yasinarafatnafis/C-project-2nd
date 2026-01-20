using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace C__project
{
    internal class DataAccess
    {
        private readonly string connectionString;

        public DataAccess()
        {
            connectionString = ConfigurationManager
                .ConnectionStrings["OfficeDB"]
                .ConnectionString;
        }

        public DataTable ExecuteQueryTable(string sql)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public int ExecuteDMLQuery(string sql)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
