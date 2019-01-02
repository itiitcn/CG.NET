using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG.NET.DB
{
    public class DBDataType
    {
        public static SqlDbType GetSqlDbType(DBType type)
        {
            switch (type)
            {
                case DBType.Bool:
                    return SqlDbType.Bit;
                case DBType.Int:
                    return SqlDbType.Int;
                case DBType.Long:
                    return SqlDbType.BigInt;
                case DBType.Char:
                    return SqlDbType.Char;
                case DBType.DateTime:
                    return SqlDbType.DateTime;
                case DBType.Decimal:
                    return SqlDbType.Decimal;
                case DBType.Double:
                    return SqlDbType.Float;
                case DBType.NVarChar:
                    return SqlDbType.NVarChar;
                case DBType.UniqueIdentifier:
                    return SqlDbType.UniqueIdentifier;
                case DBType.VarChar:
                    return SqlDbType.VarChar;
                case DBType.Date:
                    return SqlDbType.Date;
                case DBType.Xml:
                    return SqlDbType.Xml;
                default:
                    return SqlDbType.NVarChar;
            }
        }

        public static OracleDbType GetOracleDbType(DBType type)
        {
            switch (type)
            {
                case DBType.Bool:
                    return OracleDbType.Boolean;
                case DBType.Int:
                    return OracleDbType.Int32;
                case DBType.Long:
                    return OracleDbType.Int64;
                case DBType.Char:
                    return OracleDbType.Char;
                case DBType.Date:
                case DBType.DateTime:
                    return OracleDbType.Date;
                case DBType.Decimal:
                    return OracleDbType.Decimal;
                case DBType.Double:
                    return OracleDbType.Double;
                case DBType.UniqueIdentifier:
                case DBType.NVarChar:
                    return OracleDbType.NVarchar2;
                case DBType.VarChar:
                    return OracleDbType.Varchar2;
                case DBType.Xml:
                    return OracleDbType.XmlType;
                default:
                   return OracleDbType.NVarchar2;
            }
        }

        public static MySqlDbType GetMySqlDbType(DBType type)
        {
            switch (type)
            {
                case DBType.Bool:
                    return MySqlDbType.Bit;
                case DBType.Int:
                    return MySqlDbType.Int32;
                case DBType.Long:
                    return MySqlDbType.Int64;
                case DBType.Char:
                    return MySqlDbType.VarChar;
                case DBType.Date:
                    return MySqlDbType.Date;
                case DBType.DateTime:
                    return MySqlDbType.DateTime;
                case DBType.Decimal:
                    return MySqlDbType.Decimal;
                case DBType.Double:
                    return MySqlDbType.Double;
                case DBType.UniqueIdentifier:
                    return MySqlDbType.Guid;
                case DBType.NVarChar:
                    return MySqlDbType.VarChar;
                case DBType.VarChar:
                    return MySqlDbType.VarChar;
                case DBType.Xml:
                    return MySqlDbType.VarChar;
                default:
                    return MySqlDbType.VarChar;
            }
        }

    }

    public enum DBType
    {
        Bool=0,
        Int = 1,
        Long = 2,
        Char = 4,
        DateTime = 5,
        Decimal = 6,
        Double = 7,
        NVarChar = 8,
        UniqueIdentifier = 9,
        VarChar = 10,
        Date = 11,
        Xml = 12,

    }
}
