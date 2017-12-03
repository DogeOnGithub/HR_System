using System;

namespace Model
{
    /// <summary>
    /// 薪酬标准
    /// </summary>
    public class SalaryStandard
    {

        public int Id { get; set; }

        public string StandardName { get; set; }

        /// <summary>
        /// 该薪酬标准的编号
        /// </summary>
        public string StandardFileNumber { get; set; }

        /// <summary>
        /// 薪酬标准登记人
        /// </summary>
        public string Registrant { get; set; }

        public DateTime RegistTime { get; set; }

        /// <summary>
        /// 薪酬标准制定人
        /// </summary>
        public string DesignBy { get; set; }

        /// <summary>
        /// 该薪酬标准的总金额
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// 该薪酬标准的状态
        /// </summary>
        public int StandardState { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string CheckDesc { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckBy { get; set; }

    }
}
