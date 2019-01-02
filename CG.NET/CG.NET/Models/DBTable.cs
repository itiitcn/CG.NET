using CG.NET.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.NET.Models
{
    public class DBTable
    {
        public DBTable()
        {
            this.separator = '_';
        }
        public DBTable(char separator='_')
        {
            this.separator = separator;
        }
        private char separator { get; set; }
        /// <summary>
        /// 命名空间
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
               return this.SqlTableName.Replace("T_","").Pascal(separator);
            }
        }
        /// <summary>
        /// 数据库表名
        /// </summary>
        public string SqlTableName { get; set; }
        /// <summary>
        /// 全部列
        /// </summary>
        public List<IColumn> Columns { get; set; }


    }


}
