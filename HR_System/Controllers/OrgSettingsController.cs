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
    public class OrgSettingsController : Controller
    {
        [SystemManagerAuthorization]
        public ActionResult EditFirstOrg(string id)
        {

            IOrgBLL bLL = new OrgBLL();

            FirstOrg firstOrg = bLL.GetFirstOrgById(Convert.ToInt32(id));

            Models.FirstOrg firstOrgView = new Models.FirstOrg { Id = firstOrg.Id, OrgName = firstOrg.OrgName, OrgLevel = firstOrg.OrgLevel };

            ViewData["firstOrgView"] = firstOrgView;

            return View();
        }

        [SystemManagerAuthorization]
        public ActionResult SaveFirstOrg(string FirstOrgId, string FirstOrgName, string FirstOrgLevel)
        {

            IOrgBLL bLL = new OrgBLL();

            FirstOrg firstOrg = new FirstOrg { Id = Convert.ToInt32(FirstOrgId), OrgName = FirstOrgName, OrgLevel = Convert.ToInt32(FirstOrgLevel) };

            if (bLL.SaveFirstOrg(firstOrg))
            {
                TempData["info"] = "保存成功";
                return Redirect("/Settings/OrgSettings");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }



        [SystemManagerAuthorization]
        public ActionResult EditSecondOrg(string id)
        {

            IOrgBLL bLL = new OrgBLL();

            SecondOrg secondOrg = bLL.GetSecondOrgById(Convert.ToInt32(id));

            Models.SecondeOrg secondeOrgView = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel };

            FirstOrg firstOrg = bLL.GetFirstOrgById(secondOrg.ParentOrgId);

            Models.FirstOrg firstOrgView = new Models.FirstOrg { Id = firstOrg.Id, OrgName = firstOrg.OrgName, OrgLevel = firstOrg.OrgLevel };

            secondeOrgView.ParentOrg = firstOrgView;

            ViewData["secondeOrgView"] = secondeOrgView;


            //装载所有1级机构，用于所属机构选择下拉框
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();

            foreach (var fo in bLL.GetAllFirstOrg())
            {
                Models.FirstOrg tempFirstOrg = new Models.FirstOrg { Id = fo.Id, OrgName = fo.OrgName, OrgLevel = fo.OrgLevel };
                firstOrgList.Add(tempFirstOrg);
            }

            ViewData["firstOrgList"] = firstOrgList;

            return View();

        }

        [SystemManagerAuthorization]
        public ActionResult SaveSecondOrg(string SecondOrgId, string SecondOrgName, string SecondOrgLevel, string parentOrgId)
        {

            IOrgBLL bLL = new OrgBLL();

            SecondOrg secondOrg = new SecondOrg { Id = Convert.ToInt32(SecondOrgId), OrgName = SecondOrgName, OrgLevel = Convert.ToInt32(SecondOrgLevel), ParentOrgId = Convert.ToInt32(parentOrgId) };

            if (bLL.SaveSecondOrg(secondOrg))
            {
                TempData["info"] = "保存成功";
                return Redirect("/Settings/OrgSettings");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }



        [SystemManagerAuthorization]
        public ActionResult EditThirdOrg(string id)
        {

            IOrgBLL bLL = new OrgBLL();

            ThirdOrg thirdOrg = bLL.GetThirdOrgById(Convert.ToInt32(id));

            Models.ThirdOrg thirdOrgView = new Models.ThirdOrg { Id = thirdOrg.Id, OrgName = thirdOrg.OrgName, OrgLevel = thirdOrg.OrgLevel };

            //找出3级机构的所属2级机构
            SecondOrg secondOrg = bLL.GetSecondOrgById(thirdOrg.ParentOrgId);

            Models.SecondeOrg secondOrgView = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel };

            thirdOrgView.ParentOrg = secondOrgView;

            //找出3级机构的所属2级机构的所属1级机构
            FirstOrg firstOrg = bLL.GetFirstOrgById(secondOrg.ParentOrgId);

            secondOrgView.ParentOrg = new Models.FirstOrg { Id = firstOrg.Id, OrgName = firstOrg.OrgName, OrgLevel = firstOrg.OrgLevel };

            ViewData["thirdOrgView"] = thirdOrgView;


            //装载所有2级机构，用于下拉框
            List<Models.SecondeOrg> secondOrgList = new List<Models.SecondeOrg>();
            foreach (var so in bLL.GetAllSecondOrg())
            {
                Models.SecondeOrg tempSecondOrg = new Models.SecondeOrg
                {
                    Id = so.Id,
                    OrgName = so.OrgName,
                    OrgLevel = so.OrgLevel
                };
                FirstOrg tempFirstOrg = bLL.GetFirstOrgById(so.ParentOrgId);
                tempSecondOrg.ParentOrg = new Models.FirstOrg { Id = tempFirstOrg.Id, OrgName = tempFirstOrg.OrgName, OrgLevel = tempFirstOrg.OrgLevel };
                secondOrgList.Add(tempSecondOrg);
            }
            ViewData["secondOrgList"] = secondOrgList;

            //装载所有1级机构，用于所属机构选择下拉框
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();

            foreach (var fo in bLL.GetAllFirstOrg())
            {
                Models.FirstOrg tempFirstOrg = new Models.FirstOrg { Id = fo.Id, OrgName = fo.OrgName, OrgLevel = fo.OrgLevel };
                firstOrgList.Add(tempFirstOrg);
            }

            ViewData["firstOrgList"] = firstOrgList;

            return View();
        }

        [SystemManagerAuthorization]
        public ActionResult SaveThirdOrg(string ThirdOrgId, string ThirdOrgName, string ThirdOrgLevel, string secondOrg)
        {

            IOrgBLL bLL = new OrgBLL();

            ThirdOrg thirdOrg = new ThirdOrg { Id = Convert.ToInt32(ThirdOrgId), OrgName = ThirdOrgName, OrgLevel = Convert.ToInt32(ThirdOrgLevel), ParentOrgId = Convert.ToInt32(secondOrg) };

            if (bLL.SaveThirdOrg(thirdOrg))
            {
                TempData["info"] = "保存成功";
                return Redirect("/Settings/OrgSettings");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }





        [SystemManagerAuthorization]
        public ActionResult AddFirstOrg()
        {
            return View();
        }

        [SystemManagerAuthorization]
        public ActionResult AddSecondOrg()
        {
            IOrgBLL bLL = new OrgBLL();

            //装载所有2级机构，用于下拉框
            //List<Models.SecondeOrg> secondOrgList = new List<Models.SecondeOrg>();
            //foreach (var so in bLL.GetAllSecondOrg())
            //{
            //    Models.SecondeOrg tempSecondOrg = new Models.SecondeOrg
            //    {
            //        Id = so.Id,
            //        OrgName = so.OrgName,
            //        OrgLevel = so.OrgLevel
            //    };
            //    FirstOrg tempFirstOrg = bLL.GetFirstOrgById(so.ParentOrgId);
            //    tempSecondOrg.ParentOrg = new Models.FirstOrg { Id = tempFirstOrg.Id, OrgName = tempFirstOrg.OrgName, OrgLevel = tempFirstOrg.OrgLevel };
            //    secondOrgList.Add(tempSecondOrg);
            //}
            //ViewData["secondOrgList"] = secondOrgList;

            //装载所有1级机构，用于所属机构选择下拉框
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();

            foreach (var fo in bLL.GetAllFirstOrg())
            {
                Models.FirstOrg tempFirstOrg = new Models.FirstOrg { Id = fo.Id, OrgName = fo.OrgName, OrgLevel = fo.OrgLevel };
                firstOrgList.Add(tempFirstOrg);
            }

            ViewData["firstOrgList"] = firstOrgList;

            return View();
        }

        [SystemManagerAuthorization]
        public ActionResult AddThirdOrg()
        {

            IOrgBLL bLL = new OrgBLL();

            //装载所有2级机构，用于下拉框
            List<Models.SecondeOrg> secondOrgList = new List<Models.SecondeOrg>();
            foreach (var so in bLL.GetAllSecondOrg())
            {
                Models.SecondeOrg tempSecondOrg = new Models.SecondeOrg
                {
                    Id = so.Id,
                    OrgName = so.OrgName,
                    OrgLevel = so.OrgLevel
                };
                FirstOrg tempFirstOrg = bLL.GetFirstOrgById(so.ParentOrgId);
                tempSecondOrg.ParentOrg = new Models.FirstOrg { Id = tempFirstOrg.Id, OrgName = tempFirstOrg.OrgName, OrgLevel = tempFirstOrg.OrgLevel };
                secondOrgList.Add(tempSecondOrg);
            }
            ViewData["secondOrgList"] = secondOrgList;

            //装载所有1级机构，用于所属机构选择下拉框
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();

            foreach (var fo in bLL.GetAllFirstOrg())
            {
                Models.FirstOrg tempFirstOrg = new Models.FirstOrg { Id = fo.Id, OrgName = fo.OrgName, OrgLevel = fo.OrgLevel };
                firstOrgList.Add(tempFirstOrg);
            }

            ViewData["firstOrgList"] = firstOrgList;

            return View();
        }





        [SystemManagerAuthorization]
        public ActionResult DeleteFirstOrg(string id)
        {

            IOrgBLL bLL = new OrgBLL();

            if (bLL.DeleteFirstOrgById(Convert.ToInt32(id)))
            {
                TempData["info"] = "已删除";
                return Redirect("/Settings/OrgSettings");
            }
            else
            {
                TempData["error"] = "删除失败,该机构下有2级机构，无法直接删除";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }

        [SystemManagerAuthorization]
        public ActionResult DeleteSecondOrg(string id)
        {
            IOrgBLL bLL = new OrgBLL();

            if (bLL.DeleteSecondOrgById(Convert.ToInt32(id)))
            {
                TempData["info"] = "已删除";
                return Redirect("/Settings/OrgSettings");
            }
            else
            {
                TempData["error"] = "删除失败,该机构下有3级机构，无法直接删除";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }

        [SystemManagerAuthorization]
        public ActionResult DeleteThirdOrg(string id)
        {
            IOrgBLL bLL = new OrgBLL();

            if (bLL.DeleteThirdOrgById(Convert.ToInt32(id)))
            {
                TempData["info"] = "已删除";
                return Redirect("/Settings/OrgSettings");
            }
            else
            {
                TempData["error"] = "删除失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }







        //在编辑3级机构时,当1级机构的选择改变的时候,动态改变2级机构的下拉框选项
        [StaffNormalAuthorization]
        public ActionResult DynamicSecondOrg(string id)
        {

            IOrgBLL bLL = new OrgBLL();

            List<Models.SecondeOrg> list = new List<Models.SecondeOrg>();

            List<SecondOrg> tempList = bLL.GetSecondOrgByFirstOrgId(Convert.ToInt32(id));

            if (tempList != null)
            {
                foreach (var so in tempList)
                {
                    Models.SecondeOrg secondeOrg = new Models.SecondeOrg { Id = so.Id, OrgName = so.OrgName, OrgLevel = so.OrgLevel };
                    list.Add(secondeOrg);
                }
            }

            return Json(list);

        }

        [StaffNormalAuthorization]
        public ActionResult DynamicThirdOrg(string id)
        {

            IOrgBLL bLL = new OrgBLL();

            List<Models.ThirdOrg> list = new List<Models.ThirdOrg>();

            List<ThirdOrg> tempList = bLL.GetThirdOrgBySecondOrgId(Convert.ToInt32(id));

            if (tempList != null)
            {
                foreach (var to in tempList)
                {
                    Models.ThirdOrg thirdOrg = new Models.ThirdOrg { Id = to.Id, OrgName = to.OrgName, OrgLevel = to.OrgLevel };
                    list.Add(thirdOrg);
                }
            }

            return Json(list);

        }

    }
}