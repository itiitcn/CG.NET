using System;
using System.Collections.Generic;
using System.Text;

namespace CG.NET.Utils
{
    public class StringWorkClass
    {
        public StringWorkClass()
        {
        }

        #region 去掉字符串中间的空格的方法
        public static string ThrowOffSpace(string oldString)
        {
            char[] separator = new char[] { ' ' };
            string[] strarr = oldString.Split(separator);
            string newString = String.Concat(strarr);
            return newString;
        }
        #endregion

        #region 转换数据类型的方法
        public static string ChangeType(string oldType)
        {
            string newType = string.Empty;
            switch (oldType)
            {
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                case "binary":
                case "varbinary":
                case "image":
                case "smalldatetime":
                case "sysname":
                case "id":
                case "tid":
                    newType = "Convert.ToString";
                    break;
                case "datetime":
                    newType = "Convert.ToDateTime";
                    break;
                case "decimal":
                    newType = "Convert.ToDecimal";
                    break;
                case "money":
                case "smallmoney":
                case "numeric":
                case "float":
                case "real":
                    newType = "Convert.ToDouble";
                    break;
                case "bigint":
                    newType = "Convert.ToInt64";
                    break;
                case "smallint":
                case "int":
                case "tinyint":
                    newType = "Convert.ToInt32";
                    break;
                case "bit":
                    newType = "Convert.ToBoolean";
                    break;
                default:
                    newType = oldType;
                    break;
            }
            return newType;
        }
        #endregion


        public static string ChangeType1(string oldType)
        {
            string newType = string.Empty;
            switch (oldType)
            {
                case "varchar":
                    newType = "SqlDbType.VarChar";
                    break;
                case "nvarchar":
                    newType = "SqlDbType.NVarChar";
                    break;
                case "char":
                    newType = "SqlDbType.Char";
                    break;
                case "nchar":
                    newType = "SqlDbType.NChar";
                    break;
                case "text":
                    newType = "SqlDbType.Text";
                    break;
                case "ntext":
                    newType = "SqlDbType.NText";
                    break;
                case "binary":
                    newType = "SqlDbType.Binary";
                    break;
                case "varbinary":
                    newType = "SqlDbType.VarBinary";
                    break;
                case "image":
                    newType = "SqlDbType.Image";
                    break;
                case "smalldatetime":
                    newType = "SqlDbType.SmallDateTime";
                    break;
                case "datetime":
                    newType = "SqlDbType.DateTime";
                    break;
                case "decimal":
                    newType = "SqlDbType.Decimal";
                    break;
                case "money":
                    newType = "SqlDbType.Money";
                    break;
                case "smallmoney":
                    newType = "SqlDbType.SmallMoney";
                    break;
                case "float":
                    newType = "Convert.Float";
                    break;
                case "real":
                    newType = "SqlDbType.Real";
                    break;
                case "bigint":
                    newType = "SqlDbType.BigInt";
                    break;
                case "smallint":
                    newType = "SqlDbType.SmallInt";
                    break;
                case "int":
                    newType = "SqlDbType.Int";
                    break;
                case "tinyint":
                    newType = "SqlDbType.TinyInt";
                    break;
                case "bit":
                    newType = "SqlDbType.Bit";
                    break;
                default:
                    newType = "SqlDbType." + oldType;
                    break;
            }
            return newType;
        }


        public static string MSSQL2CsharpType(string oldType)
        {
            string newType = string.Empty;
            switch (oldType.ToLower())
            {
                case "uniqueidentifier":
                    newType = "Guid";
                    break;
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                case "binary":
                case "varbinary":
                case "image":
                case "smalldatetime":
                case "sysname":
                case "id":
                case "string":
                case "tid":
                    newType = "string";
                    break;
                case "date":
                case "datetime":
                    newType = "DateTime";
                    break;
                case "decimal":
                    newType = "decimal";
                    break;
                case "money":
                case "smallmoney":
                case "numeric":
                case "float":
                case "real":
                    newType = "double";
                    break;
                case "bigint":
                    newType = "long";
                    break;
                case "smallint":
                case "tinyint":
                case "int32":
                case "int":
                    newType = "int";
                    break;
                case "bit":
                    newType = "bool";
                    break;
                default:
                    newType = oldType;
                    break;
            }
            return newType;
        }


        public static string ORACLE2CsharpType(string oldType)
        {
            string newType = string.Empty;
            switch (oldType.ToLower())
            {
                case "uniqueidentifier":
                    newType = "Guid";
                    break;
                case "varchar":
                case "nvarchar":
                case "char":
                case "nchar":
                case "text":
                case "ntext":
                case "binary":
                case "varbinary":
                case "image":
                case "smalldatetime":
                case "sysname":
                case "id":
                case "string":
                case "tid":
                    newType = "string";
                    break;
                case "date":
                case "datetime":
                    newType = "DateTime";
                    break;
                case "decimal":
                    newType = "decimal";
                    break;
                case "money":
                case "smallmoney":
                case "numeric":
                case "float":
                case "real":
                    newType = "double";
                    break;
                case "bigint":
                    newType = "long";
                    break;
                case "smallint":
                case "tinyint":
                case "int32":
                case "int":
                    newType = "int";
                    break;
                case "bit":
                    newType = "bool";
                    break;
                default:
                    newType = oldType;
                    break;
            }
            return newType;
        }

    }
}
