using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BusinessLayer
{
   public class previous_Result
    {
        AssociateModuleInfo m = new AssociateModuleInfo();
        DataRow FindRow(DataTable dt, int id)
        {
            DataRow drfind = null;
            foreach (DataRow dr in dt.Rows)
            {

                if (int.Parse(dr["AA_ID"].ToString())== id)
                {
                    drfind = dr;
                    break;
                }
            }


            return drfind;
        }
           public DataTable GetProg_Selection(int id)
        {
            DataTable dt = null;
             dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            //dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "AA_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("NotAvailable", typeof(int));
            dt.Columns.Add(dc);

            
            dc = new DataColumn("Intermedite", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Expert", typeof(int));
            dt.Columns.Add(dc);

           
            DataTable DTTemp = new DataTable();
            string Qury = "SELECT e.[AA_ID],b.[Academic_info],e.[Expertise_Level]" +
                            "FROM [Data_Analytics].[dbo].[User_Input] e inner join [Data_Analytics].[dbo].[Academic_associated_info] b "+
                            "on e.AA_ID=b.AA_ID where b.CA_ID=1 and e.[user_ID]="+id+";";

            DB_ACCESS.Dbaccess.FillLocalTable(DTTemp, Qury);
            if (DTTemp.Rows.Count == 0)
            {
                return dt;
            }
 
           DataTable dtProg = new DataTable();
           dtProg= m.GetProgramingAcademicAssociatedInfo();
           foreach (DataRow dr in dtProg.Rows)
           {
               DataRow dr1 = dt.NewRow();
               dr1["data"] = dr["Academic_info"];
               dr1["AA_ID"] = dr["AA_ID"];
               dr1["Available"] = 0;
               dr1["Expert"] = 0;
               dr1["Intermedite"] = 0;
               dr1["NotAvailable"] = 1;
               dt.Rows.Add(dr1);
           }

            foreach (DataRow dr in DTTemp.Rows)
            {
            
                int id1=int.Parse( dr["AA_ID"].ToString());
              //  DataRow[] dre = dt.Select("data=" + dr["Academic_info"].ToString());
                DataRow dre = FindRow(dt, id1);
                    if(dre==null)
                        continue;
                dre.BeginEdit();
                if (dr["Expertise_Level"].ToString() == "2")
                {
                    dre["Available"] = 1;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }

                if (dr["Expertise_Level"].ToString() == "3")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 1;
                    dre["NotAvailable"] = 0;
                }
                if (dr["Expertise_Level"].ToString() == "4")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 1;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }
                dre.EndEdit();
                dt.AcceptChanges();
            }
            return dt;
        }

      public  DataTable GetTool_Selection(int id)
        {
            DataTable dt = null;
            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            //dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "AA_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("NotAvailable", typeof(int));
            dt.Columns.Add(dc);


            dc = new DataColumn("Intermedite", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Expert", typeof(int));
            dt.Columns.Add(dc);

           
            DataTable DTTemp = new DataTable();
            string Qury = "SELECT e.[AA_ID],b.[Academic_info],e.[Expertise_Level]" +
                            "FROM [Data_Analytics].[dbo].[User_Input] e inner join [Data_Analytics].[dbo].[Academic_associated_info] b " +
                            "on e.AA_ID=b.AA_ID where b.CA_ID=4 and e.[user_ID]=" + id + ";";

            DB_ACCESS.Dbaccess.FillLocalTable(DTTemp, Qury);


            if (DTTemp.Rows.Count == 0)
            {
                return dt;
            }

            DataTable dtProg = new DataTable();
            dtProg = m.GetToolAcademicAssociatedInfo();
            foreach (DataRow dr in dtProg.Rows)
            {
                DataRow dr1 = dt.NewRow();
                dr1["data"] = dr["Academic_info"];
                dr1["AA_ID"] = dr["AA_ID"];
                dr1["Available"] = 0;
                dr1["Expert"] = 0;
                dr1["Intermedite"] = 0;
                dr1["NotAvailable"] = 1;
                dt.Rows.Add(dr1);
            }
            foreach (DataRow dr in DTTemp.Rows)
            {


                int id1 = int.Parse(dr["AA_ID"].ToString());
                //  DataRow[] dre = dt.Select("data=" + dr["Academic_info"].ToString());
                DataRow dre = FindRow(dt, id1);
                if (dre == null)
                    continue;
                dre.BeginEdit();
                if (dr["Expertise_Level"].ToString() == "2")
                {
                    dre["Available"] = 1;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }

                if (dr["Expertise_Level"].ToString() == "3")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 1;
                    dre["NotAvailable"] = 0;
                }
                if (dr["Expertise_Level"].ToString() == "4")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 1;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }
                dre.EndEdit();
                dt.AcceptChanges();
            }
            return dt;
        }

    public    DataTable GetMathmetic_Selection(int id)
        {
            DataTable dt = null;
            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            //dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "AA_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("NotAvailable", typeof(int));
            dt.Columns.Add(dc);


            dc = new DataColumn("Intermedite", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Expert", typeof(int));
            dt.Columns.Add(dc);

           
            DataTable DTTemp = new DataTable();
            string Qury = "SELECT e.[AA_ID],b.[Academic_info],e.[Expertise_Level]" +
                            "FROM [Data_Analytics].[dbo].[User_Input] e inner join [Data_Analytics].[dbo].[Academic_associated_info] b " +
                            "on e.AA_ID=b.AA_ID where b.CA_ID=2 and e.[user_ID]=" + id + ";";

            DB_ACCESS.Dbaccess.FillLocalTable(DTTemp, Qury);


            if (DTTemp.Rows.Count == 0)
            {
                return dt;
            }
 DataTable dtProg = new DataTable();
            dtProg = m.GetMathmeticAcademicAssociatedInfo();
            foreach (DataRow dr in dtProg.Rows)
            {
                DataRow dr1 = dt.NewRow();
                dr1["data"] = dr["Academic_info"];
                dr1["AA_ID"] = dr["AA_ID"];
                dr1["Available"] = 0;
                dr1["Expert"] = 0;
                dr1["Intermedite"] = 0;
                dr1["NotAvailable"] = 1;
                dt.Rows.Add(dr1);
            }
            foreach (DataRow dr in DTTemp.Rows)
            {


                int id1 = int.Parse(dr["AA_ID"].ToString());
                //  DataRow[] dre = dt.Select("data=" + dr["Academic_info"].ToString());
                DataRow dre = FindRow(dt, id1);
                if (dre == null)
                    continue;
                dre.BeginEdit();
                if (dr["Expertise_Level"].ToString() == "2")
                {
                    dre["Available"] = 1;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }

                if (dr["Expertise_Level"].ToString() == "3")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 1;
                    dre["NotAvailable"] = 0;
                }
                if (dr["Expertise_Level"].ToString() == "4")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 1;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }
                dre.EndEdit();
                dt.AcceptChanges();
            }
            return dt;
        }
     public   DataTable GetResearch_Selection(int id)
        {
            DataTable dt = null;
            dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            //dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "AA_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("NotAvailable", typeof(int));
            dt.Columns.Add(dc);


            dc = new DataColumn("Intermedite", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Expert", typeof(int));
            dt.Columns.Add(dc);


            DataTable DTTemp = new DataTable();
            string Qury = "SELECT e.[AA_ID],b.[Academic_info],e.[Expertise_Level]" +
                            "FROM [Data_Analytics].[dbo].[User_Input] e inner join [Data_Analytics].[dbo].[Academic_associated_info] b " +
                            "on e.AA_ID=b.AA_ID where b.CA_ID=3 and e.[user_ID]=" + id + ";";

            DB_ACCESS.Dbaccess.FillLocalTable(DTTemp, Qury);


            if (DTTemp.Rows.Count == 0)
            {
                return dt;
            }         
         DataTable dtProg = new DataTable();
            dtProg = m.GetResearchAcademicAssociatedInfo();
            foreach (DataRow dr in dtProg.Rows)
            {
                DataRow dr1 = dt.NewRow();
                dr1["data"] = dr["Academic_info"];
                dr1["AA_ID"] = dr["AA_ID"];
                dr1["Available"] = 0;
                dr1["Expert"] = 0;
                dr1["Intermedite"] = 0;
                dr1["NotAvailable"] = 1;
                dt.Rows.Add(dr1);
            }
            foreach (DataRow dr in DTTemp.Rows)
            {


                int id1 = int.Parse(dr["AA_ID"].ToString());
                //  DataRow[] dre = dt.Select("data=" + dr["Academic_info"].ToString());
                DataRow dre = FindRow(dt, id1);
                if (dre == null)
                    continue;
                dre.BeginEdit();
                if (dr["Expertise_Level"].ToString() == "2")
                {
                    dre["Available"] = 1;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }

                if (dr["Expertise_Level"].ToString() == "3")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 0;
                    dre["Intermedite"] = 1;
                    dre["NotAvailable"] = 0;
                }
                if (dr["Expertise_Level"].ToString() == "4")
                {
                    dre["Available"] = 0;
                    dre["Expert"] = 1;
                    dre["Intermedite"] = 0;
                    dre["NotAvailable"] = 0;
                }
                dre.EndEdit();
                dt.AcceptChanges();
            }
            return dt;
        }
    }
}
