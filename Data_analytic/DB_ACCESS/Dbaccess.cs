using System;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace DB_ACCESS
{
    /// <summary>
    /// Constains overloaded method to access database and run queries 
    /// </summary>
    public class DbAccess
    {
        public static SqlConnection DbConn = new SqlConnection();
        //        private static SqlDataAdapter DbAdapter = new SqlDataAdapter();
        public static SqlCommand DbCommand = new SqlCommand();
        public static SqlTransaction DbTran;
        private static string strConnString;
        public static SqlCommand DbComandTan = new SqlCommand();
        public static int NoOfAttempts = 1;
        public static void setConnString(string strConn)
        {
            try
            {
                strConnString = strConn;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string getConnString()
        {
            try
            {
                return strConnString;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void createConn()
        {
            try
            {
                //string server = System.Configuration.ConfigurationSettings.AppSettings["server"];
                string server = System.Configuration.ConfigurationManager.AppSettings["server"];
                string dataBaseName = System.Configuration.ConfigurationManager.AppSettings["Database"];
                if (server == null || server.Length < 1)
                {
                    MessageBox.Show("Application configuration file is corrupt.", "DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
                if (dataBaseName == null || dataBaseName.Length < 1)
                {
                    MessageBox.Show("Application configuration file is corrupt.", "DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
      
                strConnString = @"Password=abc123;Persist Security Info=True;User ID=sa;Initial Catalog=" + dataBaseName + ";MultipleActiveResultSets=True;Timeout=120;Data Source=" + server;


                DbConn.ConnectionString = strConnString.Trim();
                //DbConn.ConnectionTimeout = 0;
                DbConn.Open();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public static void closeConnection()
        {
            try
            {
                if (DbConn.State != 0)
                    DbConn.Close();
            }
            catch (Exception)
            {
                throw;
            }

        }




        /// <summary>
        /// Fills The Table From DataBase 
        /// </summary>
        /// <param name="tblName">Name Of Table</param>
        /// <param name="query">select Command</param>
        public static void FillLocalTable(DataTable tblName, string query)
        {
            //SqlDataAdapter DA1 = new SqlDataAdapter();
            for (int i = 0; i < NoOfAttempts; i++)
            {
                SqlDataAdapter DbAdapter = new SqlDataAdapter();
                SqlCommand DbCommand = new SqlCommand();
                try
                {
                    lock (DbConn)
                    {
                        if (DbConn.State == 0)
                        {
                            createConn();
                        }
                        DbCommand.Connection = DbConn;
                        DbCommand.CommandText = query;
                        DbCommand.CommandType = CommandType.Text;
                        DbCommand.CommandTimeout = 0;
                       
                        DbAdapter.SelectCommand = DbCommand;
                        DbAdapter.Fill(tblName);

                
                        DbAdapter.Dispose();
                        DbCommand.Dispose();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("A transport-level error has occurred"))
                    {
                        continue;
                    }
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Runs DML's provided as the query arguement.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static int executeQuery(string query)
        {
            for (int i = 0; i < NoOfAttempts; i++)
            {
                SqlCommand DbCommand = new SqlCommand();
                try
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                    }
                    DbCommand.Connection = DbConn;
                    DbCommand.CommandText = query;
                    DbCommand.CommandType = CommandType.Text;
                    return DbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("A transport-level error has occurred"))
                    {
                        continue;
                    }
                    throw ex;
                }
            }
            return 0;
        }

        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public static string executeScalarQuery(string query)
        {
            for (int i = 0; i < NoOfAttempts; i++)
            {
                SqlCommand DbCommand = new SqlCommand();
                try
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                    }
                    DbCommand.Connection = DbConn;
                    DbCommand.CommandText = query;
                    DbCommand.CommandType = CommandType.Text;
                    object obj = DbCommand.ExecuteScalar();

                    if (obj != null)
                        return obj.ToString();
                    else
                        return null;

                }
                catch (Exception ex)
                {
                    if (ex.Message.StartsWith("A transport-level error has occurred"))
                    {
                        continue;
                    }
                    throw ex;
                }
            }
            return null;
        }


    }
}
