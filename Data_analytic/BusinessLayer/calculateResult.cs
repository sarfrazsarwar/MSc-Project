using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BusinessLayer
{
  public  class calculateResult
    { 
        DataTable dtConfusionMat = new DataTable();
        private DataTable DT = new DataTable("Academic_module_model");
        private DataTable DTRE = new DataTable("Module_Requirment");
       
        public DataTable GetPrograming_AnyOne()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where CA_ID=1 AND [Academic_info]  like '%_anyOne' ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }
        public DataTable GetPrograming_AnyOne(string str)
        {
            DT.Clear();
            string str1 = "Select *from [Data_Analytics].[dbo].[Academic_associated_info] where [info_Type]=1 AND CA_ID=1 AND [Academic_info]  like '" + str + "%' ORDER BY AA_ID";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str1);
            int rcord = DT.Rows.Count;
            return DT;
        }
        public DataTable GetModuleInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Academic_module_model]";
            DB_ACCESS.Dbaccess.FillLocalTable(DT, str);
            return DT;
        }

        public DataTable GetModuleRequirmentInfo()
        {
            DTRE.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[Module_Requirment]";
            DB_ACCESS.Dbaccess.FillLocalTable(DTRE, str);
            return DTRE;
        }
      public  void CalculateResults(DataTable dtTools,DataTable dtMath ,DataTable dtResearch ,DataTable dtPrograming )
        {

           
            DataColumn dc = new DataColumn("AM_ID");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtConfusionMat.Columns.Add(dc);



            dc = new DataColumn("Credit hours");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Smester");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("Compulsory");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("ModuleManager");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Email");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("ModuleNo");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Exam Weightage");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtConfusionMat.Columns.Add(dc);
            BusinessLayer.calculateResult m = new BusinessLayer.calculateResult();
            DataTable dtMoudle = m.GetModuleInfo();

            DataTable dtMoudleRequirment = m.GetModuleRequirmentInfo();

            foreach (DataRow dr in dtMoudle.Rows)
            {
                DataRow[] dtRer = dtMoudleRequirment.Select("AM_ID=" + dr["AM_ID"]);
                if (dtRer.Length > 0)
                    checkExpertise(dtRer, dtConfusionMat, dr, dtTools, dtMath , dtResearch , dtPrograming );
            }
            //SortSmesterData(dtConfusionMat);
        }
      public DataSet SortSmester1Data()
        {
           // Semester 1
            DataSet ds = new DataSet();
            DataRow[] fRow = dtConfusionMat.Select("Smester=1");
            DataTable dtTempSmester1 = fRow.CopyToDataTable();

             DataTable dtMat = dtConfusionMat.Clone();
            dtMat.Clear();
            DataTable dtSm1 = SmesterModuleSelction(dtTempSmester1, dtMat);
            ds.Tables.Add(dtSm1);
            ds.Tables.Add(dtMat);
            return ds;
            ////GV_SM1.DataSource = dtSm1;
            ////GV_SM1.DataBind();
            ////Gv_SM1_NO.DataSource = dttem;
            ////Gv_SM1_NO.DataBind();
            //DataRow[] fRow1 = dtConfusionMat.Select("Smester=2");
            //DataTable dtTempSmester2 = fRow1.CopyToDataTable();
            //dttem.Clear();
            //DataTable dtSm2 = SmesterModuleSelction(dtTempSmester2, dttem);
            //GV_SM2.DataSource = dtSm2;
            //GV_SM2.DataBind();




            //Gv_SM2_NO.DataSource = dttem;
            //Gv_SM2_NO.DataBind();
            
        }
      public DataSet SortSmester2Data()
        {

            DataSet ds1 = new DataSet();
            DataTable dtMat;
            DataRow[] fRow = dtConfusionMat.Select("Smester=2");
            DataTable dtTempSmester1 = fRow.CopyToDataTable();
            dtMat = dtConfusionMat.Clone();
            dtMat.Clear();
            DataTable dtSm1 = SmesterModuleSelction(dtTempSmester1, dtMat);
            ds1.Tables.Add(dtSm1);
            ds1.Tables.Add(dtMat);
            return ds1;
         }
        DataTable SmesterModuleSelction(DataTable dtSm, DataTable dttemp)
        {
            //dtTempSmester1.DefaultView.Sort = "Recall DESC";
            //DataTable dtSmester1 = dtTempSmester1.DefaultView.ToTable();
            int TotalCridetHour = 0;
            DataTable dtcom = null;
            DataRow[] dr = dtSm.Select("compulsory=true", "Recall DESC");
            if (dr.Length > 0)
            {
                dtcom = dr.CopyToDataTable();
            }
            else
            {
                dtcom = dtSm.Clone();
            }
            foreach (DataRow drCom in dtcom.Rows)
            {
                int CridetHour = int.Parse(drCom["Credit hours"].ToString());

                TotalCridetHour = TotalCridetHour + CridetHour;
            }

            DataRow[] dr1 = dtSm.Select("compulsory=false", "Recall DESC");

            DataTable dtNonCom = null;
            if (dr1.Length > 0)
            {
                dtNonCom = dr1.CopyToDataTable();
            }
            else
            {
                dtNonCom = dtSm.Clone();
            }
            foreach (DataRow drNonCom in dtNonCom.Rows)
            {
                if (TotalCridetHour < 60)
                {
                    int CridetHour = int.Parse(drNonCom["Credit hours"].ToString());

                    TotalCridetHour = TotalCridetHour + CridetHour;
                    if (TotalCridetHour > 70)
                    {
                        TotalCridetHour = TotalCridetHour - CridetHour;
                        DataRow drnew = dttemp.NewRow();


                        drnew["AM_ID"] = drNonCom["AM_ID"];
                        drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
                        drnew["TruePostive"] = drNonCom["TruePostive"];
                        drnew["Smester"] = drNonCom["Smester"];
                        drnew["Compulsory"] = drNonCom["Compulsory"];
                        drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
                        drnew["Credit hours"] = drNonCom["Credit hours"];
                        //""


                        drnew["Recall"] = drNonCom["Recall"]; ;
                        dttemp.Rows.Add(drnew);
                    }
                    else
                    {
                        DataRow drnew = dtcom.NewRow();


                        drnew["AM_ID"] = drNonCom["AM_ID"];
                        drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
                        drnew["TruePostive"] = drNonCom["TruePostive"];
                        drnew["Smester"] = drNonCom["Smester"];
                        drnew["Compulsory"] = drNonCom["Compulsory"];
                        drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
                        drnew["Credit hours"] = drNonCom["Credit hours"];
                        //""


                        drnew["Recall"] = drNonCom["Recall"]; ;
                        dtcom.Rows.Add(drnew);
                    }
                }
                else
                {
                    DataRow drnew = dttemp.NewRow();


                    drnew["AM_ID"] = drNonCom["AM_ID"];
                    drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
                    drnew["TruePostive"] = drNonCom["TruePostive"];
                    drnew["Smester"] = drNonCom["Smester"];
                    drnew["Compulsory"] = drNonCom["Compulsory"];
                    drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
                    drnew["Credit hours"] = drNonCom["Credit hours"];
                    //""


                    drnew["Recall"] = drNonCom["Recall"]; ;
                    dttemp.Rows.Add(drnew);
                }
            }



            return dtcom;
        }

        DataRow CompareData(DataTable dt, string ID)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["AA_ID"].ToString() == ID)
                {
                    return dr;
                    break;
                }
            }
            return null;
        }
        bool IsChangeRow(DataRow dr, DataRow dr1)
        {
            int Level = 1;
            if (dr["NotAvailable"].ToString() == "0")
            {
                
                if (dr["Intermedite"].ToString() == "1")
                {

                    Level = 3;


                }
                else if (dr["Expert"].ToString() == "1")
                {
                    Level = 4;
                }
                else if (dr["Available"].ToString() == "1")
                {
                    Level = 2;

                }
            }
            int Level2 = 1;
            if (dr1["NotAvailable"].ToString() == "0")
            {

                if (dr1["Intermedite"].ToString() == "1")
                {

                    Level2 = 3;


                }
                else if (dr1["Expert"].ToString() == "1")
                {
                    Level2 = 4;
                }
                else if (dr1["Available"].ToString() == "1")
                {
                    Level2 = 2;

                }
            }
            if (Level > Level2)
            {
                return true;
            }
            else
                return false;
        }



        public void InsertUserInputRecord(int user_id, int AA_ID,float p)
        {

            string str = "INSERT Into [Data_Analytics].[dbo].[User_Module_Selections] ([AM_ID] ,[user_ID],[Module Priority]) VALUES " +
                                        "(" + AA_ID + "," + user_id + "," + p + ")";
            DB_ACCESS.Dbaccess.executeQuery(str);

        }
        public void DeleteUserSelectionRecord(int user_id)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[User_Module_Selections]" +
                            "WHERE [user_ID]=" + user_id;
            DB_ACCESS.Dbaccess.executeQuery(str);

        }
    public  DataTable GetPreRecordSM1(int user_ID)
      {
          DT.Clear();
        
   string qury=     "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module No],ab.[Credit hours], "+
  "ab.[Theoretical Lecture],ab.[Practical Labs],ab.[CourseWorks_Weightage],ab.[ExamType], "+
  "ab.[Exam Weightage],mm.[Manager Name],mm.Email,se.[Module Priority] " +
  "FROM [Data_Analytics].[dbo].[Academic_module_model] ab inner join "+
  "[Data_Analytics].[dbo].[User_Module_Selections] se ON ab.AM_ID=se.AM_ID  "+ 
  "inner join [Data_Analytics].[dbo].[Module_Manager_Details] mm on ab.[MM_ID]=mm.MM_ID  "+
  "where se.[User_ID]=" +user_ID+" and ab.Smester=1";

        
          //string qury = "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module No],ab.[Credit hours],ab.[Theoretical Lecture],ab.[Practical Labs]" +
          //   ",ab.[CourseWorks_Weightage],ab.[ExamType],ab.[Exam Weightage]" +
          //  "FROM [Data_Analytics].[dbo].[Academic_module_model] ab inner join [Data_Analytics].[dbo].[User_Module_Selections] se " +
          //  "ON ab.AM_ID=se.AM_ID where se.[User_ID]="+user_ID+" and ab.Smester=1";
          DB_ACCESS.Dbaccess.FillLocalTable(DT, qury);
          return DT;
      }
     public DataTable GetPreRecordSM2(int user_ID)
      {
          DT.Clear();
          string qury = "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module No],ab.[Credit hours], " +
                            "ab.[Theoretical Lecture],ab.[Practical Labs],ab.[CourseWorks_Weightage],ab.[ExamType], " +
                             "ab.[Exam Weightage],mm.[Manager Name],mm.Email,se.[Module Priority] " +
                             "FROM [Data_Analytics].[dbo].[Academic_module_model] ab inner join " +
                             "[Data_Analytics].[dbo].[User_Module_Selections] se ON ab.AM_ID=se.AM_ID  " +
                             "inner join [Data_Analytics].[dbo].[Module_Manager_Details] mm on ab.[MM_ID]=mm.MM_ID  " +
                               "where se.[User_ID]=" + user_ID + " and ab.Smester=2";
          DB_ACCESS.Dbaccess.FillLocalTable(DT, qury);
          return DT;
      }


     
        void checkExpertise(DataRow[] drreq, DataTable dtConMat, DataRow drModule, DataTable dtTools, DataTable dtMath, DataTable dtResearch, DataTable dtPrograming)
        {

           

            //int User_ID = 0;
            
            //bool isFind = false;
            // DataRow[] dTselet;
            int TruePostive = 0;
            int FalseNegtive = 0;
            int AM_ID = 0;
            DataRow drComp = null;

            
            foreach (DataRow dr in drreq)
            {
                //DataRow[] dTselet=null;
                drComp = null;
                int ReqExpertise = int.Parse(dr["E_ID"].ToString());
                AM_ID = int.Parse(dr["AM_ID"].ToString());
                int AA_ID = int.Parse(dr["AA_ID"].ToString());
                if (dtPrograming != null)
                {
                    DataTable dt= GetPrograming_AnyOne();
                    foreach (DataRow dr_anyOne in dt.Rows)
                    {
                        if (dr_anyOne["AA_ID"].ToString() == dr["AA_ID"].ToString())
                        {
                            char[] delimiterChars = { ' ', ',', '.', '_', '\t', '-' };

                            string Str = dr_anyOne["Academic_info"].ToString();
                             string[] strary = Str.Split(delimiterChars);
                             DataTable dtanyOne = GetPrograming_AnyOne(strary[0]);
                             DataRow drTemp = null;
                             foreach (DataRow dra in dtPrograming.Rows)
                            {
                                 string strData=dra["DATA"].ToString();
                                foreach(DataRow drAny in dtanyOne.Rows)
                                {
                                    string strcomp = drAny["Academic_info"].ToString().Trim();
                                    if ( strcomp== strData.Trim())
                                    {
                                        if (drTemp == null)
                                        {
                                            drTemp = dra;
                                        }
                                        else
                                        {
                                            if (IsChangeRow(dra, drTemp))
                                            {
                                                drTemp = dra;
                                            }
                                        }
                                        break;
                                    }
                                }
                            }

                             drComp = drTemp;
                             break;
                        }
                    }

                    if(drComp==null)
                    drComp = CompareData(dtPrograming, dr["AA_ID"].ToString());
                    //dTselet=dtPrograming.Select("AA_ID="+AA_ID);
                    // foreach
                    //if(dTselet.Length>0)
                    //{
                    //    isFind=true;
                    //}
                }
                if (dtTools != null)
                {
                    if (drComp == null)
                    {
                        drComp = CompareData(dtTools, dr["AA_ID"].ToString());
                    }
                    //if(isFind==false)
                    //{
                    //    dTselet=dtTools.Select("AA_ID="+AA_ID);
                    //        if(dTselet.Length>0)
                    //        {
                    //            isFind=true;
                    //        }
                    //}
                }
                if (dtMath != null)
                {
                    if (drComp == null)
                    {
                        drComp = CompareData(dtMath, dr["AA_ID"].ToString());
                    }
                    // if(isFind==false)
                    //{
                    //    dTselet = dtMath.Select("AA_ID=" + AA_ID);
                    //      if(dTselet.Length>0)
                    //        {
                    //            isFind=true;
                    //        }
                    //}
                }
                if (dtResearch != null)
                {
                    if (drComp == null)
                    {
                        drComp = CompareData(dtResearch, dr["AA_ID"].ToString());
                    }
                    // if(isFind==false)
                    //{
                    //    dTselet = dtResearch.Select("AA_ID=" + AA_ID);
                    //      if(dTselet.Length>0)
                    //        {
                    //            isFind=true;
                    //        }
                    //}
                }
                if (drComp != null)
                {
                    int Level = 1;
                    if (drComp["NotAvailable"].ToString() == "0")
                    {
                        
                        if (drComp["Intermedite"].ToString() == "1")
                        {

                            Level = 3;


                        }
                        else if (drComp["Expert"].ToString() == "1")
                        {
                            Level = 4;
                        }
                        else if (drComp["Available"].ToString() == "1")
                        {
                            Level = 2;

                        }

                       
                    }
                    if (ReqExpertise > Level)
                    {
                        FalseNegtive++;
                    }
                    else
                    {
                        TruePostive++;
                    }

                }





            }
            if (AM_ID > 0)
            {
                DataRow dr = dtConMat.NewRow();
                dr["AM_ID"] = AM_ID;
                dr["TruePostive"] = TruePostive;
                dr["Smester"] = drModule["Smester"];
                dr["Compulsory"] = drModule["Compulsory"];
                dr["FalseNegtive"] = FalseNegtive;
                dr["Credit hours"] = drModule["Credit hours"];
                //""
                dr["ACademic_Module"] = drModule["ACademic_Module"];
                float Re = ((float)TruePostive / (float)(TruePostive + FalseNegtive));
                dr["Recall"] = Re;
                dtConMat.Rows.Add(dr);
            }


        }
    }
}
