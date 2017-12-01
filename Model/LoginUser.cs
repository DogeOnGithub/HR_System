using EnumState;

namespace Model
{
    /// <summary>
    /// 需要登录该系统的用户模型，即人力资源部门的工作人员
    /// </summary>
    public class LoginUser
    {

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public RoleLevelEnum RoleLevel { get; set; }

    }
}
