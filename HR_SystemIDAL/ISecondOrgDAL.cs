using Model;
using System.Collections.Generic;

namespace HR_SystemIDAL
{
    /// <summary>
    /// SecondOrg表数据访问层接口
    /// </summary>
    public interface ISecondOrgDAL : IHRSystemDAL<SecondOrg>
    {

        /// <summary>
        /// 通过parentOrgId（即1级机构的id），查找所有该1级机构下的2级机构
        /// </summary>
        /// <param name="parentOrgId">1级机构的Id</param>
        /// <returns>返回所有指定1级机构下的2级机构，List类型</returns>
        List<SecondOrg> QueryByParentOrgId(int parentOrgId);

    }
}
