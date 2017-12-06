using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_SystemIBLL
{
    public interface ISalaryBLL
    {

        /// <summary>
        /// 获取所有薪酬标准
        /// </summary>
        /// <returns>List类型，所有薪酬标准</returns>
        List<SalaryStandard> GetAllSalaryStandard();

        /// <summary>
        /// 获取所有薪酬标准和薪酬项目的映射关系
        /// </summary>
        /// <returns>List类型，所有薪酬标准和薪酬项目的映射关系</returns>
        List<StandardMapItem> GetAllStandardMapItem();

        /// <summary>
        /// 通过id获取薪酬标准
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回id对应的薪酬标准</returns>
        SalaryStandard GetSalaryStandardById(int id);

        /// <summary>
        /// 通过薪酬标准编号获取薪酬标准，这个编号全局唯一GUID
        /// </summary>
        /// <param name="fileNumber">编号</param>
        /// <returns>返回对应的薪酬标准的id</returns>
        int GetSalaryStandardIdByfileNumber(string fileNumber);

        /// <summary>
        /// 通过薪酬标准的id获取所有的薪酬标准和薪酬项目的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>List类型，所有的映射关系</returns>
        List<StandardMapItem> GetAllStandardMapItemByStandardId(int standardId);

        /// <summary>
        /// 通过薪酬标准的id获取所有的薪酬标准和职位的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>List类型，所有的映射关系</returns>
        List<StandardMapOccupationName> GetAllStandardMapOccByStandardId(int standardId);

        /// <summary>
        /// 通过职位的id获取该职位适用的所有薪酬标准
        /// </summary>
        /// <param name="occId">职位的id</param>
        /// <returns>List类型，所有薪酬标准</returns>
        List<SalaryStandard> GetAllStandardByOccId(int occId);

        /// <summary>
        /// 保存薪酬标准和薪酬项目的映射关系
        /// </summary>
        /// <param name="standardMapItem">需要保存的映射关系</param>
        /// <returns>是否成功</returns>
        bool SaveMapItem(StandardMapItem standardMapItem);

        /// <summary>
        /// 保存薪酬标准
        /// </summary>
        /// <param name="salaryStandard">需要保存的薪酬标准</param>
        /// <returns>是否成功</returns>
        bool SaveSalaryStandard(SalaryStandard salaryStandard);

        /// <summary>
        /// 通过id删除薪酬标准
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>是否成功</returns>
        bool DeleteSalaryStandard(int id);

        /// <summary>
        /// 保存薪酬标准和职位的映射关系
        /// </summary>
        /// <param name="standardMapOccupationName">需要保存的映射关系</param>
        /// <returns>是否成功</returns>
        bool SaveMapOcc(StandardMapOccupationName standardMapOccupationName);

        /// <summary>
        /// 通过薪酬标准的id删除所有的薪酬标准与职位的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>是否成功</returns>
        bool DeleteAllOccMapByStandardId(int standardId);

    }
}
