using HR_SystemIDAL;
using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Utils;

namespace HR_SystemDAL
{
    public class SecondOrgDAL : BaseHRSystemDAL<SecondOrg>, ISecondOrgDAL
    {
        /// <summary>
        /// 根据1级机构的Id查询所有2级机构，返回一个List
        /// </summary>
        /// <param name="parentId">1级机构Id</param>
        /// <returns>返回所有符合1级机构Id的SecondeOrg对象的List集合</returns>
        public List<SecondOrg> QueryByParentOrgId(int parentOrgId)
        {
            //throw new NotImplementedException();

            List<SecondOrg> list = new List<SecondOrg>();

            string sql = "select * from SecondOrg where parentOrgId=@parentOrgId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@parentOrgId", parentOrgId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SecondOrg secondOrg = new SecondOrg();
                        secondOrg.Id = reader.GetInt32(0);
                        secondOrg.OrgName = reader.GetString(1);
                        secondOrg.OrgLevel = reader.GetInt32(2);
                        secondOrg.ParentOrgId = reader.GetInt32(3);
                        list.Add(secondOrg);
                    }
                }
                else
                {
                    return null;
                }
            }


            return list;

        }
    }
}
