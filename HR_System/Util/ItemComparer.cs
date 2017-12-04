using System;
using System.Collections.Generic;
using HR_System.Models;

namespace HR_System.Util
{
    public class ItemComparer : IEqualityComparer<SalaryItem>
    {
        public bool Equals(SalaryItem x, SalaryItem y)
        {
            //throw new NotImplementedException();

            return x.Id == y.Id;

        }

        public int GetHashCode(SalaryItem obj)
        {
            string name = obj.Name;
            return name.GetHashCode();
        }
    }
}