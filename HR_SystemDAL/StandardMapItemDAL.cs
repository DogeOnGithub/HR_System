using System.Collections.Generic;
using HR_SystemIDAL;
using Model;
using System.Data.SqlClient;
using Utils;

namespace HR_SystemDAL
{
    public class StandardMapItemDAL : BaseHRSystemDAL<StandardMapItem>, IStandardMapItemDAL
    {
        public List<StandardMapItem> GetAllStandardMapItemByStandardId(int standardId)
        {
            //throw new System.NotImplementedException();

            List<StandardMapItem> list = new List<StandardMapItem>();

            string sql = "select * from StandardMapItem where standardId=@standardId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@standardId", standardId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        StandardMapItem item = new StandardMapItem
                        {
                            Id = reader.GetInt32(0),
                            StandardId = reader.GetInt32(1),
                            ItemId = reader.GetInt32(2),
                            Amout = reader.GetDecimal(3)
                        };
                        list.Add(item);
                    }
                }
                else
                {
                    list = null;
                }
            }


            return list;
        }

        public StandardMapItem GetStandardMapItemByStandardAndItem(int standardId, int itemId)
        {
            //throw new System.NotImplementedException();

            StandardMapItem standardMapItem = new StandardMapItem();

            string sql = "select * from StandardMapItem where standardId=@standardId and itemId=@itemId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@standardId", standardId), new SqlParameter("@itemId", itemId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        standardMapItem.Id = reader.GetInt32(0);
                        standardMapItem.StandardId = reader.GetInt32(1);
                        standardMapItem.ItemId = reader.GetInt32(2);
                        standardMapItem.Amout = reader.GetDecimal(3);
                    }
                }
                else
                {
                    standardMapItem = null;
                }
            }

            return standardMapItem;

        }
    }
}
