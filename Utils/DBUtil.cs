using System.Configuration;
using System.Data.SqlClient;

namespace Utils
{
    public static class DBUtil
    {
        static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString;

        public static SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
