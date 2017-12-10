using HR_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_System.Filters
{
    public class SalaryManagerAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            LoginUser loginUser = filterContext.HttpContext.Session["LoginUser"] as LoginUser;

            if (loginUser.RoleLevel != EnumState.RoleLevelEnum.SalaryManager && loginUser.RoleLevel != EnumState.RoleLevelEnum.SystemManager)
            {
                filterContext.Result = new HttpNotFoundResult();
            }

        }
    }
}