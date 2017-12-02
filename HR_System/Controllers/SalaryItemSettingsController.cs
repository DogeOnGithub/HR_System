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
    public class SalaryItemSettingsController : Controller
    {
        /// <summary>
        /// 处理编辑薪酬项目的请求
        /// </summary>
        /// <param name="id">薪酬项目的id</param>
        /// <returns>重定向到编辑视图</returns>
        public ActionResult EditSalatyItem(string id)
        {

            ISalaryItemBLL bLL = new SalaryItemBLL();

            SalaryItem salaryItem = bLL.GetSalaryItemById(Convert.ToInt32(id));

            Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = salaryItem.Id, Name = salaryItem.Name };

            ViewData["salaryItemView"] = salaryItemView;

            return View();

        }

        /// <summary>
        /// 处理保存薪酬项目的请求,添加或编辑的提交都往这个请求
        /// </summary>
        /// <param name="ItemId">主键Id,由隐藏域提交或不提交,用户无法编辑</param>
        /// <param name="ItemName">薪酬项目名称,用户填写</param>
        /// <returns>设置消息提示并重定向</returns>
        public ActionResult SaveSalaryItem(string ItemId, string ItemName)
        {

            ISalaryItemBLL bLL = new SalaryItemBLL();

            SalaryItem salaryItem = new SalaryItem { Id = Convert.ToInt32(ItemId), Name = ItemName };

            if (bLL.SaveSalaryItem(salaryItem))
            {
                TempData["info"] = "保存成功";
                return Redirect("/Settings/SalaryItemSettings");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }

        /// <summary>
        /// 处理添加薪酬项目的请求
        /// </summary>
        /// <returns>返回添加薪酬项目的页面</returns>
        public ActionResult AddSalaryItem()
        {
            return View();
        }

        /// <summary>
        /// 处理删除薪酬项目的请求
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>重定向并设置提示信息</returns>
        public ActionResult DeleteSalaryItem(string id)
        {

            ISalaryItemBLL bLL = new SalaryItemBLL();

            if (bLL.DeleteSalaryItemById(Convert.ToInt32(id)))
            {
                TempData["info"] = "已删除";
                return Redirect("/Settings/SalaryItemSettings");
            }
            else
            {
                TempData["error"] = "删除失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }
    }
}