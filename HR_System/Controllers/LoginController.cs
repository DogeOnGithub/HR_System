using HR_SystemBLL;
using HR_SystemIBLL;
using Model;
using System.Web.Mvc;

namespace HR_System.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection formCollection)
        {

            string username = formCollection["username"];
            string password = formCollection["password"];

            TempData["usernameInput"] = username;
            TempData["passwordInput"] = password;

            ILoginUserBLL bLL = new LoginUserBLL();
            LoginUser loginUser = bLL.GetLoginUserByUsername(username);

            

            if (loginUser == null)
            {
                TempData["error"] = "Username Error";
                return RedirectToAction("Index");
            }
            else
            {

                Models.LoginUser viewLoginUser = new Models.LoginUser()
                {
                    Id = loginUser.Id,
                    Username = loginUser.Username,
                    Password = loginUser.Password,
                    RoleLevel = loginUser.RoleLevel
                };

                if (loginUser.Password == password)
                {
                    Session["loginUser"] = viewLoginUser;
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    TempData["error"] = "Password Error";
                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Logout()
        {
            if (Session["loginUser"] != null)
            {
                Session["loginUser"] = null;
            }

            return RedirectToAction("Index");
        }
    }
}