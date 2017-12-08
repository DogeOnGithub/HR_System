using Model;

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
    }
}
