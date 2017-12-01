using HR_System.Models;
using System.Web.Mvc;

namespace HR_System.Filters
{
    /// <summary>
    /// 验证系统管理员权限的过滤器
    /// </summary>
    public class SystemManagerAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            if ((filterContext.HttpContext.Session["LoginUser"] as LoginUser).RoleLevel < EnumState.RoleLevelEnum.SystemManager)
            {
                filterContext.Result = new HttpNotFoundResult();
            }

        }
    }
}