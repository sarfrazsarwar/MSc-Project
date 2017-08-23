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


        public static void ExecuteProcedure(DataSet ds, string procedureName, string tblName)
        {
            if (DbConn.State == 0)
            {
                createConn();
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DbConn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;

            foreach (DataColumn dc in ds.Tables[tblName].Columns)
            {
                SqlParameter param = new SqlParameter(dc.ColumnName, dc.DataType);
                cmd.Parameters.Add(param);
            }
            foreach (DataRow row in ds.Tables[tblName].Rows)
            {
                foreach (SqlParameter p in cmd.Parameters)
                {
                    p.Value = row[p.ParameterName];
                }
            }
            cmd.ExecuteNonQuery();
        }

        public void UpdateTable(DataSet ds, string tableName, string spAddName, string spUpdateName, string spDeleteName)
        {
            //SqlDataAdapter DA1 = new SqlDataAdapter();
            SqlDataAdapter DbAdapter = new SqlDataAdapter();

            SqlTransaction trans = DbConn.BeginTransaction();

            SqlCommand inserCommand = new SqlCommand(spAddName);
            inserCommand.CommandType = CommandType.StoredProcedure;
            inserCommand.Transaction = trans;
            inserCommand.Connection = trans.Connection;

            SqlCommand updateCommand = new SqlCommand(spUpdateName);
            updateCommand.CommandType = CommandType.StoredProcedure;
            updateCommand.Transaction = trans;
            updateCommand.Connection = trans.Connection;

            SqlCommand deleteCommand = new SqlCommand(spDeleteName);
            deleteCommand.CommandType = CommandType.StoredProcedure;
            deleteCommand.Transaction = trans;
            deleteCommand.Connection = trans.Connection;

            DbAdapter.InsertCommand = inserCommand;
            DbAdapter.UpdateCommand = updateCommand;
            DbAdapter.DeleteCommand = deleteCommand;

         

            DataTable dt = (DataTable)ds.Tables[tableName];
            SqlParameter p = null;

            foreach (DataColumn dc in dt.Columns)
            {
                p = inserCommand.Parameters.AddWithValue("@" + dc.ColumnName, dc.DataType);
                p.SourceColumn = dc.ColumnName;
                p.SourceVersion = DataRowVersion.Current;
            }

            foreach (DataColumn dc in dt.Columns)
            {
                p = updateCommand.Parameters.AddWithValue("@" + dc.ColumnName, dc.DataType);
                p.SourceColumn = dc.ColumnName;
                p.SourceVersion = DataRowVersion.Current;
            }

            //DataColumn dc = dt.Columns[0];
            p = deleteCommand.Parameters.AddWithValue("@" + dt.Columns[0].ColumnName, dt.Columns[0].DataType);
            p.SourceColumn = dt.Columns[0].ColumnName;
            p.SourceVersion = DataRowVersion.Current;

            DbAdapter.Update(dt.Select(null, null, DataViewRowState.Deleted));
            DbAdapter.Update(dt.Select(null, null, DataViewRowState.ModifiedCurrent));
            DbAdapter.Update(dt.Select(null, null, DataViewRowState.Added));

        
            DbAdapter.Dispose();

        }
        public static void rollbackTrans()
        {
            try
            {
                if (DbTran != null)
                {
                    DbTran.Rollback();
                    DbTran = null;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Fills the Dataset dset and its Table tblname via stored procedure provided as spName arguement.Takes Parameters as param
        /// </summary>
        /// <param name="dSet"></param>
        /// <param name="spName"></param>
        /// <param name="param"></param>
        /// <param name="tblName"></param>
        public static void selectStoredProcedure(DataSet dSet, string spName, Hashtable param, string tblName)
        {
            //SqlDataAdapter DA1 = new SqlDataAdapter();
            SqlDataAdapter DbAdapter = new SqlDataAdapter();
            SqlCommand DbCommand = new SqlCommand();

            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = spName;
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbCommand.Parameters.Clear();
                foreach (string para in param.Keys)
                {
                    DbCommand.Parameters.AddWithValue(para, param[para]);
                }

                DbAdapter.SelectCommand = (DbCommand);
                DbAdapter.Fill(dSet, tblName);
                
                DbAdapter.Dispose();
                DbCommand.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Fills the Dataset dset and its Table tblname via stored procedure provided as spName arguement.
        /// </summary>
        /// <param name="dSet"></param>
        /// <param name="spName"></param>
        /// <param name="tblName"></param>

        public static void selectStoredProcedure(DataSet dSet, string spName, string tblName)
        {
            //SqlDataAdapter DA1 = new SqlDataAdapter();
            SqlDataAdapter DbAdapter = new SqlDataAdapter();
            SqlCommand DbCommand = new SqlCommand();

            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = spName;
                DbCommand.CommandType = CommandType.StoredProcedure;
                DbAdapter.SelectCommand = DbCommand;
                DbAdapter.Fill(dSet, tblName);

               
                DbAdapter.Dispose();
                DbCommand.Dispose();

            }
            catch (Exception ex)
            {
                throw ex;
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
        /// <summary>
        /// Runs the DML stored procedure provided as spName with the paramters provided as param 
        /// </summary>
        /// <param name="spName"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public static int executeStoredProcedure(string spName, Hashtable param)
        {
            SqlCommand DbCommand = new SqlCommand();
            try
            {
                if (DbConn.State == 0)
                {
                    createConn();
                }
                DbCommand.Connection = DbConn;
                DbCommand.CommandText = spName;
                DbCommand.CommandType = CommandType.StoredProcedure;
                foreach (string para in param.Keys)
                {
                    DbCommand.Parameters.AddWithValue(para, param[para]);
                }
                return DbCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }

        }


        /// <summary>
        /// Runs DML's provided as the query arguement.
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

        /// <summary>
        /// Updates the Database With the changes pr
        /// ovided in the Dataset dSet
        /// </summary>
        /// <param name="dSet"></param>
        /// <param name="tblName"></param>
        /// <returns></returns>
        public static int executeDataSet(DataSet dSet, string tblName, string strSQL)
        {
            //SqlDataAdapter DA1 = new SqlDataAdapter();
            for (int i = 0; i < NoOfAttempts; i++)
            {
                SqlDataAdapter DbAdapter = new SqlDataAdapter();
                SqlCommand DbCommand = new SqlCommand();
                try
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                    }

                    DbCommand.Connection = DbConn;
                    DbCommand.CommandText = strSQL;
                    DbCommand.CommandType = CommandType.Text;
                    DbAdapter.SelectCommand = DbCommand;

                    SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(DbAdapter);
                    DbCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                    return DbAdapter.Update(dSet, tblName);
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
        public static int executeUpdateDataSet(DataSet dSet, string tblName, string strSQL)
        {
            //SqlDataAdapter DA1 = new SqlDataAdapter();
            for (int i = 0; i < NoOfAttempts; i++)
            {
                SqlDataAdapter DbAdapter = new SqlDataAdapter();
                SqlCommand DbCommand = new SqlCommand();

                try
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                    }

                    DbCommand.Connection = DbConn;
                    DbCommand.CommandText = strSQL;
                    DbCommand.CommandType = CommandType.Text;
                    DbAdapter.SelectCommand = DbCommand;
                    DbAdapter.SelectCommand = DbCommand;
                    SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(DbAdapter);
                  
                    DbCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                    //  DbCommandBuilder.DataAdapter = DbAdapter;
                    return DbAdapter.Update(dSet, tblName);

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


        public static int executeDataTable(DataTable tblName, string strSQL)
        {
            for (int i = 0; i < NoOfAttempts; i++)
            {
                SqlDataAdapter DbAdapter = new SqlDataAdapter();
                SqlCommand DbCommand = new SqlCommand();
                try
                {
                    if (DbConn.State == 0)
                    {
                        createConn();
                    }

                    DbCommand.Connection = DbConn;
                    DbCommand.CommandText = strSQL;
                    DbCommand.CommandType = CommandType.Text;
                    DbAdapter.SelectCommand = DbCommand;

                    SqlCommandBuilder DbCommandBuilder = new SqlCommandBuilder(DbAdapter);
                    DbCommandBuilder.ConflictOption = ConflictOption.OverwriteChanges;
                    DbCommandBuilder.SetAllValues = true;
                    return DbAdapter.Update(tblName);

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
