using HR_System.Models;
using System.Web.Mvc;

namespace HR_System.Filters
{
    public class StaffNormalAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);

            LoginUser loginUser = filterContext.HttpContext.Session["LoginUser"] as LoginUser;

            if (loginUser.RoleLevel != EnumState.RoleLevelEnum.StaffNormal && loginUser.RoleLevel != EnumState.RoleLevelEnum.StaffManager && loginUser.RoleLevel != EnumState.RoleLevelEnum.SystemManager)
            {
                filterContext.Result = new HttpNotFoundResult();
            }

        }
    }
}