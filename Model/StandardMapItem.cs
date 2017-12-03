namespace Model
{
    public class StandardMapItem
    {

        /// <summary>
        /// 主键id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 外键，薪酬标准的id
        /// </summary>
        public int StandardId { get; set; }

        /// <summary>
        /// 外键，薪酬项目的id
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// 该薪酬标准对应的薪酬项目的金额
        /// </summary>
        public decimal Amout { get; set; }

    }
}
