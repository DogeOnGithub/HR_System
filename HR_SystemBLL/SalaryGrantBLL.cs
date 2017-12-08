using HR_SystemIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using HR_SystemIDAL;
using HR_SystemDAL;

namespace HR_SystemBLL
{
    public class SalaryGrantBLL : ISalaryGrantBLL
    {
        /// <summary>
        /// 实现接口，生成薪酬单并返回
        /// </summary>
        /// <returns>返回所有需要发放的薪酬单</returns>
        public List<SalaryPayment> GetAllSalaryPayment()
        {
            //throw new NotImplementedException();

            ISalaryGrantDAL dAL = new SalaryGrantDAL();

            return dAL.GetAllSalaryPayment();

        }
    }
}
