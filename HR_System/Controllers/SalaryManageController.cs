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
    public class SalaryManageController : Controller
    {
        /// <summary>
        /// 列表展示薪酬标准，再由独立控制器处理薪酬标准的具体操作
        /// </summary>
        /// <returns>返回薪酬标准的列表视图</returns>
        public ActionResult SalaryStandardManage()
        {

            //装载所有的薪酬标准

            //薪酬管理业务层
            ISalaryBLL bLL = new SalaryBLL();

            //薪酬项目管理业务层，因为薪酬标准管理和薪酬项目管理是不同模块的
            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();
            
            //获取所有的薪酬标准，这时的薪酬标准是Model中的类型
            List<SalaryStandard> standardList = bLL.GetAllSalaryStandard();

            List<Models.SalaryStandard> standardListView = new List<Models.SalaryStandard>();

            //遍历所有薪酬标准，将其转换成视图模型中的薪酬标准
            foreach (var s in standardList)
            {
                //通过薪酬标准的id获取所有的映射关系
                List<StandardMapItem> tempMapList = bLL.GetAllStandardMapItemByStandardId(s.Id);

                Models.SalaryStandard tempStandard = new Models.SalaryStandard()
                {
                    Id = s.Id,
                    StandardName = s.StandardName,
                    StandardFileNumber = s.StandardFileNumber,
                    Registrant = s.Registrant,
                    RegistTime = s.RegistTime,
                    DesignBy = s.DesignBy,
                    Total = s.Total,
                    StandardState = s.StandardState,
                    CheckDesc = s.CheckDesc,
                    CheckBy = s.CheckBy
                };

                //遍历映射关系，分拆装载进视图模型薪酬标准中的字典
                foreach (var m in tempMapList)
                {
                    SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                    Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                    tempStandard.ItemAmout.Add(salaryItemView, m.Amout);
                }

                standardListView.Add(tempStandard);
            }

            ViewData["standardListView"] = standardListView;

            return View();
        }

        /// <summary>
        /// 处理复核薪酬标准的请求
        /// </summary>
        /// <returns>返回所有待复核的薪酬标准的列表视图</returns>
        public ActionResult StandardCheck()
        {

            //装载所有待复核的薪酬标准

            //薪酬管理业务层
            ISalaryBLL bLL = new SalaryBLL();

            //薪酬项目管理业务层，因为薪酬标准管理和薪酬项目管理是不同模块的
            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            //获取所有的薪酬标准，这时的薪酬标准是Model中的类型
            List<SalaryStandard> standardList = bLL.GetAllSalaryStandardWaitCheck();

            List<Models.SalaryStandard> standardListView = new List<Models.SalaryStandard>();

            //遍历所有薪酬标准，将其转换成视图模型中的薪酬标准
            foreach (var s in standardList)
            {
                //通过薪酬标准的id获取所有的映射关系
                List<StandardMapItem> tempMapList = bLL.GetAllStandardMapItemByStandardId(s.Id);

                Models.SalaryStandard tempStandard = new Models.SalaryStandard()
                {
                    Id = s.Id,
                    StandardName = s.StandardName,
                    StandardFileNumber = s.StandardFileNumber,
                    Registrant = s.Registrant,
                    RegistTime = s.RegistTime,
                    DesignBy = s.DesignBy,
                    Total = s.Total,
                    StandardState = s.StandardState,
                    CheckDesc = s.CheckDesc,
                    CheckBy = s.CheckBy
                };

                //遍历映射关系，分拆装载进视图模型薪酬标准中的字典
                foreach (var m in tempMapList)
                {
                    SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                    Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                    tempStandard.ItemAmout.Add(salaryItemView, m.Amout);
                }

                standardListView.Add(tempStandard);
            }

            ViewData["standardListView"] = standardListView;

            return View();

        }
    }
}