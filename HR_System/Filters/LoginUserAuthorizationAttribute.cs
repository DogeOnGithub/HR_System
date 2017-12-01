using System.Web.Mvc;

namespace HR_System.Filters
{
    /// <summary>
    /// 验证用户登录的过滤器,如果没有登录不能访问任何页面,Login页面除外
    /// </summary>
    public class LoginUserAuthorizationAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Session["LoginUser"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }
        }
    }
}