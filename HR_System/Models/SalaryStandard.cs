using EnumState;
using HR_System.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_System.Models
{
    public class SalaryStandard
    {

        private Dictionary<SalaryItem, decimal> itemAmout = new Dictionary<SalaryItem, decimal>(new ItemComparer());

        private List<OccupationName> occList = new List<OccupationName>();

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
        public StandardStateEnum StandardState { get; set; }

        /// <summary>
        /// 审核意见
        /// </summary>
        public string CheckDesc { get; set; }

        /// <summary>
        /// 审核人
        /// </summary>
        public string CheckBy { get; set; }

        //重点是薪酬标准和薪酬项目的映射关系
        /// <summary>
        /// 字典，键是薪酬项目对象，值是该薪酬项目在该薪酬项目中的金额
        /// </summary>
        public Dictionary<SalaryItem, decimal> ItemAmout
        {
            get => itemAmout;
            set => itemAmout = value;
        }

        /// <summary>
        /// 装载所有该标准适用的所有职位信息
        /// </summary>
        public List<OccupationName> OccList
        {
            get => occList;
            set => occList = value;
        }

    }
}