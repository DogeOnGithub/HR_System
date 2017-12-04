using Model;

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
    }
}
