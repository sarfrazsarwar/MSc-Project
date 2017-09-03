using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class DataServices
    {
        private DataTable DT = new DataTable("Academic_associated_info");

       // Get Tools page Information  form database 
        public DataTable GetToolAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=4 AND"+
                " [Academic_info]  not like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        // Get programing page Information  form database 
        public DataTable GetProgramingAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=1 AND [Academic_info]  not like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        // Get Mathmetic page Information  form database 
        public DataTable GetMathmeticAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=2 AND [Academic_info]  not like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        // Get Mathmetic page Information  form database 
        public DataTable GetResearchAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=3 ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
       //Delete previous Selection Expertise  Record if user modify and updata Expertise
        public void DeleteUserInputRecord(int User_ID)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[UserProfile]" +
                            "WHERE [User_ID]=" + User_ID;
            DB_ACCESS.DbAccess.executeQuery(str);

        }
       //Insert user Expertise data in data base 
        public void InsertUserInputRecord(int User_ID,int AcademicInfo_ID,int Level)
        {

                string str = "INSERT Into [Data_Analytics].[dbo].[UserProfile] ([AcademicInfo_ID] ,[User_ID],[Expertise_Level]) VALUES " +
                                            "(" + AcademicInfo_ID + "," + User_ID + "," + Level + ")";
                DB_ACCESS.DbAccess.executeQuery(str);
           
        }

       // Get word sugestion when type the word on text boxt//// This work is absulte
        public DataTable GetResearchAcademicAssociatedInfo1(string pr)
        {
            DT.Clear();
            string str = "Select [Sug_Word] from [Data_Analytics].[dbo].[AcademicInterest] where Sug_Word like '%"+pr+"%' ORDER BY AcademicModule_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

    }
}
