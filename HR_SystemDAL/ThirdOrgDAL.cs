using HR_SystemIDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace HR_SystemDAL
{
    public class ThirdOrgDAL : BaseHRSystemDAL<ThirdOrg>, IThirdOrgDAL
    {

        /// <summary>
        /// 根据2级机构的Id查询所有2级机构，返回一个List
        /// </summary>
        /// <param name="parentId">2级机构Id</param>
        /// <returns>返回所有符合2级机构Id的SecondeOrg对象的List集合</returns>
        public List<ThirdOrg> QueryByParentOrgId(int parentOrgId)
        {
            //throw new NotImplementedException();

            List<ThirdOrg> list = new List<ThirdOrg>();

            string sql = "select * from ThirdOrg where parentOrgId=@parentOrgId";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@parentOrgId", parentOrgId)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ThirdOrg thirdOrg = new ThirdOrg();
                        thirdOrg.Id = reader.GetInt32(0);
                        thirdOrg.OrgName = reader.GetString(1);
                        thirdOrg.OrgLevel = reader.GetInt32(2);
                        thirdOrg.ParentOrgId = reader.GetInt32(3);
                        list.Add(thirdOrg);
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
