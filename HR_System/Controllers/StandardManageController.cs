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
    public class StandardManageController : Controller
    {
        /// <summary>
        /// 薪酬标准详情
        /// </summary>
        /// <param name="id">薪酬标准的id</param>
        /// <returns>薪酬标准详情页</returns>
        public ActionResult DetailSalaryStandard(string id)
        {

            ISalaryBLL salaryBLL = new SalaryBLL();

            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            //通过id查找到薪酬标准
            SalaryStandard salaryStandard = salaryBLL.GetSalaryStandardById(Convert.ToInt32(id));

            //视图模型薪酬标准
            Models.SalaryStandard salaryStandardView = new Models.SalaryStandard
            {
                Id = salaryStandard.Id,
                StandardName = salaryStandard.StandardName,
                StandardFileNumber = salaryStandard.StandardFileNumber,
                Registrant = salaryStandard.Registrant,
                RegistTime = salaryStandard.RegistTime,
                DesignBy = salaryStandard.DesignBy,
                Total = salaryStandard.Total,
                StandardState = salaryStandard.StandardState,
                CheckDesc = salaryStandard.CheckDesc,
                CheckBy = salaryStandard.CheckBy
            };

            //通过薪酬标准的id找到所有的项目映射关系
            List<StandardMapItem> tempMapList = salaryBLL.GetAllStandardMapItemByStandardId(salaryStandard.Id);

            //遍历映射关系，并把薪酬项目和薪酬项目的金额装载到视图模型薪酬标准的字典中
            foreach (var m in tempMapList)
            {
                SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                salaryStandardView.ItemAmout.Add(salaryItemView, m.Amout);
            }

            //通过薪酬标准的id找到所有的职位映射关系
            List<StandardMapOccupationName> occList = salaryBLL.GetAllStandardMapOccByStandardId(salaryStandard.Id);

            if (occList != null)
            {
                foreach (var o in occList)
                {
                    OccupationName tempOccName = occupationBLL.GetOccupationNameById(o.OccupationNameId);
                    Models.OccupationName occupationNameView = new Models.OccupationName { Id = tempOccName.Id, Name = tempOccName.Name };
                    OccupationClass tempOccClass = occupationBLL.GetOccupationClassById(tempOccName.ClassId);
                    occupationNameView.OccupationClass = new Models.OccupationClass { Id = tempOccClass.Id, Name = tempOccClass.Name };
                    salaryStandardView.OccList.Add(occupationNameView);
                }
            }

            ViewData["salaryStandardView"] = salaryStandardView;

            return View();
        }

        /// <summary>
        /// 编辑薪酬标准
        /// </summary>
        /// <param name="id">薪酬标准的id</param>
        /// <returns>返回编辑视图</returns>
        public ActionResult EditSalaryStandard(string id)
        {
            ISalaryBLL salaryBLL = new SalaryBLL();

            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            //通过id查找到薪酬标准
            SalaryStandard salaryStandard = salaryBLL.GetSalaryStandardById(Convert.ToInt32(id));

            //视图模型薪酬标准
            Models.SalaryStandard salaryStandardView = new Models.SalaryStandard
            {
                Id = salaryStandard.Id,
                StandardName = salaryStandard.StandardName,
                StandardFileNumber = salaryStandard.StandardFileNumber,
                Registrant = salaryStandard.Registrant,
                RegistTime = salaryStandard.RegistTime,
                DesignBy = salaryStandard.DesignBy,
                Total = salaryStandard.Total,
                StandardState = salaryStandard.StandardState,
                CheckDesc = salaryStandard.CheckDesc,
                CheckBy = salaryStandard.CheckBy
            };

            //通过薪酬标准的id找到所有的项目映射关系
            List<StandardMapItem> tempMapList = salaryBLL.GetAllStandardMapItemByStandardId(salaryStandard.Id);

            //遍历映射关系，并把薪酬项目和薪酬项目的金额装载到视图模型薪酬标准的字典中
            foreach (var m in tempMapList)
            {
                SalaryItem tempSalaryItem = salaryItemBLL.GetSalaryItemById(m.ItemId);
                Models.SalaryItem salaryItemView = new Models.SalaryItem { Id = tempSalaryItem.Id, Name = tempSalaryItem.Name };
                salaryStandardView.ItemAmout.Add(salaryItemView, m.Amout);
            }

            //通过薪酬标准的id找到所有的职位映射关系
            List<StandardMapOccupationName> occList = salaryBLL.GetAllStandardMapOccByStandardId(salaryStandard.Id);

            if (occList != null)
            {
                foreach (var o in occList)
                {
                    OccupationName tempOccName = occupationBLL.GetOccupationNameById(o.OccupationNameId);
                    Models.OccupationName occupationNameView = new Models.OccupationName { Id = tempOccName.Id, Name = tempOccName.Name };
                    OccupationClass tempOccClass = occupationBLL.GetOccupationClassById(tempOccName.ClassId);
                    occupationNameView.OccupationClass = new Models.OccupationClass { Id = tempOccClass.Id, Name = tempOccClass.Name };
                    salaryStandardView.OccList.Add(occupationNameView);
                }
            }

            ViewData["salaryStandardView"] = salaryStandardView;


            //装载所有薪酬项目
            List<SalaryItem> salaryList = salaryItemBLL.GetAllSalaryItem();

            List<Models.SalaryItem> itemList = new List<Models.SalaryItem>();

            foreach (var item in salaryList)
            {
                Models.SalaryItem tempItem = new Models.SalaryItem
                {
                    Id = item.Id,
                    Name = item.Name
                };
                itemList.Add(tempItem);
            }

            ViewData["itemList"] = itemList;

            //装载所有职位类型
            List<OccupationClass> occClassList = occupationBLL.GetAllOccupationClass();
            List<Models.OccupationClass> occClassListView = new List<Models.OccupationClass>();
            if (occClassList != null)
            {
                foreach (var oc in occClassList)
                {
                    Models.OccupationClass tempClass = new Models.OccupationClass() { Id = oc.Id, Name = oc.Name };
                    occClassListView.Add(tempClass);
                }
            }
            ViewData["occClassListView"] = occClassListView;


            //装载所有该薪酬标准的职位类型下的所有职位
            List<Models.OccupationName> occNameList = new List<Models.OccupationName>();

            for (int i = 0; i < salaryStandardView.OccList.Count; i++)
            {
                List<OccupationName> tempList = occupationBLL.GetAllOccNameByClassId(salaryStandardView.OccList[i].OccupationClass.Id);
                foreach (var on in tempList)
                {
                    Models.OccupationName tempOccupationName = new Models.OccupationName { Id = on.Id, Name = on.Name, OccupationClass = salaryStandardView.OccList[i].OccupationClass };
                    occNameList.Add(tempOccupationName);
                }
            }
            ViewData["occNameList"] = occNameList;

            return View();
        }

        /// <summary>
        /// 保存薪酬标准，编辑或添加
        /// </summary>
        /// <param name="formCollection">表单值容器</param>
        /// <returns>成功则重定向到刚刚保存的薪酬标准的详情页，否则回到源URL</returns>
        public ActionResult SaveStandard(FormCollection formCollection)
        {

            //薪酬管理的业务层
            ISalaryBLL salaryBLL = new SalaryBLL();

            //薪酬项目的业务层
            ISalaryItemBLL bLL = new SalaryItemBLL();

            //数据层Model的薪酬标准
            SalaryStandard salaryStandard = new SalaryStandard();

            Type type = salaryStandard.GetType();

            var props = type.GetProperties();

            //反射，遍历，把表单数据装载到对象的属性中
            foreach (var p in props)
            {
                if (p.Name != "StandardState" && p.Name != "Id")
                {
                    p.SetValue(salaryStandard, Convert.ChangeType(formCollection[p.Name], p.PropertyType));
                }
            }

            //装载id，因为当添加薪酬标准时，id为空，null类型不能转换
            salaryStandard.Id = Convert.ToInt32(formCollection["Id"]);

            //装载状态，枚举类型不能转换
            salaryStandard.StandardState = EnumState.StandardStateEnum.WaitCheck;

            //先保存该薪酬标准，否则，无法insert映射记录
            salaryBLL.SaveSalaryStandard(salaryStandard);

            //根据全局唯一的编号获取刚刚保存的薪酬标准的id
            salaryStandard.Id = salaryBLL.GetSalaryStandardIdByfileNumber(salaryStandard.StandardFileNumber);

            var itemcheckbox = formCollection["ItemCheckbox"];

            decimal total = 0;

            //遍历复选框，只有复选框勾选，下面对应的输入框的数值才有效
            foreach (var i in itemcheckbox.Split(','))
            {
                StandardMapItem tempMap = new StandardMapItem { StandardId = salaryStandard.Id, ItemId = Convert.ToInt32(i), Amout = Convert.ToDecimal(formCollection["value" + i]) };
                salaryBLL.SaveMapItem(tempMap);
                total += tempMap.Amout;
            }

            //更新总金额
            salaryStandard.Total = total;

            //判断该薪酬标准在映射表中有没有记录
            if (salaryBLL.GetAllStandardMapOccByStandardId(salaryStandard.Id) != null)
            {
                if (!salaryBLL.DeleteAllOccMapByStandardId(salaryStandard.Id))
                {
                    TempData["error"] = "保存失败";
                    return Redirect(Request.UrlReferrer.AbsoluteUri);
                }
            }
            //往数据库添加未存在的映射关系
            for (int i = Convert.ToInt32(formCollection["eCount"]); i < 3; i++)
            {
                if (Convert.ToInt32(formCollection["occName" + i]) != 0)
                {
                    StandardMapOccupationName standardMapOccupationName = new StandardMapOccupationName { StandardId = salaryStandard.Id, OccupationNameId = Convert.ToInt32(formCollection["occName" + i]) };
                    salaryBLL.SaveMapOcc(standardMapOccupationName); 
                }
            }

            //重新保存一次薪酬标准
            if (salaryBLL.SaveSalaryStandard(salaryStandard))
            {
                TempData["info"] = "保存成功";
                return RedirectToAction("DetailSalaryStandard", new { id = salaryStandard.Id });
            }
            else
            {
                TempData["error"] = "保存失败";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }

        public ActionResult AddSalaryStandard()
        {

            ISalaryItemBLL bLL = new SalaryItemBLL();

            List<SalaryItem> tempList = bLL.GetAllSalaryItem();

            List<Models.SalaryItem> itemList = new List<Models.SalaryItem>();

            foreach (var item in tempList)
            {
                Models.SalaryItem tempItem = new Models.SalaryItem
                {
                    Id = item.Id,
                    Name = item.Name
                };
                itemList.Add(tempItem);
            }

            ViewData["itemList"] = itemList;

            return View();
        }

        /// <summary>
        /// 处理在编辑或添加薪酬标准时发出的添加适用职位请求
        /// </summary>
        /// <param name="formCollection">提交上来的表单容器</param>
        /// <returns>返回添加职位选项后的视图</returns>
        public ActionResult StandardAddOccName(FormCollection formCollection)
        {

            ViewData["formCollection"] = formCollection;

            ISalaryItemBLL salaryItemBLL = new SalaryItemBLL();

            IOccupationBLL occupationBLL = new OccupationBLL();

            //装载所有职位类型
            List<OccupationClass> occClassList = occupationBLL.GetAllOccupationClass();
            List<Models.OccupationClass> occClassListView = new List<Models.OccupationClass>();
            foreach (var oc in occClassList)
            {
                Models.OccupationClass tempClass = new Models.OccupationClass { Id = oc.Id, Name = oc.Name };
                occClassListView.Add(tempClass);
            }
            ViewData["occClassListView"] = occClassListView;

            //装载所有职位
            List<OccupationName> occNameList = occupationBLL.GetAllOccupationName();
            List<Models.OccupationName> occNameListView = new List<Models.OccupationName>();
            foreach (var on in occNameList)
            {
                Models.OccupationName tempName = new Models.OccupationName { Id = on.Id, Name = on.Name };
                OccupationClass tempClass = occupationBLL.GetOccupationClassById(on.ClassId);
                tempName.OccupationClass = new Models.OccupationClass { Id = tempClass.Id, Name = tempClass.Name };
                occNameListView.Add(tempName);
            }
            ViewData["occNameListView"] = occNameListView;

            //装载所有薪酬项目
            List<SalaryItem> itemList = salaryItemBLL.GetAllSalaryItem();
            List<Models.SalaryItem> itemListView = new List<Models.SalaryItem>();
            foreach (var item in itemList)
            {
                Models.SalaryItem tempItem = new Models.SalaryItem { Id = item.Id, Name = item.Name };
                itemListView.Add(tempItem);
            }
            ViewData["itemListView"] = itemListView;

            return View();
        }

        public ActionResult DeleteSalaryStandard(string id)
        {

            ISalaryBLL bLL = new SalaryBLL();

            if (bLL.DeleteSalaryStandard(Convert.ToInt32(id)))
            {
                TempData["info"] = "删除成功";
                return Redirect("/SalaryManage/SalaryStandardManage");
            }
            else
            {
                TempData["error"] = "删除失败，这个薪酬标准正在使用中";
                return Redirect(Request.UrlReferrer.AbsoluteUri);
            }

        }
    }
}