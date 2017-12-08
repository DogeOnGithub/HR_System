using HR_SystemIDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using Utils;

namespace HR_SystemDAL
{
    public class SalaryGrantDAL : ISalaryGrantDAL
    {
        public List<SalaryPayment> GetAllSalaryPayment()
        {
            //throw new NotImplementedException();

            List<SalaryPayment> list = new List<SalaryPayment>();

            ISalaryPaymentDAL salaryPaymentDAL = new SalaryPaymentDAL();

            string sql = @"SELECT COUNT(ss.id) totalPerson, SUM(s.total) totalAmout, ss.tOrgId FROM StaffSalary ss, SalaryStandard s WHERE ss.standardId = s.id GROUP BY ss.tOrgId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SalaryPayment salaryPayment = new SalaryPayment
                        {
                            TotalPerson = Convert.ToInt32(reader["totalPerson"]),
                            TotalAmout = Convert.ToDecimal(reader["totalAmout"]),
                            TOrgId = Convert.ToInt32(reader["tOrgId"])
                        };
                        salaryPayment.FileNumber = Guid.NewGuid().ToString();
                        salaryPayment.FileState = EnumState.SalaryPaymentStateEnum.WaitRegist;
                        salaryPayment.RegistTime = DateTime.Now;
                        list.Add(salaryPayment);
                    }
                }
                else
                {
                    list = null;
                }
            }

            if (list != null)
            {
                foreach (var salaryPayment in list)
                {
                    salaryPaymentDAL.Add(salaryPayment);
                }
            }

            List<SalaryPayment> paymentList = new List<SalaryPayment>();

            foreach (var p in list)
            {
                paymentList.Add(salaryPaymentDAL.GetSalaryPaymentByFileNumber(p.FileNumber));
            }

            return paymentList;

        }
    }
}
