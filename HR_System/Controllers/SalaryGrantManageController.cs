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
    public class SalaryGrantManageController : Controller
    {
        public ActionResult SalaryGrantRegist(string id)
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
                    CheckBy = salaryPayment.CheckBy,
                    CheckTime = salaryPayment.CheckTime
                };


                staffPaymentListView.Add(staffPayment);

            }

            ViewData["staffPaymentListView"] = staffPaymentListView;

            return View();
        }

        public ActionResult SalaryGrantSubmitReg(FormCollection formCollection)
        {

            ISalaryGrantBLL salaryGrantBLL = new SalaryGrantBLL();

            //获取发放的人数，即StaffPayment的数量
            int count = Convert.ToInt32(formCollection["Count"]);

            //获取发放的薪酬单的id
            int salaryPaymentId = Convert.ToInt32(formCollection["SalaryPaymentId"]);

            SalaryPayment salaryPayment = salaryGrantBLL.GetSalaryPaymentById(salaryPaymentId);

            decimal total = salaryPayment.TotalAmout;

            decimal totalReal = total;

            string action = "";

            if (formCollection["SalaryPaymentCheck"] == "Checked")
            {
                salaryPayment.FileState = EnumState.SalaryPaymentStateEnum.Checked;
                salaryPayment.CheckBy = formCollection["CheckBy"];
                salaryPayment.CheckTime = DateTime.Now;
                action = "SalaryPaymentWaitCheck";
            }
            else
            {
                salaryPayment.FileState = EnumState.SalaryPaymentStateEnum.WaitCheck;
                salaryPayment.Registrant = formCollection["Registrant"];
                action = "SalaryPaymentWaitReg";
            }

            for (int i = 0; i < count; i++)
            {
                //获取StaffPayment 的id
                int staffPaymentId = Convert.ToInt32(formCollection["StaffPaymentId" + i]);

                //获取对应id的Odd和Minus
                decimal odd = Convert.ToDecimal(formCollection["OddAmout" + staffPaymentId]);
                decimal minus = Convert.ToDecimal(formCollection["MinusAmout" + staffPaymentId]);

                totalReal += odd;
                totalReal -= minus;

                if (!salaryGrantBLL.UpdateStaffPayOddAndMinus(staffPaymentId, odd, minus))
                {
                    TempData["error"] = "操作失败";
                    return RedirectToAction(action);
                }
            }

            salaryPayment.TotalReal = totalReal;
            salaryPayment.RegistTime = DateTime.Now;
            
            
            

            if (!salaryGrantBLL.SaveSalaryPayment(salaryPayment))
            {
                TempData["error"] = "操作失败";
                return RedirectToAction(action);
            }

            TempData["info"] = "操作成功";
            return RedirectToAction(action);
        }

        public ActionResult SalaryPaymentWaitReg()
        {

            ISalaryGrantBLL bLL = new SalaryGrantBLL();

            IOrgBLL orgBLL = new OrgBLL();

            List<SalaryPayment> list = bLL.GetAllSalaryPaymentWaitReg();

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

        public ActionResult SalaryPaymentWaitCheck()
        {
            ISalaryGrantBLL bLL = new SalaryGrantBLL();

            IOrgBLL orgBLL = new OrgBLL();

            List<SalaryPayment> list = bLL.GetAllSalaryPaymentWaitCheck();

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

        public ActionResult SalaryGrantCheck(string id)
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
                    TotalReal = salaryPayment.TotalReal,
                    Registrant = salaryPayment.Registrant,
                    CheckBy = salaryPayment.CheckBy,
                    RegistTime = salaryPayment.RegistTime,
                    CheckTime = salaryPayment.CheckTime
                };


                staffPaymentListView.Add(staffPayment);

            }

            ViewData["staffPaymentListView"] = staffPaymentListView;

            return View();
        }
    }
}