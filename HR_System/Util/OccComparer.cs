using HR_System.Models;
using System.Collections.Generic;

namespace HR_System.Util
{
    public class OccComparer : IEqualityComparer<OccupationName>
    {
        public bool Equals(OccupationName x, OccupationName y)
        {
            //throw new NotImplementedException();

            return x.Id == y.Id;
        }

        public int GetHashCode(OccupationName obj)
        {
            //throw new NotImplementedException();

            return obj.Name.GetHashCode();
        }
    }
}