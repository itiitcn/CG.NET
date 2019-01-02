using CG.NET.Models;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public class DBManager : SqlDataBase
    {
       
        public DataTable GetDateTable(string Name)
        {
            this.SpName = Name;
            this.ClearParameters();
            return this.GetDataTable();
        }

        public DataTable ExcuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            switch (DBConfig.DBType.ToLower())
            {
                case "oracle":
                    using (OracleDataAdapter sda = new OracleDataAdapter(sql, DBConfig.ConnStr))
                    {
                        DataTable dt = new DataTable();
                        sda.SelectCommand.CommandType = cmdType;
                        if (pms != null)
                        {
                            sda.SelectCommand.Parameters.AddRange(pms);
                        }
                        sda.Fill(dt);
                        return dt;
                    }
                case "mssql":
                    using (SqlDataAdapter sda = new SqlDataAdapter(sql, DBConfig.ConnStr))
                    {
                        DataTable dt = new DataTable();
                        sda.SelectCommand.CommandType = cmdType;
                        if (pms != null)
                        {
                            sda.SelectCommand.Parameters.AddRange(pms);
                        }
                        sda.Fill(dt);
                        return dt;
                    }
                case "mysql":
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(sql, DBConfig.ConnStr))
                    {
                        DataTable dt = new DataTable();
                        sda.SelectCommand.CommandType = cmdType;
                        if (pms != null)
                        {
                            sda.SelectCommand.Parameters.AddRange(pms);
                        }
                        sda.Fill(dt);
                        return dt;
                    }
                default:
                    return null;
            }
        }


    }
}