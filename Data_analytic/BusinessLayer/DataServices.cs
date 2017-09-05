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

       // To retrieve expertise attributes (Tools domain) from database 
        public DataTable GetToolAcademicInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=4 AND"+
                " [Academic_info]  not like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

        // To retrieve expertise attributes (Programmming domain) from database 
        public DataTable GetProgAcademicInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=1 AND [Academic_info]  not like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

        // To retrieve expertise attributes (Maths domain) from database 
        public DataTable GetMathAcademicInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=2 AND [Academic_info]  not like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

        // To retrieve expertise attributes (Research domain) from database 
        public DataTable GetResAcademicInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=3 ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

       //Delete previous selection expertise  record if user modify and updata Expertise
        public void DeleteUserInputRec(int User_ID)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[UserProfile]" +
                            "WHERE [User_ID]=" + User_ID;
            DB_ACCESS.DbAccess.ExecuteQuery(str);

        }

       //To insert user expertise data in database
 
        public void InsertUserInputRec(int User_ID, int AcademicInfo_ID, int Level)
        {

                string str = "INSERT Into [Data_Analytics].[dbo].[UserProfile] ([AcademicInfo_ID] ,[User_ID],[Expertise_Level]) VALUES " +
                                            "(" + AcademicInfo_ID + "," + User_ID + "," + Level + ")";
                DB_ACCESS.DbAccess.ExecuteQuery(str);
           
        }

       // To get word sugestion when type the word on text box//// The function relates to future work - Not completed

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
