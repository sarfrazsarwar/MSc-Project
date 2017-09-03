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
  public  class CalcualteResult
    { 
        DataTable dtConfusionMat = new DataTable();
        int TotalCridetHour = 0;
        private DataTable DT = new DataTable("Academic_module_model");
        private DataTable DTRE = new DataTable("ModuleRequirement");
        int RangeTo = 70;
        int RangeFrom = 60;
        public void setTotalCridetHr(int from,int to)
        {
            RangeFrom = from;
            RangeTo= to;
        }
      //Get those record which have 'anyone' word and beloge to programing  e.g " Language_anyOne or Domain_anyone" 
        public DataTable GetPrograming_AnyOne()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where Domain_ID=1 AND [Academic_info]  like '%_anyOne' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            int rcord = DT.Rows.Count;
            return DT;
        }

       
      // parameter e.g Language and it return Language_R, language_c# , language_java etc
        public DataTable GetPrograming_AnyOne(string str)
        {
            DT.Clear();
            string str1 = "Select *from [Data_Analytics].[dbo].[AcademicInfo] where [info_Type]=1 AND Domain_ID=1 AND [Academic_info]  like '" + str + "%' ORDER BY AcademicInfo_ID";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str1);
            int rcord = DT.Rows.Count;
            return DT;
        }


     
        public DataTable GetModuleInfo()
        {
            DT.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[AcademicModule]";
            DB_ACCESS.DbAccess.FillLocalTable(DT, str);
            return DT;
        }

        public DataTable GetModuleRequirmentInfo()
        {
            DTRE.Clear();
            string str = "Select *from [Data_Analytics].[dbo].[ModuleRequirement]";
            DB_ACCESS.DbAccess.FillLocalTable(DTRE, str);
            return DTRE;
        }
      public  void CalculateResults(DataTable dtTools,DataTable dtMath ,DataTable dtResearch ,DataTable dtPrograming )
        {

           
            DataColumn dc = new DataColumn("AcademicModule_ID");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtConfusionMat.Columns.Add(dc);



            dc = new DataColumn("Credit_hours");
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
            dc = new DataColumn("Exam_Weightage");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtConfusionMat.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtConfusionMat.Columns.Add(dc);
            dc = new DataColumn("none Selected");
            dtConfusionMat.Columns.Add(dc);
            BusinessLayer.CalcualteResult m = new BusinessLayer.CalcualteResult();
            DataTable dtMoudle = m.GetModuleInfo();

            DataTable dtMoudleRequirment = m.GetModuleRequirmentInfo();

            foreach (DataRow dr in dtMoudle.Rows)
            {
                DataRow[] dtRer = dtMoudleRequirment.Select("AcademicModule_ID=" + dr["AcademicModule_ID"]);
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
            DataTable dtSm1 = SmesterModuleSelction(dtTempSmester1, dtMat, RangeFrom, RangeTo);
            ds.Tables.Add(dtSm1);
            ds.Tables.Add(dtMat);
            return ds;
           
        }
      public DataSet SortSmester2Data()
        {

            DataSet ds1 = new DataSet();
            DataTable dtMat;
            DataRow[] fRow = dtConfusionMat.Select("Smester=2");
            DataTable dtTempSmester1 = fRow.CopyToDataTable();
            dtMat = dtConfusionMat.Clone();
            dtMat.Clear();
            DataTable dtSm1 = SmesterModuleSelction(dtTempSmester1, dtMat,RangeFrom,RangeTo);
            ds1.Tables.Add(dtSm1);
            ds1.Tables.Add(dtMat);
            return ds1;
         }

     //Sort Smester data on base of recall values,True postive,and compulsory
        DataTable SmesterModuleSelction(DataTable dtSm, DataTable dttemp,int RangeTo,int RangeFrom)
        {

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
                int CridetHour = int.Parse(drCom["Credit_hours"].ToString());

                TotalCridetHour = TotalCridetHour + CridetHour;
            }

            DataRow[] dr1 = dtSm.Select("compulsory=false", "TruePostive DESC");

            DataTable dtNonCom = null;
            if (dr1.Length > 0)
            {
                DataTable dtTm = dr1.CopyToDataTable();
                //DataTable dtTm = dr1.CopyToDataTable();
                DataRow[] dr2 = dtTm.Select("compulsory=false", "Recall DESC");
                dtNonCom = dr2.CopyToDataTable();
            }
            else
            {
                dtNonCom = dtSm.Clone();
            }
            foreach (DataRow drNonCom in dtNonCom.Rows)
            {
                if (TotalCridetHour < RangeTo)
                {
                    int CridetHour = int.Parse(drNonCom["Credit_hours"].ToString());

                    TotalCridetHour = TotalCridetHour + CridetHour;
                    if (TotalCridetHour > RangeFrom)
                    {
                        TotalCridetHour = TotalCridetHour - CridetHour;
                        DataRow drnew = dttemp.NewRow();


                        drnew["none Selected"] = drNonCom["none Selected"];
                        drnew["AcademicModule_ID"] = drNonCom["AcademicModule_ID"];
                        drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
                        drnew["TruePostive"] = drNonCom["TruePostive"];
                        drnew["Smester"] = drNonCom["Smester"];
                        drnew["Compulsory"] = drNonCom["Compulsory"];
                        drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
                        drnew["Credit_hours"] = drNonCom["Credit_hours"];
                        //""


                        drnew["Recall"] = drNonCom["Recall"]; ;
                        dttemp.Rows.Add(drnew);
                    }
                    else
                    {
                        DataRow drnew = dtcom.NewRow();

                        drnew["none Selected"] = drNonCom["none Selected"];
                        drnew["AcademicModule_ID"] = drNonCom["AcademicModule_ID"];
                        drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
                        drnew["TruePostive"] = drNonCom["TruePostive"];
                        drnew["Smester"] = drNonCom["Smester"];
                        drnew["Compulsory"] = drNonCom["Compulsory"];
                        drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
                        drnew["Credit_hours"] = drNonCom["Credit_hours"];
                        //""


                        drnew["Recall"] = drNonCom["Recall"]; ;
                        dtcom.Rows.Add(drnew);
                    }
                }
                else
                {
                    DataRow drnew = dttemp.NewRow();


                    drnew["AcademicModule_ID"] = drNonCom["AcademicModule_ID"];
                    drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
                    drnew["TruePostive"] = drNonCom["TruePostive"];
                    drnew["Smester"] = drNonCom["Smester"];
                    drnew["Compulsory"] = drNonCom["Compulsory"];
                    drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
                    drnew["Credit_hours"] = drNonCom["Credit_hours"];
                    //""
                    drnew["none Selected"] = drNonCom["none Selected"];

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
                if (dr["AcademicInfo_ID"].ToString() == ID)
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


      //final module selection save in database  
        public void InsertUserInputRecord(int User_ID, int AcademicInfo_ID,float p)
        {

            string str = "INSERT Into [Data_Analytics].[dbo].[ModuleSelction] ([AcademicModule_ID] ,[User_ID],[Module_Priority]) VALUES " +
                                        "(" + AcademicInfo_ID + "," + User_ID + "," + p + ")";
            DB_ACCESS.DbAccess.executeQuery(str);

        }

      //delete Module selection from data base
        public void DeleteUserSelectionRecord(int User_ID)
        {

            string str = "DELETE FROM [Data_Analytics].[dbo].[ModuleSelction]" +
                            "WHERE [User_ID]=" + User_ID;
            DB_ACCESS.DbAccess.executeQuery(str);

        }


      // when visit again get module Selection of semester 1 agaist user
    public  DataTable GetPreRecordSM1(int User_ID)
      {
          DT.Clear();
        
   string qury=     "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module_No],ab.[Credit_hours], "+
  "ab.[Theoretical_Lecture],ab.[Practical_Labs],ab.[CourseWorks_Weightage],ab.[ExamType], "+
  "ab.[Exam_Weightage],mm.[Manager_Name],mm.Email,se.[Module_Priority], " +
  " ab.[ClassTests],ab.[Private_Study_Required] ,ab.[CourseWorks] " +
  "FROM [Data_Analytics].[dbo].[AcademicModule] ab inner join "+
  "[Data_Analytics].[dbo].[ModuleSelction] se ON ab.AcademicModule_ID=se.AcademicModule_ID  "+ 
  "inner join [Data_Analytics].[dbo].[ModuleManager] mm on ab.[ModuleManager_ID]=mm.ModuleManager_ID  "+

  "where se.[User_ID]=" +User_ID+" and ab.Smester=1";
          DB_ACCESS.DbAccess.FillLocalTable(DT, qury);
          return DT;
      }

      //Get semester 1 modules   detail From database like courseWorks,Credit hour,Practical_Labs ec
    public DataTable GetSM1RecordInfo()
    {
        DT.Clear();

        string qury = "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module_No],ab.[Credit_hours], " +
       "ab.[Theoretical_Lecture],ab.[Practical_Labs],ab.[CourseWorks_Weightage],ab.[ExamType], " +
       " ab.[ClassTests],ab.[Private_Study_Required],ab.[CourseWorks],ab.[ExamType],ab.[Exam_Weightage], "+
       "ab.[Exam_Weightage],mm.[Manager_Name],mm.Email,  wa.[WebAddress] " +
       "FROM [Data_Analytics].[dbo].[AcademicModule] ab  " +
       "inner join [Data_Analytics].[dbo].[ModuleManager] mm on ab.[ModuleManager_ID]=mm.ModuleManager_ID  " +
       "  Left Join   [Data_Analytics].[dbo].[WebAddress] wa on ab.[AcademicModule_ID]=wa.[AcademicModule_ID]  " +
       "where  ab.Smester=1";
        DB_ACCESS.DbAccess.FillLocalTable(DT, qury);
        return DT;
    }
    //Get semester 2 modules   detail From database like courseWorks,Credit hour,Practical_Labs ec
    public DataTable GetSM2RecordInfo()
    {
        DT.Clear();
       
        string qury = "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module_No],ab.[Credit_hours], " +
       "ab.[Theoretical_Lecture],ab.[Practical_Labs],ab.[CourseWorks_Weightage],ab.[ExamType], " +
       " ab.[ClassTests],ab.[Private_Study_Required],ab.[CourseWorks], " +
       "ab.[Exam_Weightage],mm.[Manager_Name],mm.Email , wa.[WebAddress] " +
       "FROM [Data_Analytics].[dbo].[AcademicModule] ab  " +
       "inner join [Data_Analytics].[dbo].[ModuleManager] mm on ab.[ModuleManager_ID]=mm.ModuleManager_ID  " +
       "  Left Join   [Data_Analytics].[dbo].[WebAddress] wa on ab.[AcademicModule_ID]=wa.[AcademicModule_ID]  " +
       "where  ab.Smester=2";
        DB_ACCESS.DbAccess.FillLocalTable(DT, qury);
        return DT;
    }
    // when visit again get module Selection of semester 2 agaist user
     public DataTable GetPreRecordSM2(int User_ID)
      {
          DT.Clear();
          string qury = "SELECT ab.[ACademic_Module],ab.[Compulsory],ab.[Smester],ab.[Module_No],ab.[Credit_hours], " +
                            "ab.[Theoretical_Lecture],ab.[Practical_Labs],ab.[CourseWorks_Weightage],ab.[ExamType], " +
                             "ab.[Exam_Weightage],mm.[Manager_Name],mm.Email,se.[Module_Priority], " +
                               " ab.[ClassTests],ab.[Private_Study_Required] ,ab.[CourseWorks]" +
                             "FROM [Data_Analytics].[dbo].[AcademicModule] ab inner join " +
                             "[Data_Analytics].[dbo].[ModuleSelction] se ON ab.AcademicModule_ID=se.AcademicModule_ID  " +
                             "inner join [Data_Analytics].[dbo].[ModuleManager] mm on ab.[ModuleManager_ID]=mm.ModuleManager_ID  " +
                               "where se.[User_ID]=" + User_ID + " and ab.Smester=2";
          DB_ACCESS.DbAccess.FillLocalTable(DT, qury);
          return DT;
      }

//Calculate False Nagetive and True Postive on bases of Expertise Selection and set the proirty of module
     
        void checkExpertise(DataRow[] drreq, DataTable dtConMat, DataRow drModule, DataTable dtTools, DataTable dtMath, DataTable dtResearch, DataTable dtPrograming)
        {
            float TruePostive = 0;
            float FalseNegtive = 0;
            int AcademicModule_ID = 0;
            DataRow drComp = null;

            string nonSel="";
            foreach (DataRow dr in drreq)
            {
                //DataRow[] dTselet=null;
                drComp = null;
                int ReqExpertise = int.Parse(dr["ExpertiseLevel_ID"].ToString());

                AcademicModule_ID = int.Parse(dr["AcademicModule_ID"].ToString());
                int AcademicInfo_ID = int.Parse(dr["AcademicInfo_ID"].ToString());
                if (dtPrograming != null)
                {
                    DataTable dt= GetPrograming_AnyOne();
                    foreach (DataRow dr_anyOne in dt.Rows)
                    {
                        if (dr_anyOne["AcademicInfo_ID"].ToString() == dr["AcademicInfo_ID"].ToString())
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
                    drComp = CompareData(dtPrograming, dr["AcademicInfo_ID"].ToString());
                }
                if (dtTools != null)
                {
                    if (drComp == null)
                    {
                        drComp = CompareData(dtTools, dr["AcademicInfo_ID"].ToString());
                    }
                    
                }
                if (dtMath != null)
                {
                    if (drComp == null)
                    {
                        drComp = CompareData(dtMath, dr["AcademicInfo_ID"].ToString());
                    }
                }
                if (dtResearch != null)
                {
                    if (drComp == null)
                    {
                        drComp = CompareData(dtResearch, dr["AcademicInfo_ID"].ToString());
                    }
                   
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
                    int Th = ReqExpertise - 1;
                    double final = 0;
                    //if (Th >= Level && Th>=2 && Level>1)
                    //{
                    //    final = 0.5;
                    //}
                    if (ReqExpertise == 4 && Level == 3)
                    {
                        final = 0.666;
                    }
                    else if(ReqExpertise==4 && Level==2)
                    {
                        final = 0.333;
                    }
                    else if (ReqExpertise == 3 && Level == 2)
                    {
                        final = 0.5;
                    }

                    if (ReqExpertise > Level && final==0)
                    {
                        FalseNegtive++;
                        nonSel = nonSel + drComp["Data"].ToString() + ",";
                        
                    }
                    else if (final == 0)
                    {
                        TruePostive++;
                        final = 0.0;
                    }
                    else
                    {
                        TruePostive = (float)(TruePostive + final);
                    }
                }





            }
            if (AcademicModule_ID > 0)
            {
                DataRow dr = dtConMat.NewRow();
                dr["AcademicModule_ID"] = AcademicModule_ID;
                dr["TruePostive"] = TruePostive;
                dr["Smester"] = drModule["Smester"];
                dr["Compulsory"] = drModule["Compulsory"];
                dr["FalseNegtive"] = FalseNegtive;
                dr["Credit_hours"] = drModule["Credit_hours"];
                dr["none Selected"] = nonSel;
                dr["ACademic_Module"] = drModule["ACademic_Module"];
                float Re = ((float)TruePostive / (float)(TruePostive + FalseNegtive));
                dr["Recall"] = System.Math.Round(Re, 2);
                dtConMat.Rows.Add(dr);
            }


        }
    }
}
