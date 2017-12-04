namespace Model
{
    /// <summary>
    /// 薪酬标准与职位的映射关系表
    /// </summary>
    public class StandardMapOccupationName
    {

        public int Id { get; set; }

        public int StandardId { get; set; }

        public int OccupationNameId { get; set; }

    }
}
