using EnumState;

namespace HR_System.Models
{
    /// <summary>
    /// 视图模型LoginUser
    /// </summary>
    public class LoginUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public RoleLevelEnum RoleLevel { get; set; }
    }
}