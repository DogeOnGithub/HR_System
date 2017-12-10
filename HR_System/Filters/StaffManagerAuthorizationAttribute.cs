using HR_System.Models;
using System.Web.Mvc;

namespace HR_System.Filters
{
    /// <summary>
    /// 验证人事经理权限的过滤器
    /// </summary>
    public class StaffManagerAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            LoginUser loginUser = filterContext.HttpContext.Session["LoginUser"] as LoginUser;

            if (loginUser.RoleLevel != EnumState.RoleLevelEnum.StaffManager && loginUser.RoleLevel != EnumState.RoleLevelEnum.SystemManager)
            {
                filterContext.Result = new HttpNotFoundResult();
            }

        }
    }
}