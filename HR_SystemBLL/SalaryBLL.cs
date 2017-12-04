using HR_SystemIBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using HR_SystemIDAL;
using HR_SystemDAL;

namespace HR_SystemBLL
{
    public class SalaryBLL : ISalaryBLL
    {
        /// <summary>
        /// 获取所有薪酬标准
        /// </summary>
        /// <returns>List类型，所有薪酬标准</returns>
        public List<SalaryStandard> GetAllSalaryStandard()
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 获取所有薪酬标准和薪酬项目的映射关系
        /// </summary>
        /// <returns>List类型，所有薪酬标准和薪酬项目的映射关系</returns>
        public List<StandardMapItem> GetAllStandardMapItem()
        {
            //throw new NotImplementedException();

            IStandardMapItemDAL dAL = new StandardMapItemDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 通过薪酬标准的id，获取所有的标准与项目的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>List类型，所有的标准与项目的映射关系</returns>
        public List<StandardMapItem> GetAllStandardMapItemByStandardId(int standardId)
        {
            //throw new NotImplementedException();

            IStandardMapItemDAL dAL = new StandardMapItemDAL();

            return dAL.GetAllStandardMapItemByStandardId(standardId);

        }

        /// <summary>
        /// 通过id获取薪酬标准
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回id对应的薪酬标准对象</returns>
        public SalaryStandard GetSalaryStandardById(int id)
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            return dAL.QueryById(id);

        }
    }
}
