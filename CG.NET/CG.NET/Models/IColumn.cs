using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.NET.Models
{
    public class IColumn
    {

        public IColumn()
        {

        }
        private char separator { get; set; }
        public IColumn(DataRow dr,string DBType,char separator='_')
        {
            this.DB = new DBColumn(dr, DBType);
            this.Col = new DBColumn(this.DB, separator);
        }

        /// <summary>
        /// 数据库列
        /// </summary>
        public DBColumn DB { get; set; }
        /// <summary>
        /// 实体列
        /// </summary>
        public DBColumn Col { get; set; }
    }
}
