using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// 员工档案数据层接口
    /// </summary>
    public interface IStaffDAL : IHRSystemDAL<Staff>
    {

        /// <summary>
        /// 查找所有待复核的员工档案
        /// </summary>
        /// <returns>所有待复核的员工档案</returns>
        List<Staff> GetAllStaffWaitCheck();

        /// <summary>
        /// 把IsDel设为1，逻辑删除指定员工档案
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回影响行数</returns>
        int LoginDeleteStaff(int id);

        /// <summary>
        /// 获取所有待复核的未标记为删除的员工档案
        /// </summary>
        /// <returns>List类型，所有待复核的未标记为删除的员工档案</returns>
        List<Staff> GetAllStaffWaitCheckNormal();

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
        /// 根据id恢复员工档案，即把isDel设为0
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回影响行数</returns>
        int ReturnStaff(int id);

    }
}
