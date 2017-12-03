using HR_SystemDAL;
using HR_SystemIDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDAL
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 测试SecondOrgDAL，测试成功
            //ISecondOrgDAL dAL = new SecondOrgDAL();

            //foreach (var so in dAL.Query())
            //{
            //    Console.WriteLine(so.Id);
            //    Console.WriteLine(so.OrgName);
            //    Console.WriteLine(so.OrgLevel);
            //    Console.WriteLine(so.ParentOrgId);
            //}

            //ISecondOrgDAL dAL = new SecondOrgDAL();
            //foreach (var fo in dAL.QueryByParentOrgId(10))
            //{
            //    Console.WriteLine(fo.Id);
            //    Console.WriteLine(fo.OrgName);
            //}
            //Console.ReadKey();

            //Console.ReadKey(); 
            #endregion

            #region 测试ThirdOrgDAL，测试成功
            //IThirdOrgDAL dAL = new ThirdOrgDAL();
            //foreach (var to in dAL.Query())
            //{
            //    Console.WriteLine(to.Id);
            //    Console.WriteLine(to.OrgName);
            //    Console.WriteLine(to.OrgLevel);
            //    Console.WriteLine(to.ParentOrgId);
            //}
            //Console.ReadKey(); 

            //IThirdOrgDAL dAL = new ThirdOrgDAL();
            //foreach (var so in dAL.QueryByParentOrgId(10))
            //{
            //    Console.WriteLine(so.Id);
            //    Console.WriteLine(so.OrgName);
            //}
            //Console.ReadKey();

            #endregion

            #region 测试FirstOrgDAL
            //IFirstOrgDAL dAL = new FirstOrgDAL();
            //FirstOrg firstOrg = dAL.QueryById(10);
            //Console.WriteLine(firstOrg.OrgName);
            //Console.ReadKey(); 
            #endregion

            #region 测试OccupationClassDAL
            //IOccupationClassDAL dAL = new OccupationClassDAL();
            //foreach (var oc in dAL.Query())
            //{
            //    Console.WriteLine(oc.Id);
            //    Console.WriteLine(oc.Name);
            //}
            //Console.ReadKey();

            //Console.WriteLine(dAL.QueryById(1).Name);
            //Console.ReadKey(); 
            #endregion

            #region 测试TechnicalTitleDAL
            //ITechnicalTitleDAL dAL = new TechnicalTitleDAL();
            //foreach (var tt in dAL.Query())
            //{
            //    Console.WriteLine(tt.Id);
            //    Console.WriteLine(tt.Name);
            //}
            //Console.ReadKey(); 
            #endregion

            #region 测试SalaryStandardDAL，测试成功
            //ISalaryStandardDAL dAL = new SalaryStandardDAL();
            //Console.WriteLine(dAL.Add(new SalaryStandard { StandardName = "测试", StandardFileNumber = "ceshi", Registrant = "测试人", RegistTime = DateTime.Now, DesignBy = "测试人", Total = 3200 }));
            //Console.ReadKey(); 
            #endregion

            #region 测试StandardMapItemDAL
            //IStandardMapItemDAL dAL = new StandardMapItemDAL();
            //StandardMapItem standardMapItem = dAL.QueryById(1);
            //Console.WriteLine(standardMapItem.StandardId);
            //Console.ReadKey(); 
            #endregion

        }
    }
}
