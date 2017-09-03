using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class EditModuleReq
    {
        private DataTable DT = new DataTable("Academic_module_model");
        public DataTable GetModuleInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicModule]";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            return DT;
        }

        public DataTable GetModuleRequirement(int id)
        {
            DataTable dtreq = new DataTable();
            string query = "select ab.[Academic_info],ce.[Expertise] ,ce.[ExpertiseLevel_ID],ab.AcademicInfo_ID from " +
                 "[Data_Analytics].[dbo].[AcademicInfo] ab " +
                 "inner join [Data_Analytics].[dbo].[ModuleRequirement] ac on ab.AcademicInfo_ID=ac.AcademicInfo_ID " +
                     "inner join [Data_Analytics].[dbo].[ExpertiseLevel] ce on ac.ExpertiseLevel_ID=ce.ExpertiseLevel_ID " +
                     "where ac.AcademicModule_ID=" + id + "ORDER BY ab.AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(dtreq, query);
            return dtreq;
        }
        public DataTable GetAssocitedMoudleinfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo]  ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

        public void DeleteModuleReqrRecord(int u_id)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[ModuleRequirement]" +
                            "WHERE [AcademicModule_ID]=" + u_id;
            DB_ACCESS.DbAccess.executeQuery(str);

        }

        public void InsertModuleReqRecord(int AcademicModule_ID, int AcademicInfo_ID, int Level)
        {

            string str = "INSERT Into [Data_Analytics].[dbo].[ModuleRequirement] ([AcademicInfo_ID] ,[AcademicModule_ID],[ExpertiseLevel_ID]) VALUES " +
                                        "(" + AcademicInfo_ID + "," + AcademicModule_ID + "," + Level + ")";
            DB_ACCESS.DbAccess.executeQuery(str);

        }
    }
}
