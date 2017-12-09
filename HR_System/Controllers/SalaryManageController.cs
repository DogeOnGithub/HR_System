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
    public class SalaryManageController : Controller
    {
        /// <summary>
        /// 列表展示薪酬标准，再由独立控制器处理薪酬标准的具体操作
        /// </summary>
        /// <returns>返回薪酬标准的列表视图</returns>
        public ActionResult SalaryStandardManage()
        {

            //装载所有的薪酬标准

            //薪酬管理业务层
            ISalaryBLL bLL = new SalaryBLL();

            //薪酬项目管理业务层，因为薪酬标准管理和薪酬项目管理是不同模块的
            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();
            
            //获取所有的薪酬标准，这时的薪酬标准是Model中的类型
            List<SalaryStandard> standardList = bLL.GetAllSalaryStandard();

            List<Models.SalaryStandard> standardListView = new List<Models.SalaryStandard>();

            //遍历所有薪酬标准，将其转换成视图模型中的薪酬标准
            foreach (var s in standardList)
            {
                //通过薪酬标准的id获取所有的映射关系
                List<StandardMapItem> tempMapList = bLL.GetAllStandardMapItemByStandardId(s.Id);

                Models.SalaryStandard tempStandard = new Models.SalaryStandard()
                {
                    Id = s.Id,
                    StandardName = s.StandardName,
                    StandardFileNumber = s.StandardFileNumber,
                    Registrant = s.Registrant,
                    RegistTime = s.RegistTime,
                    DesignBy = s.DesignBy,
                    Total = s.Total,
                    StandardState = s.StandardState,
                    CheckDesc = s.CheckDesc,
                    CheckBy = s.CheckBy
                };

                //遍历映射关系，分拆装载进视图模型薪酬标准中的字典
                foreach (var m in tempMapList)
                {
                    SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                    Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                    tempStandard.ItemAmout.Add(salaryItemView, m.Amout);
                }

                standardListView.Add(tempStandard);
            }

            ViewData["standardListView"] = standardListView;

            return View();
        }

        /// <summary>
        /// 处理复核薪酬标准的请求
        /// </summary>
        /// <returns>返回所有待复核的薪酬标准的列表视图</returns>
        public ActionResult StandardCheck()
        {

            //装载所有待复核的薪酬标准

            //薪酬管理业务层
            ISalaryBLL bLL = new SalaryBLL();

            //薪酬项目管理业务层，因为薪酬标准管理和薪酬项目管理是不同模块的
            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            //获取所有的薪酬标准，这时的薪酬标准是Model中的类型
            List<SalaryStandard> standardList = bLL.GetAllSalaryStandardWaitCheck();

            List<Models.SalaryStandard> standardListView = new List<Models.SalaryStandard>();

            //遍历所有薪酬标准，将其转换成视图模型中的薪酬标准
            foreach (var s in standardList)
            {
                //通过薪酬标准的id获取所有的映射关系
                List<StandardMapItem> tempMapList = bLL.GetAllStandardMapItemByStandardId(s.Id);

                Models.SalaryStandard tempStandard = new Models.SalaryStandard()
                {
                    Id = s.Id,
                    StandardName = s.StandardName,
                    StandardFileNumber = s.StandardFileNumber,
                    Registrant = s.Registrant,
                    RegistTime = s.RegistTime,
                    DesignBy = s.DesignBy,
                    Total = s.Total,
                    StandardState = s.StandardState,
                    CheckDesc = s.CheckDesc,
                    CheckBy = s.CheckBy
                };

                //遍历映射关系，分拆装载进视图模型薪酬标准中的字典
                foreach (var m in tempMapList)
                {
                    SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                    Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                    tempStandard.ItemAmout.Add(salaryItemView, m.Amout);
                }

                standardListView.Add(tempStandard);
            }

            ViewData["standardListView"] = standardListView;

            return View();

        }

        /// <summary>
        /// 处理发放薪酬请求
        /// </summary>
        /// <returns>返回发放薪酬视图</returns>
        public ActionResult SalaryGrant()
        {

            ISalaryGrantBLL bLL = new SalaryGrantBLL();

            IOrgBLL orgBLL = new OrgBLL();

            List<SalaryPayment> list = bLL.GetAllSalaryPayment();

            List<Models.SalaryPayment> salaryPaymentList = new List<Models.SalaryPayment>();

            foreach (var sp in list)
            {
                Models.SalaryPayment salaryPayment = new Models.SalaryPayment
                {
                    Id = sp.Id,
                    FileNumber = sp.FileNumber,
                    TotalPerson = sp.TotalPerson,
                    TotalAmout = sp.TotalAmout,
                    RegistTime = sp.RegistTime,
                    FileState = sp.FileState
                };
                ThirdOrg thirdOrg = orgBLL.GetThirdOrgById(sp.TOrgId);
                SecondOrg secondOrg = orgBLL.GetSecondOrgById(thirdOrg.ParentOrgId);
                FirstOrg firstOrg = orgBLL.GetFirstOrgById(secondOrg.ParentOrgId);

                Models.FirstOrg firstOrgView = new Models.FirstOrg { Id = firstOrg.Id, OrgLevel = firstOrg.OrgLevel, OrgName = firstOrg.OrgName };
                Models.SecondeOrg secondeOrgView = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel, ParentOrg = firstOrgView };
                Models.ThirdOrg thirdOrgView = new Models.ThirdOrg { Id = thirdOrg.Id, ParentOrg = secondeOrgView, OrgLevel = thirdOrg.OrgLevel, OrgName = thirdOrg.OrgName };

                salaryPayment.ThirdOrg = thirdOrgView;

                salaryPaymentList.Add(salaryPayment);
            }

            ViewData["salaryPaymentList"] = salaryPaymentList;

            return View();
        }

        public ActionResult SalaryPaymentView()
        {
            ISalaryGrantBLL bLL = new SalaryGrantBLL();

            IOrgBLL orgBLL = new OrgBLL();

            List<SalaryPayment> list = bLL.GetAllSalaryPaymentFromDB();

            List<Models.SalaryPayment> salaryPaymentList = new List<Models.SalaryPayment>();

            if (list != null)
            {
                foreach (var sp in list)
                {
                    Models.SalaryPayment salaryPayment = new Models.SalaryPayment
                    {
                        Id = sp.Id,
                        FileNumber = sp.FileNumber,
                        TotalPerson = sp.TotalPerson,
                        TotalAmout = sp.TotalAmout,
                        RegistTime = sp.RegistTime,
                        FileState = sp.FileState
                    };
                    ThirdOrg thirdOrg = orgBLL.GetThirdOrgById(sp.TOrgId);
                    SecondOrg secondOrg = orgBLL.GetSecondOrgById(thirdOrg.ParentOrgId);
                    FirstOrg firstOrg = orgBLL.GetFirstOrgById(secondOrg.ParentOrgId);

                    Models.FirstOrg firstOrgView = new Models.FirstOrg { Id = firstOrg.Id, OrgLevel = firstOrg.OrgLevel, OrgName = firstOrg.OrgName };
                    Models.SecondeOrg secondeOrgView = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel, ParentOrg = firstOrgView };
                    Models.ThirdOrg thirdOrgView = new Models.ThirdOrg { Id = thirdOrg.Id, ParentOrg = secondeOrgView, OrgLevel = thirdOrg.OrgLevel, OrgName = thirdOrg.OrgName };

                    salaryPayment.ThirdOrg = thirdOrgView;

                    salaryPaymentList.Add(salaryPayment);
                }
            }

            ViewData["salaryPaymentList"] = salaryPaymentList;

            return View();
        }

        public ActionResult SalaryPaymentDetail(string id)
        {
            ISalaryGrantBLL salaryGrantBLL = new SalaryGrantBLL();

            IStaffBLL staffBLL = new StaffBLL();

            ISalaryBLL salaryBLL = new SalaryBLL();

            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            IOrgBLL orgBLL = new OrgBLL();

            List<StaffPayment> staffPaymentList = salaryGrantBLL.GetAllStaffPaymentByPaymentId(Convert.ToInt32(id));

            List<Models.StaffPayment> staffPaymentListView = new List<Models.StaffPayment>();

            foreach (var sp in staffPaymentList)
            {
                Models.StaffPayment staffPayment = new Models.StaffPayment
                {
                    Id = sp.Id,
                    OddAmout = sp.OddAmout,
                    MinusAmout = sp.MinusAmout
                };

                //获取Model.StaffSalary，为StaffPayment装载StaffSalary
                StaffSalary staffSalary = salaryGrantBLL.GetStaffSalaryById(sp.StaffSalaryId);
                Models.StaffSalary staffSalaryView = new Models.StaffSalary
                {
                    Id = staffSalary.Id,
                    StaffFileNumber = staffSalary.StaffFileNumber
                };

                Staff staff = staffBLL.GetStaffById(staffSalary.StaffId);
                staffSalaryView.Staff = new Models.Staff { Id = staff.Id, StaffName = staff.StaffName };

                ThirdOrg thirdOrg = orgBLL.GetThirdOrgById(staff.ThirdOrgId);
                SecondOrg secondOrg = orgBLL.GetSecondOrgById(thirdOrg.ParentOrgId);
                FirstOrg firstOrg = orgBLL.GetFirstOrgById(secondOrg.ParentOrgId);

                Models.FirstOrg firstOrgView = new Models.FirstOrg { Id = firstOrg.Id, OrgLevel = firstOrg.OrgLevel, OrgName = firstOrg.OrgName };
                Models.SecondeOrg secondeOrgView = new Models.SecondeOrg { Id = secondOrg.Id, OrgName = secondOrg.OrgName, OrgLevel = secondOrg.OrgLevel, ParentOrg = firstOrgView };
                staffSalaryView.ThirdOrg = new Models.ThirdOrg { Id = thirdOrg.Id, ParentOrg = secondeOrgView, OrgLevel = thirdOrg.OrgLevel, OrgName = thirdOrg.OrgName };

                SalaryStandard salaryStandard = salaryBLL.GetSalaryStandardById(staffSalary.StandardId);
                Models.SalaryStandard salaryStandardView = new Models.SalaryStandard
                {
                    Id = salaryStandard.Id,
                    StandardName = salaryStandard.StandardName,
                };
                List<StandardMapItem> standardMapItemList = salaryBLL.GetAllStandardMapItemByStandardId(salaryStandard.Id);
                foreach (var item in standardMapItemList)
                {

                    SalaryItem salaryItem = salaryItemBLL.GetSalaryItemById(item.ItemId);

                    Models.SalaryItem salaryItemView = new Models.SalaryItem
                    {
                        Id = salaryItem.Id,
                        Name = salaryItem.Name
                    };

                    salaryStandardView.ItemAmout.Add(salaryItemView, item.Amout); ;
                }

                staffSalaryView.SalaryStandard = salaryStandardView;

                staffPayment.StaffSalary = staffSalaryView;



                SalaryPayment salaryPayment = salaryGrantBLL.GetSalaryPaymentById(sp.PaymentId);
                staffPayment.SalaryPayment = new Models.SalaryPayment
                {
                    Id = salaryPayment.Id,
                    TotalPerson = salaryPayment.TotalPerson,
                    TotalAmout = salaryPayment.TotalAmout,
                    FileState = salaryPayment.FileState,
                    FileNumber = salaryPayment.FileNumber,
                    Registrant = salaryPayment.Registrant,
                    RegistTime = salaryPayment.RegistTime,
                    TotalReal = salaryPayment.TotalReal,
                    CheckBy = salaryPayment.CheckBy,
                    CheckTime = salaryPayment.CheckTime
                };


                staffPaymentListView.Add(staffPayment);

            }

            ViewData["staffPaymentListView"] = staffPaymentListView;

            return View();
        }
    }
}