using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public abstract class DataBase
    {
        public static string conStr = "";

        private SqlConnection con = null;

        private SqlCommand cmd = null;

        private SqlDataAdapter sda = null;

        protected SqlParameterCollection Parameters
        {
            get
            {
                return this.cmd.Parameters;
            }
        }

        protected string SpName
        {
            get
            {
                return this.cmd.CommandText;
            }
            set
            {
                this.cmd.CommandText = value;
            }
        }

        protected DataBase()
        {
            this.con = new SqlConnection(conStr);
            this.cmd = new SqlCommand();
            this.cmd.Connection = this.con;
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.CommandTimeout = 1000;
            this.sda = new SqlDataAdapter();
            this.sda.SelectCommand = this.cmd;
        }

        protected void Open()
        {
            if (this.con.State == ConnectionState.Closed)
            {
                this.con.Open();
            }
        }

        protected void Close()
        {
            if (this.con.State == ConnectionState.Open)
            {
                this.con.Close();
            }
        }

        protected void ClearSqlParameters()
        {
            this.cmd.Parameters.Clear();
        }

        protected SqlParameter AddSqlParameter(string parameterName, object value)
        {
            return this.AddSqlParameter(this.cmd, "@" + parameterName, value);
        }

        protected SqlParameter AddSqlParameter(string parameterName, object value, ParameterDirection parameterDirection)
        {
            return this.AddSqlParameter(this.cmd, "@" + parameterName, value, parameterDirection);
        }

        protected SqlParameter AddSqlParameter(string parameterName, object value, SqlDbType sqlDbType, int size, ParameterDirection parameterDirection)
        {
            return this.AddSqlParameter(this.cmd, "@" + parameterName, value, sqlDbType, size, parameterDirection);
        }

        protected SqlParameter AddSqlParameter(SqlCommand cmd, string parameterName, object value)
        {
            SqlParameter value2 = new SqlParameter(parameterName, value);
            return cmd.Parameters.Add(value2);
        }

        protected SqlParameter AddSqlParameter(SqlCommand cmd, string parameterName, object value, ParameterDirection parameterDirection)
        {
            SqlParameter sqlParameter = new SqlParameter(parameterName, value);
            sqlParameter.Direction = parameterDirection;
            return cmd.Parameters.Add(sqlParameter);
        }

        protected SqlParameter AddSqlParameter(SqlCommand cmd, string parameterName, object value, SqlDbType sqlDbType, int size, ParameterDirection parameterDirection)
        {
            SqlParameter sqlParameter = new SqlParameter(parameterName, sqlDbType, size);
            sqlParameter.Direction = parameterDirection;
            sqlParameter.Value = value;
            return cmd.Parameters.Add(sqlParameter);
        }

        protected DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                this.sda.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dataTable;
        }


    }
}
