namespace HR_System.Models
{
    /// <summary>
    /// 视图模型SecondOrg
    /// </summary>
    public class SecondeOrg
    {
        public int Id { get; set; }

        public string OrgName { get; set; }

        public int OrgLevel { get; set; }

        public FirstOrg ParentOrg { get; set; }
    }
}