using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace TestDBUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DBUtil.GetConnection().ToString());
            Console.ReadKey();
        }
    }
}
