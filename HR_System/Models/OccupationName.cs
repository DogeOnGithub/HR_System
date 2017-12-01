namespace HR_System.Models
{
    /// <summary>
    /// 视图模型OccupationName
    /// </summary>
    public class OccupationName
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public OccupationClass OccupationClass { get; set; }
    }
}