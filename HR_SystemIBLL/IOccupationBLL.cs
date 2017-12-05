using Model;
using System.Collections.Generic;

namespace HR_SystemIBLL
{
    /// <summary>
    /// 职位类型及职位名称管理的业务层接口
    /// </summary>
    public interface IOccupationBLL
    {

        /// <summary>
        /// 获取所有的职位类型
        /// </summary>
        /// <returns>List类型，所有职位类型</returns>
        List<OccupationClass> GetAllOccupationClass();

        /// <summary>
        /// 获取所有职位名称
        /// </summary>
        /// <returns>List类型，所有职位名称</returns>
        List<OccupationName> GetAllOccupationName();

        /// <summary>
        /// 通过职位类型的id获取所有的职位
        /// </summary>
        /// <param name="classId">职位类型的id</param>
        /// <returns>List类型，所有该职位类型下的职位</returns>
        List<OccupationName> GetAllOccNameByClassId(int classId);

        /// <summary>
        /// 获取所有职称
        /// </summary>
        /// <returns>List类型，所有职称</returns>
        List<TechnicalTitle> GetAllTechnicalTitle();

        /// <summary>
        /// 通过Id获取职位类型
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回该id对应的职位类型</returns>
        OccupationClass GetOccupationClassById(int id);

        /// <summary>
        /// 通过Id获取职位名称
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回该id对应的职位名称</returns>
        OccupationName GetOccupationNameById(int id);

        /// <summary>
        /// 通过Id获取职称
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回对应的职称</returns>
        TechnicalTitle GetTechnicalTitleById(int id);

        /// <summary>
        /// 保存职位类型
        /// </summary>
        /// <param name="occupationClass">需要保存的职位类型,Model中的类型</param>
        /// <returns>返回是否成功的布尔值</returns>
        bool SaveOccupationClass(OccupationClass occupationClass);

        /// <summary>
        /// 保存职位
        /// </summary>
        /// <param name="occupationName">需要保存的职位，Model中的类型</param>
        /// <returns>返回是否成功的布尔值</returns>
        bool SaveOccupationName(OccupationName occupationName);

        /// <summary>
        /// 保存职称
        /// </summary>
        /// <param name="technicalTitle">需要保存的职称，Model中的类型</param>
        /// <returns>返回是否成功的布尔值</returns>
        bool SaveTechnicalTitle(TechnicalTitle technicalTitle);

        /// <summary>
        /// 通过Id删除职位类型
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否成功的布尔值</returns>
        bool DeleteOccupationClassById(int id);

        /// <summary>
        /// 通过Id删除职位
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否成功的布尔值</returns>
        bool DeleteOccupationNameById(int id);

        /// <summary>
        /// 通过Id删除职称
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回是否成功的布尔值</returns>
        bool DeleteTechnicalTitle(int id);

    }
}
