using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// 薪酬标准数据层接口
    /// </summary>
    public interface ISalaryStandardDAL : IHRSystemDAL<SalaryStandard>
    {
        /// <summary>
        /// 通过编号获取该薪酬标准的主键id
        /// </summary>
        /// <param name="fileNumber">编号</param>
        /// <returns>主键id</returns>
        int GetStandardIdByFileNumber(string fileNumber);

        /// <summary>
        /// 通过id删除薪酬标准
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回影响行数</returns>
        int DeleteSalaryStandard(int id);

        /// <summary>
        /// 获取所有待复核的薪酬标准
        /// </summary>
        /// <returns>List类型，所有的待复核的薪酬标准</returns>
        List<SalaryStandard> GetAllSalaryStandardWaitCheck();

        /// <summary>
        /// 通过关键字获取薪酬标准
        /// </summary>
        /// <param name="keyword">关键字</param>
        /// <returns>带有关键字的薪酬标准</returns>
        List<SalaryStandard> GetAllSalaryStandardByKeyword(string keyword);
    }
}
