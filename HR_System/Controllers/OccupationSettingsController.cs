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
    public class OccupationSettingsController : Controller
    {
       
        // 处理编辑职位类型请求
        public ActionResult EditOccupationClass(string id)
        {

            IOccupationBLL bLL = new OccupationBLL();

            OccupationClass occupationClass = bLL.GetOccupationClassById(Convert.ToInt32(id));

            Models.OccupationClass occupationClassView = new Models.OccupationClass
            {
                Id = occupationClass.Id,
                Name = occupationClass.Name
            };

            ViewData["occupationClassView"] = occupationClassView;

            return View();
        }

        //处理保存职位类型请求
        public ActionResult SaveOccupationClass(string OccpationClassId, string OccpationClassName)
        {
            IOccupationBLL bLL = new OccupationBLL();

            OccupationClass occupationClass = new OccupationClass { Id = Convert.ToInt32(OccpationClassId), Name = OccpationClassName };

            if (bLL.SaveOccupationClass(occupationClass))
            {
                TempData["info"] = "保存成功";
                return Redirect("/Settings/OccupationSettings");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }



        //处理编辑职位请求
        public ActionResult EditOccupationName(string id)
        {

            IOccupationBLL bLL = new OccupationBLL();

            OccupationName occupationName = bLL.GetOccupationNameById(Convert.ToInt32(id));

            Models.OccupationName occupationNameView = new Models.OccupationName
            {
                Id = occupationName.Id,
                Name = occupationName.Name
            };

            OccupationClass occupationClass = bLL.GetOccupationClassById(occupationName.ClassId);

            Models.OccupationClass occupationClassView = new Models.OccupationClass
            {
                Id = occupationClass.Id,
                Name = occupationClass.Name
            };

            occupationNameView.OccupationClass = occupationClassView;

            ViewData["occupationNameView"] = occupationNameView;


            //装载所有的职位类型，用于职位类型选择的下拉框
            List<Models.OccupationClass> occupationClassList = new List<Models.OccupationClass>();

            foreach (var oc in bLL.GetAllOccupationClass())
            {
                Models.OccupationClass tempOccupationClass = new Models.OccupationClass
                {
                    Id = oc.Id,
                    Name = oc.Name
                };
                occupationClassList.Add(tempOccupationClass);
            }

            ViewData["occupationClassList"] = occupationClassList;

            return View();
        }

        //处理保存职位请求
        public ActionResult SaveOccupationName(string OccpationNameId, string OccpationName, string classId)
        {

            IOccupationBLL bLL = new OccupationBLL();

            OccupationName occupationName = new OccupationName { Id = Convert.ToInt32(OccpationNameId), Name = OccpationName, ClassId = Convert.ToInt32(classId) };

            if (bLL.SaveOccupationName(occupationName))
            {
                TempData["info"] = "保存成功";
                return Redirect("/Settings/OccupationSettings");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }



        //删除职位
        public ActionResult DeleteOccuptaionName(string id)
        {

            IOccupationBLL bLL = new OccupationBLL();

            if (bLL.DeleteOccupationNameById(Convert.ToInt32(id)))
            {
                TempData["info"] = "已删除";
                return Redirect("/Settings/OccupationSettings");
            }
            else
            {
                TempData["error"] = "删除失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }

        //删除职位类型
        public ActionResult DeleteOccupationClass(string id)
        {
            IOccupationBLL bLL = new OccupationBLL();

            if (bLL.DeleteOccupationClassById(Convert.ToInt32(id)))
            {
                TempData["info"] = "已删除";
                return Redirect("/Settings/OccupationSettings");
            }
            else
            {
                TempData["error"] = "删除失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }



        //添加职位类型
        public ActionResult AddOccupationClass()
        {
            return View();
        }

        //添加职位
        public ActionResult AddOccupationName()
        {

            IOccupationBLL bLL = new OccupationBLL();

            //装载所有职位类型，作为下拉选择框
            List<Models.OccupationClass> occupationgClassList = new List<Models.OccupationClass>();

            foreach (var oc in bLL.GetAllOccupationClass())
            {
                Models.OccupationClass tempClass = new Models.OccupationClass
                {
                    Id = oc.Id,
                    Name = oc.Name
                };
                occupationgClassList.Add(tempClass);
            }

            ViewData["occupationClassList"] = occupationgClassList;


            return View();
        }

    }
}