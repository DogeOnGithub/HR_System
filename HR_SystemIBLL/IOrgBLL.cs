using Model;
using System.Collections.Generic;

namespace HR_SystemIBLL
{
    /// <summary>
    /// 机构管理业务层接口
    /// </summary>
    public interface IOrgBLL
    {

        /// <summary>
        /// 获取所有1级机构
        /// </summary>
        /// <returns>List类型，所有1级机构</returns>
        List<FirstOrg> GetAllFirstOrg();

        /// <summary>
        /// 获取所有2级机构
        /// </summary>
        /// <returns>List类型，所有2级机构</returns>
        List<SecondOrg> GetAllSecondOrg();

        /// <summary>
        /// 获取所有3级机构
        /// </summary>
        /// <returns>List类型，所有3级机构</returns>
        List<ThirdOrg> GetAllThirdOrg();

        /// <summary>
        /// 通过Id获取1级机构
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回该id对应的1级机构</returns>
        FirstOrg GetFirstOrgById(int id);

        /// <summary>
        /// 通过Id获取2级机构
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回该id对应的2级机构</returns>
        SecondOrg GetSecondOrgById(int id);

        /// <summary>
        /// 通过Id获取3级机构
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回该id对应的3级机构</returns>
        ThirdOrg GetThirdOrgById(int id);

        /// <summary>
        /// 保存FirstOrg，即，该方法可以Update也可以Add
        /// </summary>
        /// <param name="firstOrg">需要保存的FirstOrg</param>
        /// <returns>返回是否保存成功的布尔值</returns>
        bool SaveFirstOrg(FirstOrg firstOrg);

        /// <summary>
        /// 保存SecondOrg，即，该方法可以Update也可以Add
        /// </summary>
        /// <param name="secondOrg">需要保存的SecondOrg</param>
        /// <returns>返回是否保存成功的布尔值</returns>
        bool SaveSecondOrg(SecondOrg secondOrg);

        /// <summary>
        /// 保存ThirdOrg，即，该方法可以Update也可以Add
        /// </summary>
        /// <param name="thirdOrg">需要保存的ThirdOrg</param>
        /// <returns>返回是否保存成功的布尔值</returns>
        bool SaveThirdOrg(ThirdOrg thirdOrg);

        /// <summary>
        /// 通过1级机构的id获取2级机构
        /// </summary>
        /// <param name="id">1级机构id</param>
        /// <returns>返回所有parentId为传入1级机构id的2级机构</returns>
        List<SecondOrg> GetSecondOrgByFirstOrgId(int id);

        /// <summary>
        /// 通过2级机构的id获取3级机构
        /// </summary>
        /// <param name="id">2级机构的id</param>
        /// <returns>返回所有parentId为传入2级机构id的3级机构</returns>
        List<ThirdOrg> GetThirdOrgBySecondOrgId(int id);

        /// <summary>
        /// 通过id删除1级机构
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否删除成功</returns>
        bool DeleteFirstOrgById(int id);

        /// <summary>
        /// 通过id删除2级机构
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否删除成功</returns>
        bool DeleteSecondOrgById(int id);

        /// <summary>
        /// 通过id删除3级机构
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否删除成功</returns>
        bool DeleteThirdOrgById(int id);

    }
}
