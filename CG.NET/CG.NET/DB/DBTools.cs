using CG.NET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public class DBTools
    {

        public static void Config(ServerModel server)
        {
            DBConfig.DBType = server.dbtype.ToLower();
            switch (DBConfig.DBType)
            {
                case "oracle":
                    DBConfig.ConnStr = "data source=" + server.server + ";User Id=" + server.name + ";Password=" + server.pwd + ";";
                    break;
                case "mssql":
                    DBConfig.ConnStr = "server=" + server.server + ";uid=" + server.name + ";pwd=" + server.pwd + ";";
                    break;
                case "mysql":
                    string port = "3306";
                    string[] ser = server.server.Split(':');
                    if (ser != null && ser.Length == 2)
                    {
                        server.server = ser[0];
                        port= ser[1];
                    }
                    DBConfig.ConnStr = $"server={server.server};user id={server.name}; password={server.pwd}; port={port}; charset=utf8";
                    break;

            }
        }

        public static DataTable ExcuteDataTable(string sql, ServerModel server)
        {
            Config(server);
            DBManager manager = new DBManager();
            return manager.ExcuteDataTable(sql,CommandType.Text);
        }

        public static DataTable GetDateTable(string name, ServerModel server)
        {
            Config(server);
            DBManager manager = new DBManager();
            return manager.GetDateTable(name);
        }
    }
}