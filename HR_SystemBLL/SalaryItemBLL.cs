using HR_SystemIBLL;
using System.Collections.Generic;
using Model;
using HR_SystemIDAL;
using HR_SystemDAL;

namespace HR_SystemBLL
{
    public class SalaryItemBLL : ISalaryItemBLL
    {
        /// <summary>
        /// 通过id删除薪酬项目
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>是否成功</returns>
        public bool DeleteSalaryItemById(int id)
        {
            //throw new NotImplementedException();

            ISalaryItemDAL dAL = new SalaryItemDAL();

            if (dAL.Remove(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 获取所有薪酬项目
        /// </summary>
        /// <returns>List类型,所有薪酬项目</returns>
        public List<SalaryItem> GetAllSalaryItem()
        {
            //throw new NotImplementedException();

            ISalaryItemDAL dAL = new SalaryItemDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 通过id获取薪酬项目
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>薪酬项目对象</returns>
        public SalaryItem GetSalaryItemById(int id)
        {
            //throw new NotImplementedException();

            ISalaryItemDAL dAL = new SalaryItemDAL();

            return dAL.QueryById(id);

        }

        /// <summary>
        /// 保存薪酬项目
        /// </summary>
        /// <param name="salaryItem">需要保存的薪酬项目</param>
        /// <returns>是否成功</returns>
        public bool SaveSalaryItem(SalaryItem salaryItem)
        {
            //throw new NotImplementedException();

            ISalaryItemDAL dAL = new SalaryItemDAL();

            if (dAL.QueryById(salaryItem.Id) != null)
            {
                if (dAL.Update(salaryItem) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (dAL.Add(salaryItem) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
