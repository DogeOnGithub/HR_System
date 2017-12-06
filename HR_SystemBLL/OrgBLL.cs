using HR_SystemIBLL;
using System.Collections.Generic;
using Model;
using HR_SystemIDAL;
using HR_SystemDAL;

namespace HR_SystemBLL
{
    /// <summary>
    /// 实现IOrgBLL接口
    /// </summary>
    public class OrgBLL : IOrgBLL
    {
        public bool DeleteFirstOrgById(int id)
        {
            //throw new System.NotImplementedException();

            IFirstOrgDAL dAL = new FirstOrgDAL();

            if (dAL.Remove(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteSecondOrgById(int id)
        {
            //throw new System.NotImplementedException();

            ISecondOrgDAL dAL = new SecondOrgDAL();

            if (dAL.Remove(id) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool DeleteThirdOrgById(int id)
        {
            //throw new System.NotImplementedException();

            IThirdOrgDAL dAL = new ThirdOrgDAL();

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
        /// 实现IOrgBLL接口
        /// </summary>
        /// <returns>返回所有1级机构</returns>
        public List<FirstOrg> GetAllFirstOrg()
        {
            //throw new NotImplementedException();

            IFirstOrgDAL dAL = new FirstOrgDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <returns>返回所有2级机构</returns>
        public List<SecondOrg> GetAllSecondOrg()
        {
            //throw new NotImplementedException();

            ISecondOrgDAL dAL = new SecondOrgDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <returns>返回所有3级机构</returns>
        public List<ThirdOrg> GetAllThirdOrg()
        {
            //throw new NotImplementedException();

            IThirdOrgDAL dAL = new ThirdOrgDAL();

            return dAL.Query();

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回对应id的1级机构</returns>
        public FirstOrg GetFirstOrgById(int id)
        {
            //throw new NotImplementedException();

            IFirstOrgDAL dAL = new FirstOrgDAL();

            return dAL.QueryById(id);

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="id">1级机构的id</param>
        /// <returns>返回所欲parentId为传入id的2级机构</returns>
        public List<SecondOrg> GetSecondOrgByFirstOrgId(int id)
        {
            //throw new System.NotImplementedException();

            ISecondOrgDAL dAL = new SecondOrgDAL();

            return dAL.QueryByParentOrgId(id);

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回对应id的2级机构</returns>
        public SecondOrg GetSecondOrgById(int id)
        {
            //throw new NotImplementedException();

            ISecondOrgDAL dAL = new SecondOrgDAL();

            return dAL.QueryById(id);

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回对应id的3级机构</returns>
        public ThirdOrg GetThirdOrgById(int id)
        {
            //throw new NotImplementedException();

            IThirdOrgDAL dAL = new ThirdOrgDAL();

            return dAL.QueryById(id);

        }

        public List<ThirdOrg> GetThirdOrgBySecondOrgId(int id)
        {
            //throw new System.NotImplementedException();

            IThirdOrgDAL dAL = new ThirdOrgDAL();

            return dAL.QueryByParentOrgId(id);

        }

        /// <summary>
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="firstOrg">需要保存的FirstOrg</param>
        /// <returns>返回是否保存成功的布尔值</returns>
        public bool SaveFirstOrg(FirstOrg firstOrg)
        {
            //throw new System.NotImplementedException();

            IFirstOrgDAL dAL = new FirstOrgDAL();

            //先检查有没有该FirstOrg，如果有，则更新，没有则添加
            if (dAL.QueryById(firstOrg.Id) != null)
            {
                if (dAL.Update(firstOrg) > 0)
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
                if (dAL.Add(firstOrg) > 0)
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
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="secondOrg">需要保存的SecondOrg</param>
        /// <returns>返回是否保存成功的布尔值</returns>
        public bool SaveSecondOrg(SecondOrg secondOrg)
        {
            //throw new System.NotImplementedException();

            ISecondOrgDAL dAL = new SecondOrgDAL();

            //先检查有没有该SecondOrg，如果有，则更新，没有则添加
            if (dAL.QueryById(secondOrg.Id) != null)
            {
                if (dAL.Update(secondOrg) > 0)
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
                if (dAL.Add(secondOrg) > 0)
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
        /// 实现IOrgBLL接口
        /// </summary>
        /// <param name="thirdOrg">需要保存的ThirdOrg</param>
        /// <returns>返回是否保存成功的布尔值</returns>
        public bool SaveThirdOrg(ThirdOrg thirdOrg)
        {
            //throw new System.NotImplementedException();

            IThirdOrgDAL dAL = new ThirdOrgDAL();

            if (dAL.QueryById(thirdOrg.Id) != null)
            {
                if (dAL.Update(thirdOrg) > 0)
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
                if (dAL.Add(thirdOrg) > 0)
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
