using HR_SystemBLL;
using HR_SystemIBLL;
using Model;
using System;

namespace TestLoginUserBLL
{
    /// <summary>
    /// 测试LoginUserBLL，测试成功
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ILoginUserBLL bLL = new LoginUserBLL();
            LoginUser loginUser = bLL.GetLoginUserByUsername("tjsanshao");
            Console.WriteLine(loginUser.Password);
            Console.ReadKey();
        }
    }
}
