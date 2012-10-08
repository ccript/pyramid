using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Configuration;

using BuinessLayer;

namespace DataLayer
{
    /// <summary>
    /// Summary description for BaseDAL
    /// </summary>
    public abstract class BaseDAL
    {
        // ------------------------- private ----------------------------

        private static string connectionString = null;
        private static string providerName = null;

        private static void initialize()
        {
            Configuration configuration = WebConfigurationManager.OpenWebConfiguration("~");
            connectionString = configuration.ConnectionStrings.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
            providerName = configuration.ConnectionStrings.ConnectionStrings["DatabaseConnectionString"].ProviderName;
        }

        private static string getConnectionString()
        {
            if (connectionString == null)
                initialize();

            return connectionString;
        }

        private static string getProviderName()
        {
            if (providerName == null)
                initialize();

            return providerName;
        }

        protected static SqlConnection getConnection()
        {
            if (connectionString == null)
                initialize();
            SqlConnection connection = new SqlConnection(connectionString);
           
            return connection;
        }

        private static DataSet executeSelect(SqlCommand sqlCommand)
        {
            sqlCommand.Connection = getConnection();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return dataSet;
        }

        private static int executeNonSelect(SqlCommand sqlCommand)
        {
            try
            {
                sqlCommand.Connection = getConnection();
                sqlCommand.Connection.Open();
                return sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
        }

        // ------------------------- protected wrappers -----------------------

        protected static DataSet select(SqlCommand sqlCommand)
        {
            return executeSelect(sqlCommand);
        }

        protected static int insert(SqlCommand sqlCommand)
        {
            return executeNonSelect(sqlCommand);
        }

        protected static int update(SqlCommand sqlCommand)
        {
            return executeNonSelect(sqlCommand);
        }

        protected static int delete(SqlCommand sqlCommand)
        {
            return executeNonSelect(sqlCommand);
        }
    }

}