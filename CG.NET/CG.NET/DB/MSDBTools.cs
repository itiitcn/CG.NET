using CG.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public class MSDBTools : DataBase
    {

        public void Login(ServerModel server)
        {
            this.conStr = "server=" + server.server + ";uid=" + server.name + ";pwd=" + server.pwd + ";";
        }

        public string conStr { get; set; }
        public DataTable GetDateTable(string Name)
        {
            DataBase.conStr = conStr;
            this.SpName = Name;
            this.ClearSqlParameters();
            return this.GetDataTable();
        }

        public DataSet SQLQuery(string SQLString)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                        command.Fill(ds, "ds");
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }


        public DataTable ExcuteDataTable(string sql, CommandType cmdType, params SqlParameter[] pms)
        {
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, conStr))
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
        }


    }
}