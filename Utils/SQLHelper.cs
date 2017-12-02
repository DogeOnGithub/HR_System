using System.Data;
using System.Data.SqlClient;

namespace Utils
{
    public static class SQLHelper
    {

        /// <summary>
        /// 增删改数据库的方法，执行单条语句
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数数组</param>
        /// <returns>返回影响行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            try
            {
                using (SqlConnection con = DBUtil.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        if (parameters != null)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }

                        con.Open();

                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (System.Exception)
            {
                return -1;
                //throw;
            }
        }

        /// <summary>
        /// 一般用于聚合函数的查询，返回结果的第一行第一列且为object类型
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数数组</param>
        /// <returns>返回结果的第一行第一列且为Object类型</returns>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection con = DBUtil.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }

                    con.Open();

                    return cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// 查询数据库，返回一个Reader
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数数组</param>
        /// <returns>返回一个SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection con = DBUtil.GetConnection();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                con.Open();

                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }

        /// <summary>
        /// 查询一个表，返回一个DataTable
        /// </summary>
        /// <param name="sql">需要执行的sql语句</param>
        /// <param name="parameters">sql语句中的参数数组</param>
        /// <returns>返回一张表</returns>
        public static DataTable ExecuteTable(string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = DBUtil.GetConnection())
            {
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con))
                {
                    dataAdapter.SelectCommand.Parameters.AddRange(parameters);
                    dataAdapter.Fill(dt);
                }
            }
            return dt;
        }

    }
}
