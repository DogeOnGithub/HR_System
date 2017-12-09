using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using HR_System.Filters;
using HR_SystemIBLL;
using HR_SystemBLL;
using Model;
using System.Linq;

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

        /// <summary>
        /// 保存员工档案
        /// </summary>
        /// <param name="formCollection">表单容器</param>
        /// <returns>设置提示信息并重定向</returns>
        public ActionResult SaveStaff(FormCollection formCollection)
        {

            IStaffBLL bLL = new StaffBLL();

            Staff staff = new Staff();

            Type type = typeof(Staff);

            foreach (var p in type.GetProperties())
            {
                if (p.Name != "FileState" && p.Name != "IsDel" && p.Name != "ImagePath" && p.Name != "Id" && p.Name != "StaffFileNumber")
                {
                    p.SetValue(staff, Convert.ChangeType(formCollection[p.Name], p.PropertyType));
                }
            }

            if (formCollection["Id"] != null)
            {
                staff.Id = Convert.ToInt32(formCollection["Id"]);
            }

            if (formCollection["StaffFile"] == "Checked")
            {
                staff.FileState = EnumState.StaffFileStateEnum.Checked;
            }
            else
            {
                staff.FileState = EnumState.StaffFileStateEnum.WaitCheck;
            }

            staff.IsDel = false;

            if (formCollection["StaffFileNumber"] != null)
            {
                staff.StaffFileNumber = formCollection["StaffFileNumber"];
            }
            else
            {
                staff.StaffFileNumber = DateTime.Now.Year.ToString() + formCollection["FirstOrg"] + formCollection["SecondOrg"] + formCollection["ThirdOrgId"] + new Random().Next(10, 99).ToString();
            }


            if (formCollection["ImagePath"] != null)
            {
                staff.ImagePath = formCollection["ImagePath"];
            }

            if (Request.Files["StaffImage"].ContentLength > 10)
            {
                HttpPostedFileBase file = Request.Files["StaffImage"];

                string path = @"/UploadFiles/" + Guid.NewGuid().ToString() + file.FileName;

                file.SaveAs(Server.MapPath(path));

                staff.ImagePath = path;
            }

            if (bLL.SaveStaff(staff))
            {
                if (formCollection["StaffFile"] == "Checked")
                {
                    //复核之后，员工档案应该生效，因此需要往StaffSalary中插入记录，薪酬统计时是使用StaffSalary表的

                    ISalaryGrantBLL salaryGrantBLL = new SalaryGrantBLL();

                    if (salaryGrantBLL.SaveStaffSalary(new StaffSalary { StaffFileNumber = staff.StaffFileNumber, StaffId = staff.Id, StandardId = staff.StandardId, TOrgId = staff.ThirdOrgId }))
                    {
                        TempData["info"] = "复核通过";
                        return Redirect("/StaffManage/StaffCheck");
                    }
                    else
                    {
                        TempData["error"] = "复核失败";
                        return Redirect("/StaffManage/StaffCheck");
                    }

                    
                }
                else
                {
                    TempData["info"] = "保存成功";
                    return Redirect("/StaffManage/StaffView");
                }
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }
        }

        /// <summary>
        /// 列表展示所有员工档案
        /// </summary>
        /// <returns>返回列表展示视图</returns>
        public ActionResult StaffView()
        {

            IStaffBLL bLL = new StaffBLL();

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            List<Staff> staffList = bLL.GetAllStaffNormal();

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


            return View();
        }

        /// <summary>
        /// 指定id的员工档案详情
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>员工档案详情视图</returns>
        public ActionResult DetailStaff(string id)
        {

            GetStaffById(id);

            if (Request["Function"] == "Return")
            {
                ViewBag.Function = "Return";
            }

            return View();

        }

        /// <summary>
        /// 编辑员工档案
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>返回编辑视图</returns>
        public ActionResult EditStaff(string id)
        {
            GetStaffById(id);

            ViewBag.Title = "EditStaff";

            ViewBag.Button = "Submit";

            return View();

        }

        /// <summary>
        /// 查看需要复核的档案
        /// </summary>
        /// <returns>返回复核档案列表视图</returns>
        public ActionResult StaffCheck()
        {

            IStaffBLL bLL = new StaffBLL();

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            List<Staff> staffList = bLL.GetAllStaffWaitCheckNormal();

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

        /// <summary>
        /// 查看复核详细信息
        /// </summary>
        /// <param name="id">档案主键id</param>
        /// <returns>返回复核视图</returns>
        public ActionResult StaffCheckedDetail(string id)
        {

            GetStaffById(id);

            ViewBag.Title = "StaffCheckDetail";

            ViewBag.Button = "Checked";

            ViewBag.Function = "CheckedStaffFile";

            return View("EditStaff");

        }

        /// <summary>
        /// 逻辑删除员工档案
        /// </summary>
        /// <param name="id">主键id</param>
        /// <returns>设置提示信息并重定向</returns>
        public ActionResult DeleteStaff(string id)
        {

            IStaffBLL staffBLL = new StaffBLL();

            if (staffBLL.LoginDeleteStaff(Convert.ToInt32(id)))
            {
                TempData["info"] = "删除成功";
                return Redirect("/StaffManage/StaffView");
            }
            else
            {
                TempData["error"] = "删除失败";
                return Redirect("/StaffManage/StaffView");
            }

        }

        /// <summary>
        /// 查看已删除的员工档案
        /// </summary>
        /// <returns>返回列表视图</returns>
        public ActionResult StaffViewDeleted()
        {

            IStaffBLL bLL = new StaffBLL();

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            List<Staff> staffList = bLL.GetAllStaffDeleted();

            List<Models.Staff> staffListView = new List<Models.Staff>();

            if (staffList != null)
            {
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
            }

            ViewData["staffListView"] = staffListView;

            return View();
        }

        /// <summary>
        /// 逻辑恢复员工档案
        /// </summary>
        /// <param name="id">档案主键id</param>
        /// <returns>设置提示信息并重定向</returns>
        public ActionResult StaffReturn(string id)
        {

            IStaffBLL bLL = new StaffBLL();

            if (bLL.ReturnStaff(Convert.ToInt32(id)))
            {
                TempData["info"] = "还原成功";
                return Redirect("/StaffManage/StaffViewDeleted");
            }
            else
            {
                TempData["error"] = "还原失败";
                return Redirect("/StaffManage/StaffViewDeleted");
            }

        }

        /// <summary>
        /// 根据条件查询档案
        /// </summary>
        /// <param name="formCollection">查询条件</param>
        /// <returns>返回符合条件的员工档案列表视图</returns>
        public ActionResult StaffSearch(FormCollection formCollection)
        {

            IStaffBLL staffBLL = new StaffBLL();

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            List<Staff> list = new List<Staff>();

            List<Staff> tempList = new List<Staff>();

            if (formCollection["ThirdOrgId"] != "0")
            {
                list = staffBLL.GetAllStaffByTOrgId(Convert.ToInt32(formCollection["ThirdOrgId"]));

                tempList = list;

                if (formCollection["BeginDate"] != "")
                {
                    var l = from s in list
                            where s.RegistTime > Convert.ToDateTime(formCollection["BeginDate"])
                            select s;
                    tempList = l.ToList();
                    if (formCollection["EndDate"] != "")
                    {
                        var l2 = from s in tempList
                                 where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                 select s;
                        tempList = l2.ToList();
                    }
                }
                else
                {
                    if (formCollection["EndDate"] != "")
                    {
                        var l2 = from s in list
                                 where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                 select s;
                        tempList = l2.ToList();
                    }
                }

                list = tempList;
            }
            else
            {
                if (formCollection["SecondOrgId"] != "0")
                {
                    list = staffBLL.GetAllStaffBySOrgId(Convert.ToInt32(formCollection["SecondOrgId"]));

                    tempList = list;

                    if (formCollection["BeginDate"] != "")
                    {
                        var l = from s in list
                                where s.RegistTime > Convert.ToDateTime(formCollection["BeginDate"])
                                select s;
                        tempList = l.ToList();
                        if (formCollection["EndDate"] != "")
                        {
                            var l2 = from s in tempList
                                     where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                     select s;
                            tempList = l2.ToList();
                        }
                    }
                    else
                    {
                        if (formCollection["EndDate"] != "")
                        {
                            var l2 = from s in list
                                     where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                     select s;
                            tempList = l2.ToList();
                        }
                    }

                    list = tempList;
                }
                else
                {
                    if (formCollection["FirstOrgId"] != "0")
                    {
                        list = staffBLL.GetAllStaffByFOrgId(Convert.ToInt32(formCollection["FirstOrgId"]));

                        tempList = list;

                        if (formCollection["BeginDate"] != "")
                        {
                            var l = from s in list
                                    where s.RegistTime > Convert.ToDateTime(formCollection["BeginDate"])
                                    select s;
                            tempList = l.ToList();
                            if (formCollection["EndDate"] != "")
                            {
                                var l2 = from s in tempList
                                         where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                         select s;
                                tempList = l2.ToList();
                            }
                        }
                        else
                        {
                            if (formCollection["EndDate"] != "")
                            {
                                var l2 = from s in list
                                         where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                         select s;
                                tempList = l2.ToList();
                            }
                        }

                        list = tempList;
                    }
                    else
                    {
                        list = staffBLL.GetAllStaffNormal();

                        tempList = list;

                        if (formCollection["BeginDate"] != "")
                        {
                            var l = from s in list
                                    where s.RegistTime > Convert.ToDateTime(formCollection["BeginDate"])
                                    select s;
                            tempList = l.ToList();
                            if (formCollection["EndDate"] != "")
                            {
                                var l2 = from s in tempList
                                         where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                         select s;
                                tempList = l2.ToList();
                            }
                        }
                        else
                        {
                            if (formCollection["EndDate"] != "")
                            {
                                var l2 = from s in list
                                         where s.RegistTime < Convert.ToDateTime(formCollection["EndDate"])
                                         select s;
                                tempList = l2.ToList();
                            }
                        }

                        list = tempList;
                    }
                }
            }

            if (formCollection["OccNameId"] != "0")
            {
                int occNameId = Convert.ToInt32(formCollection["OccNameId"]);

                var l = from s in list
                        where s.OccId == occNameId
                        select s;

                list = l.ToList();
            }
            else
            {
                if (formCollection["OccClassId"] != "0")
                {
                    int occClassId = Convert.ToInt32(formCollection["OccClassId"]);

                    List<OccupationName> occNameList = occupationBLL.GetAllOccNameByClassId(occClassId);

                    List<int> ints = new List<int>();

                    foreach (var oc in occNameList)
                    {
                        ints.Add(oc.Id);
                    }

                    var l = from s in list
                            where ints.Contains(s.OccId)
                            select s;

                    list = l.ToList();

                }
            }

                    



            List<Models.Staff> staffListView = new List<Models.Staff>();

            if (list != null)
            {
                foreach (var staff in list)
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
            }

            ViewData["staffListView"] = staffListView;


            //装载1级机构
            List<FirstOrg> fList = orgBLL.GetAllFirstOrg();
            List<Models.FirstOrg> firstOrgList = new List<Models.FirstOrg>();
            foreach (var fo in fList)
            {
                Models.FirstOrg tempFo = new Models.FirstOrg { Id = fo.Id, OrgName = fo.OrgName, OrgLevel = fo.OrgLevel };
                firstOrgList.Add(tempFo);
            }
            ViewData["firstOrgList"] = firstOrgList;

            if (formCollection["FirstOrgId"] != "0")
            {
                //装载2级机构
                List<SecondOrg> sList = orgBLL.GetSecondOrgByFirstOrgId(Convert.ToInt32(formCollection["FirstOrgId"]));
                List<Models.SecondeOrg> secondOrgList = new List<Models.SecondeOrg>();
                foreach (var so in sList)
                {
                    Models.SecondeOrg tempSo = new Models.SecondeOrg { Id = so.Id, OrgName = so.OrgName };
                    secondOrgList.Add(tempSo);
                }
                ViewData["secondOrgList"] = secondOrgList; 
            }

            if (formCollection["SecondOrgId"] != "0")
            {
                //装载3级机构
                List<ThirdOrg> tList = orgBLL.GetThirdOrgBySecondOrgId(Convert.ToInt32(formCollection["SecondOrgId"]));
                List<Models.ThirdOrg> thirdOrgList = new List<Models.ThirdOrg>();
                foreach (var to in tList)
                {
                    Models.ThirdOrg tempTo = new Models.ThirdOrg { Id = to.Id, OrgName = to.OrgName };
                    thirdOrgList.Add(tempTo);
                }
                ViewData["thirdOrgList"] = thirdOrgList; 
            }

            //装载职位类型
            List<OccupationClass> ocList = occupationBLL.GetAllOccupationClass();
            List<Models.OccupationClass> occClassList = new List<Models.OccupationClass>();
            foreach (var oc in ocList)
            {
                Models.OccupationClass tempClass = new Models.OccupationClass { Id = oc.Id, Name = oc.Name };
                occClassList.Add(tempClass);
            }
            ViewData["occClassList"] = occClassList;

            if (formCollection["OccClassId"] != "0")
            {
                //装载职位
                List<OccupationName> onList = occupationBLL.GetAllOccNameByClassId(Convert.ToInt32(formCollection["OccClassId"]));
                List<Models.OccupationName> occNameList2 = new List<Models.OccupationName>();
                foreach (var on in onList)
                {
                    Models.OccupationName tempName = new Models.OccupationName { Id = on.Id, Name = on.Name };
                    occNameList2.Add(tempName);
                }
                ViewData["occNameList"] = occNameList2; 
            }




            return View("StaffView");
        }



        /// <summary>
        /// 控制器内部方法
        /// </summary>
        /// <param name="id">通过id装载视图模型Staff</param>
        private void GetStaffById(string id)
        {
            IStaffBLL staffBLL = new StaffBLL();

            IOrgBLL orgBLL = new OrgBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            ISalaryBLL salaryBLL = new SalaryBLL();

            Staff staff = staffBLL.GetStaffById(Convert.ToInt32(id));

            Models.Staff staffView = new Models.Staff();

            Type type = typeof(Models.Staff);

            Type modelType = typeof(Staff);

            var props = type.GetProperties();

            foreach (var p in props)
            {
                if (modelType.GetProperty(p.Name) != null)
                {
                    p.SetValue(staffView, modelType.GetProperty(p.Name).GetValue(staff));
                }
            }

            ThirdOrg thirdOrg = orgBLL.GetThirdOrgById(staff.ThirdOrgId);
            SecondOrg secondOrg = orgBLL.GetSecondOrgById(thirdOrg.ParentOrgId);
            FirstOrg firstOrg = orgBLL.GetFirstOrgById(secondOrg.ParentOrgId);
            OccupationName occupationName = occupationBLL.GetOccupationNameById(staff.OccId);
            OccupationClass occupationClass = occupationBLL.GetOccupationClassById(occupationName.ClassId);
            SalaryStandard salaryStandard = salaryBLL.GetSalaryStandardById(staff.StandardId);
            TechnicalTitle technicalTitle = occupationBLL.GetTechnicalTitleById(staff.TechnicalTitleId);

            staffView.FirstOrg = new Models.FirstOrg { Id = firstOrg.Id, OrgLevel = firstOrg.OrgLevel, OrgName = firstOrg.OrgName };
            staffView.SecondeOrg = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel, ParentOrg = staffView.FirstOrg };
            staffView.ThirdOrg = new Models.ThirdOrg { Id = thirdOrg.Id, ParentOrg = staffView.SecondeOrg, OrgLevel = thirdOrg.OrgLevel, OrgName = thirdOrg.OrgName };
            staffView.OccupationClass = new Models.OccupationClass { Id = occupationClass.Id, Name = occupationClass.Name };
            staffView.OccupationName = new Models.OccupationName { Id = occupationName.Id, Name = occupationName.Name, OccupationClass = staffView.OccupationClass };
            staffView.SalaryStandard = new Models.SalaryStandard { Id = salaryStandard.Id, StandardName = salaryStandard.StandardName, Total = salaryStandard.Total };
            staffView.TechnicalTitle = new Models.TechnicalTitle { Id = technicalTitle.Id, Name = technicalTitle.Name };

            ViewData["staffView"] = staffView;

            //装载所有职称
            List<Models.TechnicalTitle> list = new List<Models.TechnicalTitle>();

            List<TechnicalTitle> tempList = occupationBLL.GetAllTechnicalTitle();

            foreach (var tt in tempList)
            {
                Models.TechnicalTitle tempTechnicalTitle = new Models.TechnicalTitle
                {
                    Id = tt.Id,
                    Name = tt.Name
                };
                list.Add(tempTechnicalTitle);
            }

            ViewData["tTitleList"] = list;

            //装载该职位的所有薪酬标准
            List<SalaryStandard> standardList = salaryBLL.GetAllStandardByOccId(staff.OccId);

            List<Models.SalaryStandard> standardListView = new List<Models.SalaryStandard>();

            foreach (var s in standardList)
            {
                Models.SalaryStandard tempStandard = new Models.SalaryStandard
                {
                    Id = s.Id,
                    StandardName = s.StandardName,
                    Total = s.Total
                };
                standardListView.Add(tempStandard);
            }

            ViewData["standardListView"] = standardListView;
        }
    }
}