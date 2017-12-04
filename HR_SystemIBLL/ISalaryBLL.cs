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
        /// 通过薪酬标准的id获取所有的薪酬标准和薪酬项目的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>List类型，所有的映射关系</returns>
        List<StandardMapItem> GetAllStandardMapItemByStandardId(int standardId);

    }
}
