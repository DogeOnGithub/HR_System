using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// 薪酬标准与职位的映射关系表数据层接口
    /// </summary>
    public interface IStandardMapOccupationNameDAL : IHRSystemDAL<StandardMapOccupationName>
    {
        /// <summary>
        /// 通过薪酬标准的id获取所有的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>List类型，所有的映射关系</returns>
        List<StandardMapOccupationName> GetAllMapByStandardId(int standardId);

        /// <summary>
        /// 通过薪酬标准的id和职位的id查找映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <param name="OccNameId">职位的id</param>
        /// <returns>返回对应的映射关系</returns>
        StandardMapOccupationName GetMapByStandardIdAndOccNameId(int standardId, int OccNameId);

        /// <summary>
        /// 通过薪酬id删除薪酬标准和职位的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>返回影响行数</returns>
        int DeleteAllOccMapByStandardId(int standardId);
    }
}
