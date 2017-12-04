using Model;
using HR_SystemIDAL;
using System.Collections.Generic;

namespace HR_SystemDAL
{
    public class StandardMapOccupationNameDAL : BaseHRSystemDAL<StandardMapOccupationName>, IStandardMapOccupationNameDAL
    {
        public List<StandardMapOccupationName> GetAllMapByStandardId(int standardId)
        {
            throw new System.NotImplementedException();
        }
    }
}
