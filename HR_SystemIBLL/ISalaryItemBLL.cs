using Model;
using System.Collections.Generic;

namespace HR_SystemIBLL
{
    /// <summary>
    /// 薪酬项目管理业务层接口
    /// </summary>
    public interface ISalaryItemBLL
    {

        /// <summary>
        /// 获取所有薪酬项目
        /// </summary>
        /// <returns>List类型,所有薪酬项目</returns>
        List<SalaryItem> GetAllSalaryItem();

        /// <summary>
        /// 通过id获取薪酬项目
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>薪酬项目对象</returns>
        SalaryItem GetSalaryItemById(int id);

        /// <summary>
        /// 保存薪酬项目
        /// </summary>
        /// <param name="salaryItem">需要保存的项目</param>
        /// <returns>是否成功</returns>
        bool SaveSalaryItem(SalaryItem salaryItem);

        /// <summary>
        /// 通过id删除薪酬项目
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>是否成功</returns>
        bool DeleteSalaryItemById(int id);

    }
}
