using Model;

namespace HR_SystemIDAL
{
    /// <summary>
    /// LoginUser表数据访问接口
    /// </summary>
    public interface ILoginUserDAL : IHRSystemDAL<LoginUser>
    {

        /// <summary>
        ///根据用户名查询该用户的所有信息 
        /// </summary>
        /// <param name="username">输入的用户名参数</param>
        /// <returns>返回符合用户名的用户的所有信息，LoginUser对象</returns>
        LoginUser GetLoginUserByUsername(string username);

    }
}
