using HR_SystemIDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utils;

namespace HR_SystemDAL
{
    public class SalaryStandardDAL : BaseHRSystemDAL<SalaryStandard>, ISalaryStandardDAL
    {
        public int DeleteSalaryStandard(int id)
        {
            //throw new NotImplementedException();

            int rows = 0;

            string sql1 = "delete from StandardMapItem where standardId=@standardId";

            string sql2 = "delete from SalaryStandard where id=@id";

            using (SqlConnection con = DBUtil.GetConnection())
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(sql1, con, tran))
                        {
                            cmd.Parameters.Add(new SqlParameter("@standardId", id));
                            rows += cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = new SqlCommand(sql2, con, tran))
                        {
                            cmd.Parameters.Add(new SqlParameter("@id", id));
                            rows += cmd.ExecuteNonQuery();
                        }

                        tran.Commit();

                        return rows;
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        return -1;
                    }
                }
            }



        }

        public int GetStandardIdByFileNumber(string fileNumber)
        {
            //throw new System.NotImplementedException();

            string sql = "select id from SalaryStandard where standardFileNumber=@standardFileNumber";

            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, new System.Data.SqlClient.SqlParameter("@standardFileNumber", fileNumber)));

        }
    }
}
