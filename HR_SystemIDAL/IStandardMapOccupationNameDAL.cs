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
    }
}
