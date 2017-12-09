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

        public List<SalaryPayment> GetAllSalaryPaymentFromDB()
        {
            //throw new NotImplementedException();

            ISalaryPaymentDAL dAL = new SalaryPaymentDAL();

            return dAL.Query();

        }

        public List<SalaryPayment> GetAllSalaryPaymentWaitCheck()
        {
            //throw new NotImplementedException();

            ISalaryPaymentDAL dAL = new SalaryPaymentDAL();

            return dAL.GetAllSalaryPaymentWaitCheck();
        }

        public List<SalaryPayment> GetAllSalaryPaymentWaitReg()
        {
            //throw new NotImplementedException();

            ISalaryPaymentDAL dAL = new SalaryPaymentDAL();

            return dAL.GetAllSalaryPaymentWaitReg();

        }

        /// <summary>
        /// 通过薪酬单的主键id获取所有的StaffPayment，即每个员工的在指定薪酬单上的个人薪酬
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回符合条件的员工个人薪酬单</returns>
        public List<StaffPayment> GetAllStaffPaymentByPaymentId(int id)
        {
            //throw new NotImplementedException();

            IStaffPaymentDAL dAL = new StaffPaymentDAL();

            return dAL.GetAllStaffPaymentByPaymentId(id);

        }

        public SalaryPayment GetSalaryPaymentById(int id)
        {
            //throw new NotImplementedException();

            ISalaryPaymentDAL dAL = new SalaryPaymentDAL();

            return dAL.QueryById(id);

        }

        public StaffSalary GetStaffSalaryById(int id)
        {
            //throw new NotImplementedException();

            IStaffSalaryDAL dAL = new StaffSalaryDAL();

            return dAL.QueryById(id);

        }

        public bool SaveSalaryPayment(SalaryPayment salaryPayment)
        {
            //throw new NotImplementedException();

            ISalaryPaymentDAL dAL = new SalaryPaymentDAL();

            if (dAL.QueryById(salaryPayment.Id) != null)
            {
                if (dAL.Update(salaryPayment) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (dAL.Add(salaryPayment) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool SaveStaffSalary(StaffSalary staffSalary)
        {
            //throw new NotImplementedException();

            IStaffSalaryDAL dAL = new StaffSalaryDAL();

            if (dAL.QueryById(staffSalary.Id) != null)
            {
                if (dAL.Update(staffSalary) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (dAL.Add(staffSalary) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// 通过id更新StaffPayment的Odd以及Minus
        /// </summary>
        /// <param name="id">StaffPayment的主键id</param>
        /// <param name="odd">OddAmout</param>
        /// <param name="minus">MinusAmout</param>
        /// <returns>是否成功</returns>
        public bool UpdateStaffPayOddAndMinus(int id, decimal odd, decimal minus)
        {
            //throw new NotImplementedException();

            IStaffPaymentDAL dAL = new StaffPaymentDAL();

            if (dAL.UpdateStaffPayOddAndMinus(id, odd, minus) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
