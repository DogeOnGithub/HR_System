using System.Collections.Generic;

namespace HR_SystemIDAL
{

    /// <summary>
    /// 数据库增删改查接口
    /// </summary>
    /// <typeparam name="T">Model类</typeparam>
    public interface IHRSystemDAL<T>
    {

        int Add(T t);

        int Remove(int id);

        int Update(T t);

        List<T> Query();

        T QueryById(int id);

    }
}
