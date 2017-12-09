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
    public class StaffPaymentDAL : BaseHRSystemDAL<StaffPayment>, IStaffPaymentDAL
    {
        public List<StaffPayment> GetAllStaffPaymentByPaymentId(int id)
        {
            //throw new NotImplementedException();

            List<StaffPayment> list = new List<StaffPayment>();

            string sql = "select * from StaffPayment where paymentId=@paymentId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@paymentId", id)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StaffPayment staffPayment = new StaffPayment
                        {
                            Id = reader.GetInt32(0),
                            StaffSalaryId = reader.GetInt32(1),
                            PaymentId = reader.GetInt32(2),
                            OddAmout = reader.GetDecimal(3),
                            MinusAmout = reader.GetDecimal(4)
                        };
                        list.Add(staffPayment);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public int UpdateStaffPayOddAndMinus(int id, decimal odd, decimal minus)
        {
            //throw new NotImplementedException();

            string sql = "update StaffPayment set oddAmout=@oddAmout, minusAmout=@minusAmout where id=@id";

            return SQLHelper.ExecuteNonQuery(sql, new SqlParameter("@oddAmout", odd), new SqlParameter("@minusAmout", minus), new SqlParameter("@id", id));

        }
    }
}
