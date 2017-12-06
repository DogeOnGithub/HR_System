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

        public Staff GetStaffById(int id)
        {
            //throw new NotImplementedException();

            IStaffDAL dAL = new StaffDAL();

            return dAL.QueryById(id);

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
