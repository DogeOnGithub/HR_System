using HR_SystemIDAL;
using Model;
using System.Data.SqlClient;
using Utils;
using EnumState;

namespace HR_SystemDAL
{
    public class LoginUserDAL : BaseHRSystemDAL<LoginUser>, ILoginUserDAL
    {

        /// <summary>
        /// 实现ILoginUserDAL接口，根据用户名查询该用户的所有信息
        /// </summary>
        /// <param name="username">输入的用户名参数</param>
        /// <returns>返回符合用户名的用户的所有信息，LoginUser对象</returns>
        public LoginUser GetLoginUserByUsername(string username)
        {
            //throw new NotImplementedException();

            LoginUser loginUser = null;

            string sql = @"select * from LoginUser where username=@username";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@username", username)))
            {
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        LoginUser user = new LoginUser();
                        user.Id = reader.GetInt32(0);
                        user.Username = reader.GetString(1);
                        user.Password = reader.GetString(2);
                        user.RoleLevel = (RoleLevelEnum)reader.GetInt32(3);
                        loginUser = user;
                    }
                }
            }

            return loginUser;

        }

    }
}
