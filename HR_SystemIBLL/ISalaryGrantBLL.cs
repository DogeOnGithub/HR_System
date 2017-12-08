using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_SystemIBLL
{
    public interface ISalaryGrantBLL
    {

        /// <summary>
        /// 获取所有的需要发放的薪酬单，调用该方法后会生成Model.SalaryPayment对象并往SalaryPayment表中插入记录，即调用该方法才会生成薪酬单
        /// </summary>
        /// <returns>返回所有需要发放薪酬的薪酬单，即刚刚生成的薪酬单</returns>
        List<SalaryPayment> GetAllSalaryPayment();

    }
}
