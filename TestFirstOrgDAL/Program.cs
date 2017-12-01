using HR_SystemDAL;
using HR_SystemIDAL;
using Model;
using System;
using System.Collections.Generic;

namespace TestFirstOrgDAL
{
    /// <summary>
    /// 测试FirstOrgDAL, 成功
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(new FirstOrgDAL().AddFirstOrg(new FirstOrg() { OrgName = "大集团1", OrgLevel = 1 }));
            //Console.ReadKey();


            //List<FirstOrg> list = new FirstOrgDAL().GetAllFirstOrg();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.Id + "-" + item.OrgName + "-" + item.OrgLevel);
            //}
            //Console.ReadKey();

            //Console.WriteLine(new FirstOrgDAL().RemoveFirstOrgById(13));
            //Console.ReadKey();

            //Console.WriteLine(new FirstOrgDAL().UpdateFirstOrg(new FirstOrg() { Id = 11, OrgName = "第二集团", OrgLevel = 1 }));
            //Console.ReadKey();

            IFirstOrgDAL dAL = new FirstOrgDAL();


            //dAL.Add(new FirstOrg() { OrgName = "第fdhkjh集团", OrgLevel = 1 });
            //Console.ReadKey();

            //foreach (var o in dAL.Query())
            //{
            //    Console.WriteLine(o.Id);
            //    Console.WriteLine(o.OrgName);
            //    Console.WriteLine(o.OrgLevel);
            //}
            //Console.ReadKey();

            //Console.WriteLine(dAL.Update(new FirstOrg() { Id = 10, OrgName = "第一集团", OrgLevel = 1 }));
            //Console.ReadKey();

            Console.WriteLine(dAL.Remove(15));
            Console.ReadKey();

        }
    }
}
