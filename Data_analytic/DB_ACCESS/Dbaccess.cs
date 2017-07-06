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
    public class Dbaccess
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
        public static string executeTransactionalScalarQuery(string query)
        {
            SqlCommand DbCommand = new SqlCommand();
            SqlTransaction DbLocalTran = DbConn.BeginTransaction();
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                //SqlTransaction DbLocalTran = DbConn.BeginTransaction();
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = query;
                DbCommand.Transaction = DbLocalTran;
                DbCommand.CommandType = CommandType.Text;
                object obj = DbCommand.ExecuteScalar();
                DbLocalTran.Commit();

                if (obj != null)
                    return obj.ToString();
                else
                    return null;
            }
            catch (Exception)
            {
                DbLocalTran.Rollback();
                throw;
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

        public static void beginTrans()
        {
            try
            {
                if (DbTran == null)
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                        DbTran = DbConn.BeginTransaction();

                    }
                    else
                    {
                        DbTran = DbConn.BeginTransaction();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        public static void commitTrans()
        {
            try
            {
                if (DbTran != null)
                {
                    DbTran.Commit();
                    DbTran = null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Fills the Dataset dset and its Table tblName with the query arguement provided
        /// </summary>
        /// <param name="dSet"></param>
        /// <param name="query"></param>
        /// <param name="tblName"></param>
        public static void selectQuery(DataSet dSet, string query, string tblName)
        {
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
                        DbCommand.CommandTimeout = 0;
                        DbCommand.CommandType = CommandType.Text;
                        DbAdapter = new SqlDataAdapter(DbCommand);
                        DbAdapter.SelectCommand = DbCommand;
                        DbAdapter.Fill(dSet, tblName);
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


        public static SqlDataReader executeDataReader(string strSql)
        {
            SqlCommand DbCommand = new SqlCommand();

            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = strSql;
                DbCommand.CommandType = CommandType.Text;
                SqlDataReader dr = DbCommand.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
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
                        //Modify Date 28-06-07 (Salman)
                        //DbAdapter = new SqlDataAdapter(DbCommand);
                        DbAdapter.SelectCommand = DbCommand;
                        DbAdapter.Fill(tblName);

                        ////Change Date 20-06-07
                        //DA1.SelectCommand = DbCommand;
                        //DA1.Fill(tblName);
                        //DA1.Dispose();
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

    }
}
