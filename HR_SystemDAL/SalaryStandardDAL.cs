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

        public List<SalaryStandard> GetAllSalaryStandardWaitCheck()
        {
            //throw new NotImplementedException();

            List<SalaryStandard> list = new List<SalaryStandard>();

            string sql = "select * from SalaryStandard where standardState=0";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SalaryStandard salaryStandard = new SalaryStandard
                        {
                            Id = reader.GetInt32(0),
                            StandardName = reader.GetString(1),
                            StandardFileNumber = reader.GetString(2),
                            Registrant = reader.GetString(3),
                            RegistTime = reader.GetDateTime(4),
                            DesignBy = reader.GetString(5),
                            Total = reader.GetDecimal(6),
                            StandardState = (EnumState.StandardStateEnum)reader.GetInt32(7),
                            CheckDesc = reader.GetString(8),
                            CheckBy = reader.GetString(9)
                        };
                        list.Add(salaryStandard);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public int GetStandardIdByFileNumber(string fileNumber)
        {
            //throw new System.NotImplementedException();

            string sql = "select id from SalaryStandard where standardFileNumber=@standardFileNumber";

            return Convert.ToInt32(SQLHelper.ExecuteScalar(sql, new System.Data.SqlClient.SqlParameter("@standardFileNumber", fileNumber)));

        }
    }
}
