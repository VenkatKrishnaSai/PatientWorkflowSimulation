using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace PWSApp_DataAccessLayer.Utilities
{

    public static class PACS_DaoUtility
    {
        private static string GetConectionString()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["PWS_PACSDBConStr"].ConnectionString;
                return connectionString;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlConnection CreateConnection()
        {
            string connectionString = null;
            SqlConnection connectionObj = null;
            try
            {
                connectionString = GetConectionString();
                connectionObj = new SqlConnection(connectionString);
                return connectionObj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void OpenConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                    connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CloseConnection(SqlConnection connection)
        {
            try
            {
                if (connection != null && connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlCommand CreateCommand(SqlConnection connection, string query, CommandType commandType)
        {
            SqlCommand command = null;
            try
            {
                command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = query;
                command.CommandType = commandType;
                return command;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SqlParameter CreateParameter(string paramName, object paramValue, SqlDbType dbType, ParameterDirection direction = ParameterDirection.Input)
        {
            SqlParameter parameter = null;
            try
            {
                parameter = new SqlParameter();
                parameter.ParameterName = paramName;
                parameter.Value = paramValue;
                parameter.Direction = direction;
                parameter.SqlDbType = dbType;
                return parameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
