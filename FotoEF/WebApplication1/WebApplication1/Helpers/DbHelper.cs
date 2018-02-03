using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1.Helpers
{
    public class DbHelper
    {
        public static string ConnectionString
        {
            get
            {
                String rval = null;
                try
                {
                    rval = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    if (String.IsNullOrEmpty(rval))
                    {
                        throw new Exception("Invalid null connection string in web.config for attribute-name, 'ConnectionString'");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return rval;
            }
        }

        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection(ConnectionString);
                if (conn == null)
                {
                    throw new ArgumentNullException();
                }
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conn;
        }

    }
}