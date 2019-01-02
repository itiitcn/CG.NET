using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CG.NET.DB
{
    public abstract class SqlDataBase
    {

        private DbConnection conn = null;

        private DbCommand cmd = null;

        private DbDataAdapter sda = null;



        protected SqlDataBase()
        {
            if (DBConfig.DBType=="oracle")
            {
                conn = new OracleConnection(DBConfig.ConnStr);
                cmd = new OracleCommand();
                sda = new OracleDataAdapter();
            }
            if (DBConfig.DBType == "mssql")
            {
                conn = new SqlConnection(DBConfig.ConnStr);
                cmd = new SqlCommand();
                sda = new SqlDataAdapter();
            }
            if (DBConfig.DBType == "mysql")
            {
                conn = new MySqlConnection(DBConfig.ConnStr);
                cmd = new MySqlCommand();
                sda = new MySqlDataAdapter();
                
            }
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 1000;
            sda.SelectCommand = cmd;
        }

        protected void Open()
        {
            if (conn.State == ConnectionState.Closed || conn.State == ConnectionState.Broken)
            {
                conn.Open();
            }
        }


        protected void Close()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }


        public DbParameter GetParameter(string Name)
        {
            if (DBConfig.DBType=="oracle")
            {
                return cmd.Parameters[Name];
            }
            else
            {
                return cmd.Parameters["@" + Name];
            }
        }


        protected DbParameterCollection Parameters
        {
            get
            {
                return cmd.Parameters;
            }
        }

        protected void ClearParameters()
        {
            cmd.Parameters.Clear();
        }

        protected string SpName
        {
            get
            {
                return cmd.CommandText;
            }
            set
            {
                cmd.CommandText = value;
            }
        }



        protected DbParameter AddParameter(string parameterName, object value)
        {

            if (DBConfig.DBType=="oracle")
            {
                return AddParameter(cmd, ":" + parameterName, value);
            }
            else
            {
                return AddParameter(cmd, "@" + parameterName, value);
            }
        }


        protected DbParameter AddParameter(string parameterName, object value, ParameterDirection parameterDirection)
        {

            if (DBConfig.DBType == "oracle")
            {
                return AddParameter(cmd, ":" + parameterName, value, parameterDirection);
            }
            else
            {
                return AddParameter(cmd, "@" + parameterName, value, parameterDirection);
            }
        }



        protected DbParameter AddParameter(string parameterName, object value, DBType Type, int size, ParameterDirection parameterDirection)
        {
            if (DBConfig.DBType == "oracle")
            {
                //OracleParameter
                OracleDbType DbType = DBDataType.GetOracleDbType(Type);
                return AddParameter(cmd, ":" + parameterName, value, Type, size, parameterDirection);
            }
            else
            {
                //SqlParameter
                SqlDbType DbType = DBDataType.GetSqlDbType(Type);
                return AddParameter(cmd, "@" + parameterName, value, Type, size, parameterDirection);
            }
        }




        protected DbParameter AddParameter(DbCommand cmd, string parameterName, object value)
        {
            if (DBConfig.DBType == "oracle")
            {
                OracleCommand ocmd = (OracleCommand)cmd;
                OracleParameter sp = new OracleParameter(parameterName, value);
                return ocmd.Parameters.Add(sp);
            }
            if (DBConfig.DBType == "mssql")
            {
                SqlCommand scmd = (SqlCommand)cmd;
                SqlParameter sp = new SqlParameter(parameterName, value);
                return scmd.Parameters.Add(sp);
            }
            if (DBConfig.DBType == "mysql")
            {
                MySqlCommand scmd = (MySqlCommand)cmd;
                MySqlParameter sp = new MySqlParameter(parameterName, value);
                return scmd.Parameters.Add(sp);
            }
            return null;
        }





        protected DbParameter AddParameter(DbCommand cmd, string parameterName, object value, ParameterDirection parameterDirection)
        {
            if (DBConfig.DBType == "oracle")
            {
                OracleCommand ocmd = (OracleCommand)cmd;
                OracleParameter sp = new OracleParameter(parameterName, value);
                sp.Direction = parameterDirection;
                return ocmd.Parameters.Add(sp);
            }
            if (DBConfig.DBType == "mssql")
            {
                SqlCommand scmd = (SqlCommand)cmd;
                SqlParameter sp = new SqlParameter(parameterName, value);
                sp.Direction = parameterDirection;
                return scmd.Parameters.Add(sp);
            }
            if (DBConfig.DBType == "mysql")
            {
                MySqlCommand scmd = (MySqlCommand)cmd;
                MySqlParameter sp = new MySqlParameter(parameterName, value);
                sp.Direction = parameterDirection;
                return scmd.Parameters.Add(sp);
            }
            return null;
        }


        protected DbParameter AddParameter(DbCommand cmd, string parameterName, object value, DBType Type, int size, ParameterDirection parameterDirection)
        {
            if (DBConfig.DBType == "oracle")
            {
                OracleCommand ocmd = (OracleCommand)cmd;
                OracleDbType DbType = DBDataType.GetOracleDbType(Type);
                OracleParameter sp = new OracleParameter(parameterName, DbType, size);
                sp.Direction = parameterDirection;
                sp.Value = value;
                return ocmd.Parameters.Add(sp);
            }
            if (DBConfig.DBType == "mssql")
            {
                SqlCommand scmd = (SqlCommand)cmd;
                SqlDbType DbType = DBDataType.GetSqlDbType(Type);
                SqlParameter sp = new SqlParameter(parameterName, DbType, size);
                sp.Direction = parameterDirection;
                sp.Value = value;
                return scmd.Parameters.Add(sp);
            }
            if (DBConfig.DBType == "mysql")
            {
                MySqlCommand scmd = (MySqlCommand)cmd;
                MySqlDbType DbType = DBDataType.GetMySqlDbType(Type);
                MySqlParameter sp = new MySqlParameter(parameterName, DbType, size);
                sp.Direction = parameterDirection;
                sp.Value = value;
                return scmd.Parameters.Add(sp);
            }
            return null;
        }





        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <returns></returns>
        protected DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                sda.Fill(dataTable);
            }
            catch (Exception ex)
            {
                throw;
            }
            return dataTable;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <returns></returns>
        protected bool GetOutput()
        {
            bool result = false;
            SqlConnection sqlConnection = new SqlConnection(DBConfig.ConnStr);
            try
            {
                Open();
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Close();
            }
            return result;
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <returns></returns>
        protected object GetScalar()
        {
            object result = null;
            try
            {
                Open();
                cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                Close();
            }
            return result;
        }


    }
}