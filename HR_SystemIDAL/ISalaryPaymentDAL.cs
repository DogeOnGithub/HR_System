using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// SalaryPayment表数据访问接口
    /// </summary>
    public interface ISalaryPaymentDAL : IHRSystemDAL<SalaryPayment>
    {
        /// <summary>
        /// 通过唯一的档案编号查找薪酬发放单
        /// </summary>
        /// <param name="fileNumber">薪酬发放单编号</param>
        /// <returns>返回对应的薪酬发放单</returns>
        SalaryPayment GetSalaryPaymentByFileNumber(string fileNumber);

        /// <summary>
        /// 获取所有已经生成了薪酬单的，但尚未登记过的薪酬单
        /// </summary>
        /// <returns>返回所有等待登记的薪酬单</returns>
        List<SalaryPayment> GetAllSalaryPaymentWaitReg();

        /// <summary>
        /// 获取所有需要复核的薪酬单
        /// </summary>
        /// <returns>返回所有等待复核的薪酬单</returns>
        List<SalaryPayment> GetAllSalaryPaymentWaitCheck();
    }
}
