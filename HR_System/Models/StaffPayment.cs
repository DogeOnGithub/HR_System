using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_System.Models
{
    /// <summary>
    /// 视图模型StaffPayment
    /// </summary>
    public class StaffPayment
    {

        public int Id { get; set; }

        public StaffSalary StaffSalary { get; set; }

        public SalaryPayment SalaryPayment { get; set; }

        public decimal OddAmout { get; set; }

        public decimal MinusAmout { get; set; }

    }
}