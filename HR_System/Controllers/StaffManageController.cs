using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_System.Filters;

namespace HR_System.Controllers
{
    [LoginUserAuthorization]
    public class StaffManageController : Controller
    {
        /// <summary>
        /// 处理档案登记请求
        /// </summary>
        /// <returns>返回档案登记视图</returns>
        public ActionResult StaffRegist()
        {
            return View();
        }
    }
}