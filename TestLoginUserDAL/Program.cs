using HR_SystemDAL;
using HR_SystemIDAL;
using Model;
using System;

namespace TestLoginUserDAL
{
    /// <summary>
    /// 测试LoginUserDAL，测试成功
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //ILoginUserDAL dAL = new LoginUserDAL();
            //LoginUser loginUser = dAL.GetLoginUserByUsername("tjsanshao");
            //Console.WriteLine(loginUser.Password);
            //Console.ReadKey();

            ILoginUserDAL dAL = new LoginUserDAL();
            //foreach (var user in dAL.Query())
            //{
            //    Console.WriteLine(user.Id);
            //    Console.WriteLine(user.Username);
            //    Console.WriteLine(user.Password);
            //    Console.WriteLine(user.RoleLevel);
            //}

            //Console.ReadKey();

            //Console.WriteLine(dAL.Remove(3));
            //Console.ReadKey();

            //Console.WriteLine(dAL.Add(new LoginUser() { Username = "tjsanshao4", Password = "123456", RoleLevel = EnumState.RoleLevelEnum.SystemManager }));
            //Console.ReadKey();

            Console.WriteLine(dAL.Update(new LoginUser() { Id = 4, Username = "tjsanshao4Update", Password = "123456", RoleLevel = EnumState.RoleLevelEnum.Manager }));
            Console.ReadKey();

        }
    }
}
