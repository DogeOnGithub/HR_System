using Model;
using HR_SystemIDAL;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utils;
using System;

namespace HR_SystemDAL
{
    public class StandardMapOccupationNameDAL : BaseHRSystemDAL<StandardMapOccupationName>, IStandardMapOccupationNameDAL
    {
        public int DeleteAllOccMapByStandardId(int standardId)
        {
            //throw new System.NotImplementedException();

            string sql = "delete from StandardMapOccupationName where standardId=@standardId";

            return SQLHelper.ExecuteNonQuery(sql, new SqlParameter("@standardId", standardId));

        }

        public List<StandardMapOccupationName> GetAllMapByStandardId(int standardId)
        {
            //throw new System.NotImplementedException();

            List<StandardMapOccupationName> list = new List<StandardMapOccupationName>();

            string sql = "select * from StandardMapOccupationName where standardId=@standardId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@standardId", standardId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StandardMapOccupationName standardMapOccupationName = new StandardMapOccupationName
                        {
                            Id = reader.GetInt32(0),
                            StandardId = reader.GetInt32(1),
                            OccupationNameId = reader.GetInt32(2)
                        };
                        list.Add(standardMapOccupationName);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public StandardMapOccupationName GetMapByStandardIdAndOccNameId(int standardId, int OccNameId)
        {
            //throw new System.NotImplementedException();

            StandardMapOccupationName standardMapOccupationName = new StandardMapOccupationName();

            string sql = "select * from StandardMapOccupationName where standardId=@standardId and OccupationNameId=@occupationNameId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@standardId", standardId), new SqlParameter("@occupationNameId", OccNameId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        standardMapOccupationName.Id = reader.GetInt32(0);
                        standardMapOccupationName.StandardId = reader.GetInt32(1);
                        standardMapOccupationName.OccupationNameId = reader.GetInt32(2);
                    }
                }
                else
                {
                    standardMapOccupationName = null;
                }
            }

            return standardMapOccupationName;

        }
    }
}
