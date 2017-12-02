using HR_SystemIBLL;
using System.Collections.Generic;
using Model;
using HR_SystemIDAL;
using HR_SystemDAL;

namespace HR_SystemBLL
{
    /// <summary>
    /// 实现IOccupationBLL接口
    /// </summary>
    public class OccupationBLL : IOccupationBLL
    {
        /// <summary>
        /// 实现IOccupationBLL接口，通过id删除职位类型
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否成功的布尔值</returns>
        public bool DeleteOccupationClassById(int id)
        {
            //throw new System.NotImplementedException();

            IOccupationClassDAL dAL = new OccupationClassDAL();

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
        /// 实现IOccupationBLL接口，通过id删除职位
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否成功的布尔值</returns>
        public bool DeleteOccupationNameById(int id)
        {
            //throw new System.NotImplementedException();

            IOccupationNameDAL dAL = new OccupationNameDAL();

            if (dAL.Remove(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteTechnicalTitle(int id)
        {
            //throw new System.NotImplementedException();

            ITechnicalTitleDAL dAL = new TechnicalTitleDAL();

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
        /// 实现IOccupationBLL接口
        /// </summary>
        /// <returns>返回所有职位类别，List类型</returns>
        public List<OccupationClass> GetAllOccupationClass()
        {
            //throw new NotImplementedException();

            IOccupationClassDAL dAL = new OccupationClassDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 实现IOccupationBLL接口
        /// </summary>
        /// <returns>返回所有职位名称，List类型</returns>
        public List<OccupationName> GetAllOccupationName()
        {
            //throw new NotImplementedException();

            IOccupationNameDAL dAL = new OccupationNameDAL();

            return dAL.Query();

        }

        public List<TechnicalTitle> GetAllTechnicalTitle()
        {
            //throw new System.NotImplementedException();

            ITechnicalTitleDAL dAL = new TechnicalTitleDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 实现IOccupationBLL接口
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回id对应的职位类型</returns>
        public OccupationClass GetOccupationClassById(int id)
        {
            //throw new NotImplementedException();

            IOccupationClassDAL dAL = new OccupationClassDAL();

            return dAL.QueryById(id);

        }

        /// <summary>
        /// 实现IOccupationBLL接口
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回id对应的职位名称</returns>
        public OccupationName GetOccupationNameById(int id)
        {
            //throw new NotImplementedException();

            IOccupationNameDAL dAL = new OccupationNameDAL();

            return dAL.QueryById(id);

        }

        public TechnicalTitle GetTechnicalTitleById(int id)
        {
            //throw new System.NotImplementedException();

            ITechnicalTitleDAL dAL = new TechnicalTitleDAL();

            return dAL.QueryById(id);

        }

        /// <summary>
        /// 实现IOccupationBLL接口
        /// </summary>
        /// <param name="occupationClass">需要保存的职位类型</param>
        /// <returns>返回是否成功的布尔值</returns>
        public bool SaveOccupationClass(OccupationClass occupationClass)
        {
            //throw new System.NotImplementedException();

            IOccupationClassDAL dAL = new OccupationClassDAL();

            //先检查有没有该职位类型,如果有,则更新记录,如果没有,则添加
            if (dAL.QueryById(occupationClass.Id) != null)
            {
                if(dAL.Update(occupationClass) > 0)
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
                if(dAL.Add(occupationClass) > 0)
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
        /// 实现IOccupationBLL接口
        /// </summary>
        /// <param name="occupationName">需要保存的职位</param>
        /// <returns>返回是否成功的布尔值</returns>
        public bool SaveOccupationName(OccupationName occupationName)
        {
            //throw new System.NotImplementedException();

            IOccupationNameDAL dAL = new OccupationNameDAL();

            //检查是否有记录存在
            if (dAL.QueryById(occupationName.Id) != null)
            {
                if (dAL.Update(occupationName) > 0)
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
                if (dAL.Add(occupationName) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }

        public bool SaveTechnicalTitle(TechnicalTitle technicalTitle)
        {
            //throw new System.NotImplementedException();

            ITechnicalTitleDAL dAL = new TechnicalTitleDAL();

            if (dAL.QueryById(technicalTitle.Id) != null)
            {
                if (dAL.Update(technicalTitle) > 0)
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
                if (dAL.Add(technicalTitle) > 0)
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
