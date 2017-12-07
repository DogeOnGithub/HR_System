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
    public class StaffBLL : IStaffBLL
    {
        public List<Staff> GetAllStaff()
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            return dAL.Query();

        }

        public List<Staff> GetAllStaffNormal()
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            return dAL.GetAllStaffNormal();

        }

        public List<Staff> GetAllStaffWaitCheck()
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            return dAL.GetAllStaffWaitCheck();

        }

        public List<Staff> GetAllStaffWaitCheckNormal()
        {

            IStaffDAL dAL = new StaffDAL();

            return dAL.GetAllStaffWaitCheckNormal();

        }

        public Staff GetStaffById(int id)
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            return dAL.QueryById(id);

        }

        /// <summary>
        /// 逻辑删除员工档案
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>是否成功</returns>
        public bool LoginDeleteStaff(int id)
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            if (dAL.LoginDeleteStaff(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 保存员工档案
        /// </summary>
        /// <param name="staff">需要保存的员工档案</param>
        /// <returns>是否成功</returns>
        public bool SaveStaff(Staff staff)
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            if (dAL.QueryById(staff.Id) != null)
            {
                if (dAL.Update(staff) > 0)
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
                if (dAL.Add(staff) > 0)
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
}
