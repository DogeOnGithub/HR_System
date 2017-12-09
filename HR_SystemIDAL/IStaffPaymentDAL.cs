using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// StaffPayment表数据访问接口
    /// </summary>
    public interface IStaffPaymentDAL : IHRSystemDAL<StaffPayment>
    {

        /// <summary>
        /// 通过薪酬单的主键id获取所有的StaffPayment，即每个员工的在指定薪酬单上的个人薪酬
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回符合条件的员工个人薪酬单</returns>
        List<StaffPayment> GetAllStaffPaymentByPaymentId(int id);

        /// <summary>
        /// 通过id更新StaffPayment的Odd以及Minus
        /// </summary>
        /// <param name="id">StaffPayment的主键id</param>
        /// <param name="odd">OddAmout</param>
        /// <param name="minus">MinusAmout</param>
        /// <returns>是否成功</returns>
        int UpdateStaffPayOddAndMinus(int id, decimal odd, decimal minus);

    }
}
