using HR_SystemIBLL;
using Model;
using HR_SystemIDAL;
using HR_SystemDAL;

namespace HR_SystemBLL
{
    /// <summary>
    /// 实现ILoginUserBLL接口
    /// </summary>
    public class LoginUserBLL : ILoginUserBLL
    {
        /// <summary>
        /// 实现ILoginUserBLL接口
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回LoginUser对象</returns>
        public LoginUser GetLoginUserByUsername(string username)
        {
            //throw new NotImplementedException();

            ILoginUserDAL dAL = new LoginUserDAL();
            return dAL.GetLoginUserByUsername(username);

        }
    }
}
