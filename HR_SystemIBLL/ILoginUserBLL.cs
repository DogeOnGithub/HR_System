using Model;

namespace HR_SystemIBLL
{
    /// <summary>
    /// 用户登录业务接口层
    /// </summary>
    public interface ILoginUserBLL
    {
        /// <summary>
        /// 根据用户名查询该用户的所有信息，因为要把用户信息存到session中，因此返回值是LoginUser类型
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>LoginUser对象</returns>
        LoginUser GetLoginUserByUsername(string username);

    }
}
