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

    }
}
