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
    public class StandardManageController : Controller
    {
        public ActionResult DetailSalaryStandard(string id)
        {

            ISalaryBLL salaryBLL = new SalaryBLL();

            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            //通过id查找到薪酬标准
            SalaryStandard salaryStandard = salaryBLL.GetSalaryStandardById(Convert.ToInt32(id));

            //视图模型薪酬标准
            Models.SalaryStandard salaryStandardView = new Models.SalaryStandard
            {
                Id = salaryStandard.Id,
                StandardName = salaryStandard.StandardName,
                StandardFileNumber = salaryStandard.StandardFileNumber,
                Registrant = salaryStandard.Registrant,
                RegistTime = salaryStandard.RegistTime,
                DesignBy = salaryStandard.DesignBy,
                Total = salaryStandard.Total,
                StandardState = salaryStandard.StandardState,
                CheckDesc = salaryStandard.CheckDesc,
                CheckBy = salaryStandard.CheckBy
            };

            //通过薪酬标准的id找到所有的项目映射关系
            List<StandardMapItem> tempMapList = salaryBLL.GetAllStandardMapItemByStandardId(salaryStandard.Id);

            //遍历映射关系，并把薪酬项目和薪酬项目的金额装载到视图模型薪酬标准的字典中
            foreach (var m in tempMapList)
            {
                SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                salaryStandardView.ItemAmout.Add(salaryItemView, m.Amout);
            }

            ViewData["salaryStandardView"] = salaryStandardView;

            return View();
        }
    }
}