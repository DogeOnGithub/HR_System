namespace HR_System.Models
{
    /// <summary>
    /// 视图模型ThirdOrg
    /// </summary>
    public class ThirdOrg
    {
        public int Id { get; set; }

        public string OrgName { get; set; }

        public int OrgLevel { get; set; }

        public SecondeOrg ParentOrg { get; set; }
    }
}