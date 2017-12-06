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

    }
}
