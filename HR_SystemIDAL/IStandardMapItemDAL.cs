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
        /// <returns>返回所有该id对应的所有映射关系</returns>
        List<StandardMapItem> GetAllStandardMapItemByStandardId(int standardId);

        /// <summary>
        /// 通过薪酬标准id和项目id查找映射关系
        /// </summary>
        /// <param name="standardId">标准的id</param>
        /// <param name="itemId">项目的id</param>
        /// <returns>返回对应的映射关系</returns>
        StandardMapItem GetStandardMapItemByStandardAndItem(int standardId, int itemId);

    }
}
