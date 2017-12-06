using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_SystemIBLL
{
    public interface IStaffBLL
    {

        /// <summary>
        /// 获取所有员工档案
        /// </summary>
        /// <returns>List类型，所有员工档案</returns>
        List<Staff> GetAllStaff();

        /// <summary>
        /// 获取所有待复核的员工档案
        /// </summary>
        /// <returns>List类型，所有待复核的员工档案</returns>
        List<Staff> GetAllStaffWaitCheck();

        /// <summary>
        /// 通过id获取员工档案
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回id对应的员工档案</returns>
        Staff GetStaffById(int id);

        /// <summary>
        /// 保存员工档案
        /// </summary>
        /// <param name="staff">需要保存的员工档案</param>
        /// <returns>是否成功</returns>
        bool SaveStaff(Staff staff);

    }
}
