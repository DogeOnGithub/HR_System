using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_System.Filters;
using HR_SystemIDAL;
using HR_SystemIBLL;
using HR_SystemBLL;
using Model;

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

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            //装载1级机构
            List<FirstOrg> fList = orgBLL.GetAllFirstOrg();
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();
            foreach (var fo in fList)
            {
                Models.FirstOrg tempFo = new Models.FirstOrg { Id = fo.Id, OrgName = fo.OrgName, OrgLevel = fo.OrgLevel };
                firstOrgList.Add(tempFo);
            }
            ViewData["firstOrgList"] = firstOrgList;

            //装载职位类型
            List<OccupationClass> ocList = occupationBLL.GetAllOccupationClass();
            List<Models.OccupationClass> occClassList = new List<Models.OccupationClass>();
            foreach (var oc in ocList)
            {
                Models.OccupationClass tempClass = new Models.OccupationClass { Id = oc.Id, Name = oc.Name };
                occClassList.Add(tempClass);
            }
            ViewData["occClassList"] = occClassList;

            //装载职称
            List<TechnicalTitle> ttList = occupationBLL.GetAllTechnicalTitle();
            List<Models.TechnicalTitle> tTitleList = new List<Models.TechnicalTitle>();
            foreach (var tt in ttList)
            {
                Models.TechnicalTitle tempTitle = new Models.TechnicalTitle { Id = tt.Id, Name = tt.Name };
                tTitleList.Add(tempTitle);
            }
            ViewData["tTitleList"] = tTitleList;


            return View();
        }

        public ActionResult SaveStaff(FormCollection formCollection)
        {

            IStaffBLL bLL = new StaffBLL();

            Staff staff = new Staff();

            Type type = typeof(Staff);

            foreach (var p in type.GetProperties())
            {
                if (p.Name != "FileState" && p.Name != "IsDel" && p.Name != "ImagePath" && p.Name != "Id")
                {
                    p.SetValue(staff, Convert.ChangeType(formCollection[p.Name], p.PropertyType));
                }
            }

            staff.FileState = EnumState.StaffFileStateEnum.WaitCheck;
            staff.IsDel = false;
            staff.StaffFileNumber = DateTime.Now.Year.ToString() + formCollection["FirstOrg"] + formCollection["SecondOrg"] + formCollection["ThirdOrgId"] + new Random().Next(10, 99).ToString();
            

            HttpPostedFileBase file = Request.Files["StaffImage"];

            string path = @"/UploadFiles/" + Guid.NewGuid().ToString() + file.FileName;

            file.SaveAs(Server.MapPath(path));

            staff.ImagePath = path;

            if (bLL.SaveStaff(staff))
            {
                TempData["info"] = "保存成功";
                return Redirect("/StaffManage/StaffView");
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }

        public ActionResult StaffView()
        {

            IStaffBLL bLL = new StaffBLL();

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            List<Staff> staffList = bLL.GetAllStaff();

            List<Models.Staff> staffListView = new List<Models.Staff>();

            foreach (var staff in staffList)
            {
                Models.Staff tempStaff = new Models.Staff
                {
                    Id = staff.Id,
                    StaffFileNumber = staff.StaffFileNumber,
                    StaffName = staff.StaffName,
                    FileState = staff.FileState,
                    IsDel = staff.IsDel
                };
                ThirdOrg thirdOrg = orgBLL.GetThirdOrgById(staff.ThirdOrgId);
                SecondOrg secondOrg = orgBLL.GetSecondOrgById(thirdOrg.ParentOrgId);
                FirstOrg firstOrg = orgBLL.GetFirstOrgById(secondOrg.ParentOrgId);

                tempStaff.FirstOrg = new Models.FirstOrg { Id = firstOrg.Id, OrgLevel = firstOrg.OrgLevel, OrgName = firstOrg.OrgName };
                tempStaff.SecondeOrg = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel, ParentOrg = tempStaff.FirstOrg };
                tempStaff.ThirdOrg = new Models.ThirdOrg { Id = thirdOrg.Id, ParentOrg = tempStaff.SecondeOrg, OrgLevel = thirdOrg.OrgLevel, OrgName = thirdOrg.OrgName };

                OccupationName occupationName = occupationBLL.GetOccupationNameById(staff.OccId);

                tempStaff.OccupationName = new Models.OccupationName { Id = occupationName.Id, Name = occupationName.Name };

                staffListView.Add(tempStaff);
            }

            ViewData["staffListView"] = staffListView;

            return View();
        }
    }
}