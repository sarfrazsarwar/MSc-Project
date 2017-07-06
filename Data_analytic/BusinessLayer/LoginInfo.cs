using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
    public class LoginInfo
    {
        private string StrLoginTableName;
        private DataTable DT = new DataTable("Userinfo");
        public string GetTableName()
        {
            return StrLoginTableName;
        }
        public void AddTableName()
        {
            //if (!BusGenral.DS.Tables.Contains("Userinfo"))
            //{
            //    StrLoginTableName = "Userinfo";
            //    BusGenral.DS.Tables.Add(StrLoginTableName);
            //}
        }
       
        public int GetRowCount()
        {
            return DT.Rows.Count;
        }
        public string GetUserName()
        {
             DataRow dr= DT.Rows[0];
             return dr["User Name"].ToString();
        }
        public string GetUserPass()
        {
            DataRow dr = DT.Rows[0];
            return dr["Password"].ToString();
        }
        public void InsertRecord(List<string> dr)
        {
           // foreach (DataRow dr in BusGenral.DS.Tables["UserInfo"].Rows)
            {
                string str = "INSERT Into [Data_Analytics].[dbo].[Userinfo] ([User_Name] ,[Password],[Email]) VALUES "+
                                                            "('" + dr[0].ToString() + "','" + dr[1].ToString() + "','" + dr[2].ToString() + "')";
                DB_ACCESS.Dbaccess.executeQuery(str);
            }
           
          //  BusGenral.DS.Tables["Userinfo"].Clear();
        }
    
        public int  GetUserInfoRecord(string strUserName, string strpass)
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Userinfo] where [User_Name]= '" + strUserName + "'  AND [Password]= '" + strpass + "'";


            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
                DT.Clear();
                return rcord;
        }
        public int DuplicateUserInfoRecord(string strUserName)
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Userinfo] where [User_Name]= '" + strUserName + "'  ";

           // AND [Password]= '" + strpass + "'
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            DT.Clear();
            return rcord;
        }
        public DataTable UserInfoRecord(string strUserName)
        {
            DT.Clear();
            string str = "Select User_name from [Data_Analytics].[dbo].[Userinfo] ";

            // AND [Password]= '" + strpass + "
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
           
            return DT;
        }
    }
}
