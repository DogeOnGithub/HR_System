using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    public interface IThirdOrgDAL : IHRSystemDAL<ThirdOrg>
    {

        /// <summary>
        /// 通过parentOrgId（即2级机构的id），查找所有该2级机构下的3级机构
        /// </summary>
        /// <param name="parentOrgId">2级机构的Id</param>
        /// <returns>返回所有指定2级机构下的3级机构，List类型</returns>
        List<ThirdOrg> QueryByParentOrgId(int parentOrgId);

    }
}
