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
        /// 通过薪酬标准的编号获取薪酬标准的id
        /// </summary>
        /// <param name="fileNumber">编号</param>
        /// <returns>薪酬标准的id</returns>
        public int GetSalaryStandardIdByfileNumber(string fileNumber)
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            return dAL.GetStandardIdByFileNumber(fileNumber);

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

        /// <summary>
        /// 保存映射关系
        /// </summary>
        /// <param name="standardMapItem">需要保存的映射关系</param>
        /// <returns>是否成功</returns>
        public bool SaveMapItem(StandardMapItem standardMapItem)
        {
            //throw new NotImplementedException();

            IStandardMapItemDAL dAL = new StandardMapItemDAL();

            StandardMapItem tempMap = dAL.GetStandardMapItemByStandardAndItem(standardMapItem.StandardId, standardMapItem.ItemId);

            if (tempMap != null)
            {
                standardMapItem.Id = tempMap.Id;
                if (dAL.Update(standardMapItem) > 0)
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
                if (dAL.Add(standardMapItem) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// 保存薪酬标准
        /// </summary>
        /// <param name="salaryStandard">需要保存的薪酬标准</param>
        /// <returns>是否成功</returns>
        public bool SaveSalaryStandard(SalaryStandard salaryStandard)
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            if (dAL.QueryById(salaryStandard.Id) != null)
            {
                if (dAL.Update(salaryStandard) > 0)
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
                if (dAL.Add(salaryStandard) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// 通过id删除薪酬标准
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>是否成功</returns>
        public bool DeleteSalaryStandard(int id)
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            if (dAL.DeleteSalaryStandard(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 通过薪酬标准的id获取所有的薪酬标准与职位的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>List类型，所有的薪酬标准与职位的映射关系</returns>
        public List<StandardMapOccupationName> GetAllStandardMapOccByStandardId(int standardId)
        {
            //throw new NotImplementedException();

            IStandardMapOccupationNameDAL dAL = new StandardMapOccupationNameDAL();

            return dAL.GetAllMapByStandardId(standardId);

        }

        /// <summary>
        /// 保存薪酬标准和职位的映射关系
        /// </summary>
        /// <param name="standardMapOccupationName">需要保存的映射关系</param>
        /// <returns>是否成功</returns>
        public bool SaveMapOcc(StandardMapOccupationName standardMapOccupationName)
        {
            //throw new NotImplementedException();

            IStandardMapOccupationNameDAL dAL = new StandardMapOccupationNameDAL();

            StandardMapOccupationName tempMap = dAL.QueryById(standardMapOccupationName.Id);

            if (tempMap != null)
            {
                standardMapOccupationName.Id = tempMap.Id;
                if (dAL.Update(standardMapOccupationName) > 0)
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
                if (dAL.Add(standardMapOccupationName) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        /// <summary>
        /// 通过薪酬id删除薪酬标准和职位的映射关系
        /// </summary>
        /// <param name="standardId">薪酬标准的id</param>
        /// <returns>是否成功</returns>
        public bool DeleteAllOccMapByStandardId(int standardId)
        {
            //throw new NotImplementedException();

            IStandardMapOccupationNameDAL dAL = new StandardMapOccupationNameDAL();

            if (dAL.DeleteAllOccMapByStandardId(standardId) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 通过职位获取所有薪酬标准
        /// </summary>
        /// <param name="occId">职位id</param>
        /// <returns>所有该职位适用的薪酬标准</returns>
        public List<SalaryStandard> GetAllStandardByOccId(int occId)
        {
            //throw new NotImplementedException();

            IStandardMapOccupationNameDAL dAL = new StandardMapOccupationNameDAL();

            return dAL.GetAllStandardByOccId(occId);

        }

        /// <summary>
        /// 获取所有待复核的薪酬标准
        /// </summary>
        /// <returns>List类型，所有的待复核的薪酬标准</returns>
        public List<SalaryStandard> GetAllSalaryStandardWaitCheck()
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            return dAL.GetAllSalaryStandardWaitCheck();

        }

        public List<SalaryStandard> GetAllSalaryStandardByKeyword(string keyword)
        {
            //throw new NotImplementedException();

            ISalaryStandardDAL dAL = new SalaryStandardDAL();

            return dAL.GetAllSalaryStandardByKeyword(keyword);

        }
    }
}
