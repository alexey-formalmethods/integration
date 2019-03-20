using System;
using System.Collections.Generic;
using System.Text;

namespace bi_dev.integration.utils.storage.MsSql
{
    public static class Extensions
    {
        public static string GetSqlServerTypeName(this Type type)
        {
            if (type == typeof(string))
            {
                return "nvarchar(max)";
            }
            else if (type == typeof(int))
            {
                return "int";
            }
            else if (type == typeof(DateTime))
            {
                return "datetime";
            }
            else return "nvarchar(max)";




        }
    }
}
