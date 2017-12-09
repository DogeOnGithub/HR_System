using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_System.Models
{
    public class StaffSalary
    {
        public int Id { get; set; }
        public Staff Staff { get; set; }
        public string StaffFileNumber { get; set; }
        public ThirdOrg ThirdOrg { get; set; }
        public SalaryStandard SalaryStandard { get; set; }
    }
}