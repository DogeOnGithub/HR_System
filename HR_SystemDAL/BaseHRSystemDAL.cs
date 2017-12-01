using HR_SystemIDAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Utils;

namespace HR_SystemDAL
{
    /// <summary>
    /// 数据库接口基础实现，利用反射和泛型
    /// </summary>
    /// <typeparam name="T">Model类</typeparam>
    public class BaseHRSystemDAL<T> : IHRSystemDAL<T> where T : class, new()
    {
        public virtual int Add(T t)
        {

            //获得T的类型
            Type type = typeof(T);

            //用StringBuilder拼接SQL语句
            StringBuilder builder = new StringBuilder("insert into " + type.Name + " values(");

            //获得T的所有属性
            var Properties = type.GetProperties();

            //循环遍历T的所有属性，拼接需要添加到数据库的记录的字段
            foreach (var p in Properties)
            {
                if (p.Name != "Id")
                {
                    builder.Append("@" + p.Name + ",");
                }
            }
            builder.Remove(builder.Length - 1, 1);
            builder.Append(")");

            string sql = builder.ToString();

            using (SqlConnection con = DBUtil.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //循环遍历T的所有属性，通过传进来的t对象建立SQL语句参数
                    foreach (var p in Properties)
                    {
                        if (p.Name != "Id")
                        {
                            cmd.Parameters.Add(new SqlParameter("@" + p.Name, p.GetValue(t)));
                        }
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        }

        public virtual List<T> Query()
        {
            //throw new NotImplementedException();

            List<T> list = new List<T>();

            Type type = typeof(T);

            //拼接SQL语句
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"select * from {0}", type.Name);

            string sql = builder.ToString();

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        T t = new T();

                        foreach (var p in type.GetProperties())
                        {
                            //从reader中取出相应列名的值放到t的相应属性中
                            p.SetValue(t, reader[p.Name]);
                        }

                        list.Add(t);
                    }
                }
            }


            return list;

        }

        public virtual T QueryById(int id)
        {
            //throw new NotImplementedException();

            Type type = typeof(T);

            T t = new T();

            string sql = "select * from " + type.Name + " where id = @id";

            using (SqlDataReader reader = SQLHelper.ExecuteReader(sql, new SqlParameter("@id", id)))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        foreach (var p in type.GetProperties())
                        {
                            p.SetValue(t, reader[p.Name]);
                        }
                    }
                }
                else
                {
                    return null;
                }
            }


            return t;

        }

        public virtual int Remove(int id)
        {
            //throw new NotImplementedException();

            Type type = typeof(T);

            StringBuilder builder = new StringBuilder();
            builder.AppendFormat(@"delete from {0} where id = @id", type.Name);

            //string sql = "delete from " + type.Name + " where id = @id";

            string sql = builder.ToString();

            return SQLHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));

        }

        public virtual int Update(T t)
        {

            Type type = typeof(T);

            //用StringBuilder拼接SQL语句
            StringBuilder builder = new StringBuilder("update " + type.Name + " set ");

            var Properties = type.GetProperties();

            foreach (var p in Properties)
            {
                if (p.Name != "Id")
                {
                    builder.Append(p.Name + "=@" + p.Name + ",");
                }
            }

            builder.Remove(builder.Length - 1, 1);
            builder.Append(" where id=@id");

            string sql = builder.ToString();

            using (SqlConnection con = DBUtil.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    //循环遍历T的所有属性，通过传进来的t对象建立SQL语句参数
                    foreach (var p in Properties)
                    {
                        cmd.Parameters.Add(new SqlParameter("@" + p.Name, p.GetValue(t)));
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
