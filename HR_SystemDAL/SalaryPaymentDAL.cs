using EnumState;
using HR_SystemIDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace HR_SystemDAL
{
    public class SalaryPaymentDAL : BaseHRSystemDAL<SalaryPayment>, ISalaryPaymentDAL
    {
        public List<SalaryPayment> GetAllSalaryPaymentWaitCheck()
        {
            //throw new NotImplementedException();

            List<SalaryPayment> list = new List<SalaryPayment>();

            string sql = "select * from SalaryPayment where fileState=1";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SalaryPayment salaryPayment = new SalaryPayment
                        {
                            Id = reader.GetInt32(0),
                            FileNumber = reader.GetString(1),
                            TotalPerson = reader.GetInt32(2),
                            TotalAmout = reader.GetDecimal(3),
                            RegistTime = reader.GetDateTime(4),
                            FileState = (SalaryPaymentStateEnum)reader.GetInt32(5),
                            TOrgId = reader.GetInt32(6),
                            TotalReal = reader.GetDecimal(7)
                        };
                        list.Add(salaryPayment);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public List<SalaryPayment> GetAllSalaryPaymentWaitReg()
        {
            //throw new NotImplementedException();

            List<SalaryPayment> list = new List<SalaryPayment>();

            string sql = "select * from SalaryPayment where fileState=0";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SalaryPayment salaryPayment = new SalaryPayment
                        {
                            Id = reader.GetInt32(0),
                            FileNumber = reader.GetString(1),
                            TotalPerson = reader.GetInt32(2),
                            TotalAmout = reader.GetDecimal(3),
                            RegistTime = reader.GetDateTime(4),
                            FileState = (SalaryPaymentStateEnum)reader.GetInt32(5),
                            TOrgId = reader.GetInt32(6),
                            TotalReal = reader.GetDecimal(7)
                        };
                        list.Add(salaryPayment);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public SalaryPayment GetSalaryPaymentByFileNumber(string fileNumber)
        {
            //throw new NotImplementedException();

            SalaryPayment salaryPayment = null;

            string sql = @"select * from SalaryPayment where fileNumber=@fileNumber";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@fileNumber", fileNumber)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        salaryPayment = new SalaryPayment
                        {
                            Id = reader.GetInt32(0),
                            FileNumber = reader.GetString(1),
                            TotalPerson = reader.GetInt32(2),
                            TotalAmout = reader.GetDecimal(3),
                            RegistTime = reader.GetDateTime(4),
                            FileState = (SalaryPaymentStateEnum)reader.GetInt32(5),
                            TOrgId = reader.GetInt32(6)
                        };
                    }
                }
            }

            return salaryPayment;

        }
    }
}
