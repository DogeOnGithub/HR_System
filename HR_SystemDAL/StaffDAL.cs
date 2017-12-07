using System.Collections.Generic;
using HR_SystemIDAL;
using Model;
using System.Data.SqlClient;
using Utils;
using System;

namespace HR_SystemDAL
{
    public class StaffDAL : BaseHRSystemDAL<Staff>, IStaffDAL
    {
        public List<Staff> GetAllStaffDeleted()
        {
            //throw new NotImplementedException();

            List<Staff> list = new List<Staff>();

            string sql = "select * from Staff where isDel=1";

            Type type = typeof(Staff);

            var props = type.GetProperties();

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        foreach (var p in props)
                        {
                            p.SetValue(staff, reader[p.Name]);
                        }

                        list.Add(staff);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public List<Staff> GetAllStaffNormal()
        {
            //throw new NotImplementedException();

            List<Staff> list = new List<Staff>();

            string sql = "select * from Staff where isDel=0";

            Type type = typeof(Staff);

            var props = type.GetProperties();

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        foreach (var p in props)
                        {
                            p.SetValue(staff, reader[p.Name]);
                        }

                        list.Add(staff);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public List<Staff> GetAllStaffWaitCheck()
        {
            //throw new System.NotImplementedException();

            List<Staff> list = new List<Staff>();

            string sql = "select * from Staff where fileState=0";

            Type type = typeof(Staff);

            var props = type.GetProperties();

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        foreach (var p in props)
                        {
                            p.SetValue(staff, reader[p.Name]);
                        }

                        list.Add(staff);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public List<Staff> GetAllStaffWaitCheckNormal()
        {
            //throw new NotImplementedException();

            List<Staff> list = new List<Staff>();

            string sql = "select * from Staff where fileState=0 and isDel=0";

            Type type = typeof(Staff);

            var props = type.GetProperties();

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Staff staff = new Staff();

                        foreach (var p in props)
                        {
                            p.SetValue(staff, reader[p.Name]);
                        }

                        list.Add(staff);
                    }
                }
                else
                {
                    list = null;
                }
            }

            return list;

        }

        public int LoginDeleteStaff(int id)
        {
            //throw new NotImplementedException();

            string sql = "update Staff set IsDel=1 where id=@id";

            return SQLHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));

        }

        public int ReturnStaff(int id)
        {
            //throw new NotImplementedException();

            string sql = "update Staff set IsDel=0 where id=@id";

            return SQLHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));

        }
    }
}
