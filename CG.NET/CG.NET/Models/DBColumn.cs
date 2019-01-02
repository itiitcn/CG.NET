using CG.NET.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.NET.Models
{
    public class DBColumn
    {
        public DBColumn()
        {

        }
        private char separator { get; set; }
        public DBColumn(DataRow dr,string DBType)
        {
            if (dr != null)
            {
                if (!DBNull.Value.Equals(dr["Name"])) this.Name = Convert.ToString(dr["Name"]);
                if (!DBNull.Value.Equals(dr["Type"])) this.Type = Convert.ToString(dr["Type"]);
                if (!DBNull.Value.Equals(dr["Length"])) this.Length = Convert.ToInt16(dr["Length"]);
                if (!DBNull.Value.Equals(dr["Prec"])) this.Prec = Convert.ToByte(dr["Prec"]);
                if (!DBNull.Value.Equals(dr["Scale"])) this.Scale = Convert.ToByte(dr["Scale"]);
                if (!DBNull.Value.Equals(dr["IsNull"])) this.IsNull = Convert.ToBoolean(dr["IsNull"]);
                if (!DBNull.Value.Equals(dr["PrimaryKey"])) this.PrimaryKey = Convert.ToBoolean(dr["PrimaryKey"]);
                if (!DBNull.Value.Equals(dr["Default"])) this.Default = Convert.ToString(dr["Default"]);
                if (!DBNull.Value.Equals(dr["Description"])) this.Description = Convert.ToString(dr["Description"]);
                if (!DBNull.Value.Equals(dr["TableName"])) this.TableName = Convert.ToString(dr["TableName"]);
            }
            this.DBType = DBType;
        }

        public DBColumn(DBColumn column, char separator = '_')
        {
            this.separator = separator;
            if (column != null)
            {
                this.Name = column.Name.Camel();
                if (column.DBType == "MSSQL")
                {
                    this.Type = StringWorkClass.MSSQL2CsharpType(column.Type);
                }
                if (column.DBType == "ORACLE")
                {
                    this.Type = StringWorkClass.MSSQL2CsharpType(column.Type);
                }
                this.Length = column.Length;
                this.Prec = column.Prec;
                this.Scale = column.Scale;
                this.IsNull = column.IsNull;
                this.PrimaryKey = column.PrimaryKey;
                this.Default = column.Default;
                this.Description = column.Description;
                this.TableName = column.TableName;
            }
        }

        public string DBType { get; set; }

        public string Details
        {
            get
            {
                List<string> vs = new List<string>();
                if (this.PrimaryKey)
                {
                    vs.Add("PK");
                }
                switch (this.Type.ToLower())
                {
                    case "varchar":
                        vs.Add($"{this.Type}({this.Length})");
                        break;
                    case "nvarchar":
                        vs.Add($"{this.Type}({this.Length / 2})");
                        break;
                    case "double":
                    case "decimal":
                        vs.Add($"{this.Type}({this.Length},{this.Scale})");
                        break;
                    default:
                        vs.Add($"{this.Type}");
                        break;
                }
                vs.Add($"{(this.IsNull?"null":"not null")}");
                return $"({string.Join(",", vs.ToArray())})";
            }
        }

        public string TableName { get; set; }

        public string Name { set; get; }
        public string Type { set; get; }
        public int Length { set; get; }
        public int Prec { set; get; }
        public int Scale { set; get; }
        public bool IsNull { set; get; }
        public bool PrimaryKey { set; get; }
        public string Default { set; get; }
        public string Description { set; get; }

    }
}
