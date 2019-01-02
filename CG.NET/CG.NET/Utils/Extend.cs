using CG.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CG.NET.Utils
{
    public static class Extend
    {
        public static DBTable ToSQLColumns(this DataTable dt, string Namespace, string TableName,string DBType, char separator = '_')
        {
            DBTable dBTable = new DBTable(separator);
            dBTable.Namespace = Namespace;
            dBTable.SqlTableName = TableName;
            List<IColumn> Columns = null;
            if (dt != null && dt.Rows != null)
            {
                Columns = new List<IColumn>();
                foreach (DataRow dr in dt.Rows)
                {
                    Columns.Add(new IColumn(dr, DBType));
                }
            }
            dBTable.Columns = Columns;
            return dBTable;
        }

        /// <summary>
        /// 首字母大写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UpperFirst(this string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// 首字母转小写
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string LowerFirst(this string s)
        {
            return char.ToLower(s[0]) + s.Substring(1);
        }

        /// <summary>
        /// Pascal命名 每个单词开头的字母大写(如 TestCounter).
        /// </summary>
        /// <param name="s">待处理字符串</param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Pascal(this string s, char separator = '_')
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (s.Length > 3)
                {
                    string[] ss = s.Split(separator);
                    if (ss != null && ss.Length > 0)
                    {
                        return string.Join("", ss.Select(x => x.UpperFirst()));
                    }
                    else
                    {
                        return s;
                    }
                }
                else
                {
                    return s.Trim(separator).ToUpper();
                }
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Camel 命名 除了第一个单词外的其他单词的开头字母大写. 如. testCounter.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string Camel(this string s, char separator = '_')
        {
            if (!string.IsNullOrWhiteSpace(s))
            {
                if (s.Length > 3)
                {
                    string[] ss = s.Split(separator);
                    if (ss != null && ss.Length > 0)
                    {
                        s = string.Join("", ss.Select(x => x.UpperFirst()));
                        return s.LowerFirst();
                    }
                    else
                    {
                        return s;
                    }

                }
                else
                {
                    return s.Trim(separator).ToUpper();
                }
            }
            else
            {
                return s;
            }
        }
    }
}