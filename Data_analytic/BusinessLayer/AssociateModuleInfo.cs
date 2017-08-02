using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class AssociateModuleInfo
    {
        private DataTable DT = new DataTable("Academic_associated_info");
        public DataTable GetToolAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where CA_ID=4 AND"+
                " [Academic_info]  not like '%_anyOne' ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        public DataTable GetProgramingAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where CA_ID=1 AND [Academic_info]  not like '%_anyOne' ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        public DataTable GetMathmeticAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where CA_ID=2 AND [Academic_info]  not like '%_anyOne' ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        public DataTable GetResearchAcademicAssociatedInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where CA_ID=3 ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

        public void DeleteUserInputRecord(int user_id)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[User_Input]" +
                            "WHERE [user_ID]=" + user_id;
            DB_ACCESS.Dbaccess.executeQuery(str);

        }
        public void InsertUserInputRecord(int user_id,int AA_ID,int Level)
        {

                string str = "INSERT Into [Data_Analytics].[dbo].[User_Input] ([AA_ID] ,[user_ID],[Expertise_Level]) VALUES " +
                                            "(" + AA_ID + "," + user_id + "," + Level + ")";
                DB_ACCESS.Dbaccess.executeQuery(str);
           
        }

        public DataTable GetResearchAcademicAssociatedInfo1(string pr)
        {
            DT.Clear();
            string str = "Select [Sug_Word] from [Data_Analytics].[dbo].[Academic_Interests] where Sug_Word like '%"+pr+"%' ORDER BY AM_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

    }
}
