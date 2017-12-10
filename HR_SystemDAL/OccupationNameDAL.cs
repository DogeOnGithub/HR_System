using System.Collections.Generic;
using HR_SystemIDAL;
using Model;
using System.Data.SqlClient;
using Utils;

namespace HR_SystemDAL
{
    public class OccupationNameDAL : BaseHRSystemDAL<OccupationName>, IOccupationNameDAL
    {
        public List<OccupationName> GetAllOccNameByClassId(int classId)
        {
            //throw new System.NotImplementedException();

            List<OccupationName> list = new List<OccupationName>();

            string sql = "select * from OccupationName where classId=@classId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@classId", classId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        OccupationName occupationName = new OccupationName
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ClassId = reader.GetInt32(2)
                        };
                        list.Add(occupationName);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public OccupationName GetOccupationNameByNameAndClass(string name, int classId)
        {
            //throw new System.NotImplementedException();

            OccupationName occupationName = new OccupationName();

            string sql = "select * from OccupationName where name=@name and classId=@classId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@name", name), new SqlParameter("@classId", classId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        occupationName = new OccupationName
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ClassId = reader.GetInt32(2)
                        };
                    }
                }
                else
                {
                    occupationName = null;
                }
            }

            return occupationName;

        }
    }
}
