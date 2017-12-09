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
        /// 获取所有未标记为删除的员工档案
        /// </summary>
        /// <returns>List类型，获取所有未标记为删除的员工档案</returns>
        List<Staff> GetAllStaffNormal();

        /// <summary>
        /// 获取所有已标记为删除的员工档案
        /// </summary>
        /// <returns>List类型，获取所有标记为删除的员工档案</returns>
        List<Staff> GetAllStaffDeleted();

        /// <summary>
        /// 获取所有待复核的员工档案
        /// </summary>
        /// <returns>List类型，所有待复核的员工档案</returns>
        List<Staff> GetAllStaffWaitCheck();

        /// <summary>
        /// 获取所有待复核的未标记为删除的员工档案
        /// </summary>
        /// <returns>List类型，所有待复核的未标记为删除的员工档案</returns>
        List<Staff> GetAllStaffWaitCheckNormal();

        /// <summary>
        /// 通过3级机构的id查找员工档案
        /// </summary>
        /// <param name="tOrgId">3级机构的id</param>
        /// <returns>所有符合条件的员工档案</returns>
        List<Staff> GetAllStaffByTOrgId(int tOrgId);

        /// <summary>
        /// 通过2级机构的id查找员工
        /// </summary>
        /// <param name="sOrgId">2级机构的id</param>
        /// <returns>所有符合条件的员工档案</returns>
        List<Staff> GetAllStaffBySOrgId(int sOrgId);

        /// <summary>
        /// 通过1级机构的id查找员工
        /// </summary>
        /// <param name="fOrgId">1级机构的id</param>
        /// <returns>所有符合条件的员工档案</returns>
        List<Staff> GetAllStaffByFOrgId(int fOrgId);

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

        /// <summary>
        /// 逻辑删除员工档案，即把IsDel设为1
        /// </summary>
        /// <param name="id">员工档案的id</param>
        /// <returns>是否成功</returns>
        bool LoginDeleteStaff(int id);

        /// <summary>
        /// 根据id恢复员工档案，即把isDel设为0
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>是否成功</returns>
        bool ReturnStaff(int id);

    }
}
