using HR_System.Filters;
using HR_SystemBLL;
using HR_SystemIBLL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_System.Controllers
{
    [LoginUserAuthorization]
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Index()
        {
            return View();
        }

    }
}