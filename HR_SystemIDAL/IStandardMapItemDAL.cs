using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// 薪酬标准与薪酬项目映射表数据层接口
    /// </summary>
    public interface IStandardMapItemDAL : IHRSystemDAL<StandardMapItem>
    {

        /// <summary>
        /// 通过薪酬标准的id获取所有的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>返回所有该id对应的薪酬标准的id</returns>
        List<StandardMapItem> GetAllStandardMapItemByStandardId(int standardId);

    }
}
