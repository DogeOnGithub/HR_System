using HR_System.Filters;
using HR_SystemBLL;
using HR_SystemIBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_System.Controllers
{
    [LoginUserAuthorization]
    [SystemManagerAuthorization]
    public class SettingsController : Controller
    {
        /// <summary>
        /// 处理机构管理请求
        /// </summary>
        /// <returns>返回视图,包含所有机构的信息</returns>
        public ActionResult OrgSettings()
        {

            IOrgBLL bLL = new OrgBLL();

            //装载所有1级机构
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();

            foreach (var fo in bLL.GetAllFirstOrg())
            {
                Models.FirstOrg firstOrg = new Models.FirstOrg
                {
                    Id = fo.Id,
                    OrgName = fo.OrgName,
                    OrgLevel = fo.OrgLevel
                };
                firstOrgList.Add(firstOrg);
            }

            ViewData["firstOrgList"] = firstOrgList;


            //装载所有2级机构
            List<Models.SecondeOrg> secondOrgList = new List<Models.SecondeOrg>();

            foreach (var so in bLL.GetAllSecondOrg())
            {
                Models.SecondeOrg secondeOrg = new Models.SecondeOrg
                {
                    Id = so.Id,
                    OrgName = so.OrgName,
                    OrgLevel = so.OrgLevel,
                };
                FirstOrg tempFirstOrg = bLL.GetFirstOrgById(so.ParentOrgId);
                secondeOrg.ParentOrg = new Models.FirstOrg
                {
                    Id = tempFirstOrg.Id,
                    OrgName = tempFirstOrg.OrgName,
                    OrgLevel = tempFirstOrg.OrgLevel
                };
                secondOrgList.Add(secondeOrg);
            }

            ViewData["secondOrgList"] = secondOrgList;


            //装载所有3级机构
            List<Models.ThirdOrg> thirdOrgList = new List<Models.ThirdOrg>();

            foreach (var to in bLL.GetAllThirdOrg())
            {
                Models.ThirdOrg thirdOrg = new Models.ThirdOrg
                {
                    Id = to.Id,
                    OrgName = to.OrgName,
                    OrgLevel = to.OrgLevel,
                };
                SecondOrg tempSecondeOrg = bLL.GetSecondOrgById(to.ParentOrgId);
                FirstOrg tempFirstOrg = bLL.GetFirstOrgById(tempSecondeOrg.ParentOrgId);
                thirdOrg.ParentOrg = new Models.SecondeOrg
                {
                    Id = tempSecondeOrg.Id,
                    OrgName = tempSecondeOrg.OrgName,
                    OrgLevel = tempSecondeOrg.OrgLevel,
                    ParentOrg = new Models.FirstOrg { Id = tempFirstOrg.Id, OrgLevel = tempFirstOrg.OrgLevel, OrgName = tempFirstOrg.OrgName }
                };
                thirdOrgList.Add(thirdOrg);
            }

            ViewData["thirdOrgList"] = thirdOrgList;

            return View();
        }

        /// <summary>
        /// 处理职位管理请求
        /// </summary>
        /// <returns>返回视图,包含所有职位信息</returns>
        public ActionResult OccupationSettings()
        {

            IOccupationBLL bLL = new OccupationBLL();

            //装载所有职位类型
            List<Models.OccupationClass> occupationClassList = new List<Models.OccupationClass>();

            foreach (var oc in bLL.GetAllOccupationClass())
            {
                Models.OccupationClass occupationClass = new Models.OccupationClass
                {
                    Id = oc.Id,
                    Name = oc.Name
                };
                occupationClassList.Add(occupationClass);
            }

            ViewData["occupationClassList"] = occupationClassList;


            //装载所有职位名称
            List<Models.OccupationName> occupationNameList = new List<Models.OccupationName>();

            foreach (var on in bLL.GetAllOccupationName())
            {
                Models.OccupationName occupationName = new Models.OccupationName
                {
                    Id = on.Id,
                    Name = on.Name
                };
                OccupationClass tempClass = bLL.GetOccupationClassById(on.ClassId);
                occupationName.OccupationClass = new Models.OccupationClass
                {
                    Id = tempClass.Id,
                    Name = tempClass.Name
                };
                occupationNameList.Add(occupationName);
            }

            ViewData["occupationNameList"] = occupationNameList;

            return View();
        }

        /// <summary>
        /// 处理职称管理请求
        /// </summary>
        /// <returns>返回视图,包含所有职称信息</returns>
        public ActionResult TitleSettings()
        {

            IOccupationBLL bLL = new OccupationBLL();

            //装载所有职称信息
            List<Models.TechnicalTitle> titleList = new List<Models.TechnicalTitle>();

            foreach (var tt in bLL.GetAllTechnicalTitle())
            {
                Models.TechnicalTitle tempTitle = new Models.TechnicalTitle { Id = tt.Id, Name = tt.Name };
                titleList.Add(tempTitle);
            }

            ViewData["titleList"] = titleList;

            return View();
        }

        /// <summary>
        /// 处理薪酬项目管理请求
        /// </summary>
        /// <returns>返回视图,包含所有薪酬项目信息</returns>
        public ActionResult SalaryItemSettings()
        {

            ISalaryItemBLL bLL = new SalaryItemBLL();

            //装载所有薪酬项目信息
            List<Models.SalaryItem> itemList = new List<Models.SalaryItem>();

            foreach (var si in bLL.GetAllSalaryItem())
            {
                Models.SalaryItem tempItem = new Models.SalaryItem
                {
                    Id = si.Id,
                    Name = si.Name
                };
                itemList.Add(tempItem);
            }

            ViewData["itemList"] = itemList;

            return View();

        }
    }
}