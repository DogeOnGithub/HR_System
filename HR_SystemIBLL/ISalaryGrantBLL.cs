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

        /// <summary>
        /// 获取所有的薪酬单
        /// </summary>
        /// <returns>所有薪酬单</returns>
        List<SalaryPayment> GetAllSalaryPaymentFromDB();

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

        /// <summary>
        /// 通过薪酬单的主键id获取所有的StaffPayment，即每个员工的在指定薪酬单上的个人薪酬
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回符合条件的员工个人薪酬单</returns>
        List<StaffPayment> GetAllStaffPaymentByPaymentId(int id);

        /// <summary>
        /// 通过id获取员工薪酬，StaffSalary，即员工的简化表
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回对应的StaffSalary</returns>
        StaffSalary GetStaffSalaryById(int id);

        /// <summary>
        /// 通过id获取薪酬单
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回对应的薪酬单</returns>
        SalaryPayment GetSalaryPaymentById(int id);

        /// <summary>
        /// 通过id更新StaffPayment的Odd以及Minus
        /// </summary>
        /// <param name="id">StaffPayment的主键id</param>
        /// <param name="odd">OddAmout</param>
        /// <param name="minus">MinusAmout</param>
        /// <returns>是否成功</returns>
        bool UpdateStaffPayOddAndMinus(int id, decimal odd, decimal minus);

        /// <summary>
        /// 保存薪酬单
        /// </summary>
        /// <param name="salaryPayment">需要保存的薪酬单</param>
        /// <returns>是否成功</returns>
        bool SaveSalaryPayment(SalaryPayment salaryPayment);

    }
}
