using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// OccupationName表数据访问层接口
    /// </summary>
    public interface IOccupationNameDAL : IHRSystemDAL<OccupationName>
    {
        /// <summary>
        /// 通过职位类型的id获取所有的职位
        /// </summary>
        /// <param name="classId">职位类型的id</param>
        /// <returns>List类型，所有该类型职位下的职位</returns>
        List<OccupationName> GetAllOccNameByClassId(int classId);

        /// <summary>
        /// 通过职位类型id和职位名字查找职位
        /// </summary>
        /// <param name="name">职位名称</param>
        /// <param name="classId">职位类型的id</param>
        /// <returns>符合条件的职位</returns>
        OccupationName GetOccupationNameByNameAndClass(string name, int classId);
    }
}
