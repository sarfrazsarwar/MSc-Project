using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class EditRequirment
    {
        private DataTable DT = new DataTable("Academic_module_model");  //change//
        public DataTable GetModuleInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_module_model]";  //change//
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            return DT;
        }

        public DataTable GetModuleRequirement(int id)
        {
            DataTable dtreq = new DataTable();  //change//
            string query = "select ab.[Academic_info],ce.[Expertise] ,ce.[E_ID],ab.AA_ID from " +
                 "[Data_Analytics].[dbo].[Academic_associated_info] ab " +
                 "inner join [Data_Analytics].[dbo].[Module_Requirment] ac on ab.AA_ID=ac.AA_ID " +
                     "inner join [Data_Analytics].[dbo].[Expertise_TAB] ce on ac.E_ID=ce.E_ID " +
                     "where ac.AM_ID=" + id + "ORDER BY ab.AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(dtreq, query);
            return dtreq;
        }
        public DataTable GetAssocitedMoudleinfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info]  ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;  //change//
            return DT;
        }

        public void DeleteModuleReqrRecord(int u_id)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[Module_Requirment]" +
                            "WHERE [AM_ID]=" + u_id;
            DB_ACCESS.Dbaccess.executeQuery(str);

        }

        public void InsertModuleReqRecord(int AM_id, int AA_ID, int Level)
        {

            string str = "INSERT Into [Data_Analytics].[dbo].[Module_Requirment] ([AA_ID] ,[AM_ID],[E_ID]) VALUES " +
                                        "(" + AA_ID + "," + AM_id + "," + Level + ")";
            DB_ACCESS.Dbaccess.executeQuery(str);

        }
    }
}
