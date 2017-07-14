using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            DataTable dtTools = null;
            DataTable dtMath = null;
            DataTable dtResearch = null;
            DataTable dtPrograming = null;
            if (Session["TOOL"] != null)
            {
                dtTools = (DataTable)Session["TOOL"];
            }
            if (Session["Mathmetic"] != null)
            {
                dtMath = (DataTable)Session["Mathmetic"];
            }
            if (Session["Programing"] != null)
            {
                dtPrograming = (DataTable)Session["Programing"];
            }
            if (Session["ResearchExp"] != null)
            {
                dtResearch = (DataTable)Session["ResearchExp"];
            }


            BusinessLayer.calculateResult obj = new BusinessLayer.calculateResult();
            obj.CalculateResults(dtTools, dtMath, dtResearch, dtPrograming);
            
            DataSet dtsm1 = obj.SortSmester1Data();
            GV_SM1.DataSource = dtsm1.Tables[0];
            GV_SM1.DataBind();
            Gv_SM1_NO.DataSource = dtsm1.Tables[1] ;
            Gv_SM1_NO.DataBind();

           
            DataSet dtsm2 = obj.SortSmester2Data();
            GV_SM2.DataSource = dtsm2.Tables[0];
            GV_SM2.DataBind();
            Gv_SM2_NO.DataSource = dtsm2.Tables[1];
            Gv_SM2_NO.DataBind();


            //    CalculateResults();

            //DataRow[] fRow = dtMat.Select("Smester=1");
            //DataTable dtTempSmester1 = fRow.CopyToDataTable();
            //DataTable dttem = dtTempSmester1.Clone();
            //dttem.Clear();
            //DataTable dtSm1 = SmesterModuleSelction(dtTempSmester1, dttem);
            //GV_SM1.DataSource = dtSm1;
            //GV_SM1.DataBind();
            //Gv_SM1_NO.DataSource = dttem;
            //Gv_SM1_NO.DataBind();
            //DataRow[] fRow1 = dtMat.Select("Smester=2");
            //DataTable dtTempSmester2 = fRow1.CopyToDataTable();
            //dttem.Clear();
            //DataTable dtSm2 = SmesterModuleSelction(dtTempSmester2, dttem);
            //GV_SM2.DataSource = dtSm2;
            //GV_SM2.DataBind();




            //Gv_SM2_NO.DataSource = dttem;
            //Gv_SM2_NO.DataBind();
        }
        //void CalculateResults()
        //{

        //      DataTable dtConfusionMat = new DataTable();
        //    DataColumn dc = new DataColumn("AM_ID");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("ACademic_Module");
        //    dtConfusionMat.Columns.Add(dc);

        //    dc = new DataColumn("TruePostive");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("FalseNegtive");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("Recall");
        //    dtConfusionMat.Columns.Add(dc);



        //    dc = new DataColumn("Credit hours");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("Smester");
        //    dtConfusionMat.Columns.Add(dc);

        //    dc = new DataColumn("Compulsory");
        //    dtConfusionMat.Columns.Add(dc);

        //    dc = new DataColumn("ModuleManager");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("Email");
        //    dtConfusionMat.Columns.Add(dc);

        //    dc = new DataColumn("ModuleNo");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("Exam Weightage");
        //    dtConfusionMat.Columns.Add(dc);

        //    dc = new DataColumn("courswork Weightage");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("Exam Type");
        //    dtConfusionMat.Columns.Add(dc);

        //    dc = new DataColumn("Theritical Lecture");
        //    dtConfusionMat.Columns.Add(dc);
        //    dc = new DataColumn("Practicle Lab");
        //    dtConfusionMat.Columns.Add(dc);
        //    BusinessLayer.calculateResult m = new BusinessLayer.calculateResult();
        //    DataTable dtMoudle = m.GetModuleInfo();

        //    DataTable dtMoudleRequirment = m.GetModuleRequirmentInfo();

        //    foreach (DataRow dr in dtMoudle.Rows)
        //        {
        //            DataRow[] dtRer = dtMoudleRequirment.Select("AM_ID=" + dr["AM_ID"]);
        //        if(dtRer.Length>0)
        //            checkExpertise(dtRer,dtConfusionMat,dr);
        //        }
        //    SortSmesterData(dtConfusionMat);
        //}
        //void SortSmesterData(DataTable dtMat)
        //{
        //    //Semester 1
        //    DataRow[] fRow = dtMat.Select("Smester=1");
        //    DataTable dtTempSmester1 = fRow.CopyToDataTable();
        //    DataTable dttem = dtTempSmester1.Clone();
        //    dttem.Clear();
        //    DataTable dtSm1=SmesterModuleSelction(dtTempSmester1,dttem);
        //    GV_SM1.DataSource = dtSm1;
        //    GV_SM1.DataBind();
        //    Gv_SM1_NO.DataSource = dttem;
        //    Gv_SM1_NO.DataBind();
        //    DataRow[] fRow1 = dtMat.Select("Smester=2");
        //    DataTable dtTempSmester2 = fRow1.CopyToDataTable();
        //    dttem.Clear();
        //    DataTable dtSm2 = SmesterModuleSelction(dtTempSmester2,dttem);
        //    GV_SM2.DataSource = dtSm2;
        //    GV_SM2.DataBind();




        //    Gv_SM2_NO.DataSource = dttem;
        //    Gv_SM2_NO.DataBind();
        //    //GV_SM1.Columns[0].Visible = false;
        //    //GV_SM1.Columns[6].Visible = false;
        //    //GV_SM1.Columns[7].Visible = false;

        //    //GV_SM2..Columns.Visible = false;
        //    //GV_SM2.Columns[6].Visible = false;
        //    //GV_SM2.Columns[7].Visible = false;
        //}
        //DataTable  SmesterModuleSelction(DataTable dtSm,DataTable dttemp)
        //{
        //    //dtTempSmester1.DefaultView.Sort = "Recall DESC";
        //    //DataTable dtSmester1 = dtTempSmester1.DefaultView.ToTable();
        //    int TotalCridetHour = 0;
        //    DataTable dtcom = null;
        //    DataRow[] dr = dtSm.Select("compulsory=true","Recall DESC");
        //    if (dr.Length > 0)
        //    {
        //         dtcom = dr.CopyToDataTable();
        //    }
        //    else
        //    {
        //        dtcom = dtSm.Clone();
        //    }
        //    foreach (DataRow drCom in dtcom.Rows)
        //    {
        //        int CridetHour = int.Parse(drCom["Credit hours"].ToString());

        //        TotalCridetHour = TotalCridetHour + CridetHour;
        //    }

        //    DataRow[] dr1 = dtSm.Select("compulsory=false","Recall DESC");

        //    DataTable dtNonCom = null;
        //    if (dr1.Length > 0)
        //    {
        //         dtNonCom = dr1.CopyToDataTable();
        //    }
        //    else
        //    {
        //        dtNonCom = dtSm.Clone();
        //    }
        //    foreach (DataRow drNonCom in dtNonCom.Rows)
        //    {
        //        if (TotalCridetHour < 60)
        //        {
        //            int CridetHour = int.Parse(drNonCom["Credit hours"].ToString());

        //            TotalCridetHour = TotalCridetHour + CridetHour;
        //            if (TotalCridetHour > 70)
        //            {
        //                TotalCridetHour = TotalCridetHour - CridetHour;
        //                DataRow drnew = dttemp.NewRow();


        //                drnew["AM_ID"] = drNonCom["AM_ID"];
        //                drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
        //                drnew["TruePostive"] = drNonCom["TruePostive"];
        //                drnew["Smester"] = drNonCom["Smester"];
        //                drnew["Compulsory"] = drNonCom["Compulsory"];
        //                drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
        //                drnew["Credit hours"] = drNonCom["Credit hours"];
        //                //""


        //                drnew["Recall"] = drNonCom["Recall"]; ;
        //                dttemp.Rows.Add(drnew);
        //            }
        //            else
        //            {
        //                DataRow drnew = dtcom.NewRow();


        //                drnew["AM_ID"] = drNonCom["AM_ID"];
        //                drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
        //                drnew["TruePostive"] = drNonCom["TruePostive"];
        //                drnew["Smester"] = drNonCom["Smester"];
        //                drnew["Compulsory"] = drNonCom["Compulsory"];
        //                drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
        //                drnew["Credit hours"] = drNonCom["Credit hours"];
        //                //""


        //                drnew["Recall"] = drNonCom["Recall"]; ;
        //                dtcom.Rows.Add(drnew);
        //            }
        //        }
        //        else
        //        {
        //            DataRow drnew = dttemp.NewRow();


        //            drnew["AM_ID"] = drNonCom["AM_ID"];
        //            drnew["ACademic_Module"] = drNonCom["ACademic_Module"];
        //            drnew["TruePostive"] = drNonCom["TruePostive"];
        //            drnew["Smester"] = drNonCom["Smester"];
        //            drnew["Compulsory"] = drNonCom["Compulsory"];
        //            drnew["FalseNegtive"] = drNonCom["FalseNegtive"]; ;
        //            drnew["Credit hours"] = drNonCom["Credit hours"];
        //            //""


        //            drnew["Recall"] = drNonCom["Recall"]; ;
        //            dttemp.Rows.Add(drnew);
        //        }
        //    }



        //    return dtcom;
        //}

        //DataRow CompareData(DataTable dt,string ID)
        //{
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["AA_ID"].ToString() == ID)
        //        {
        //            return dr;
        //            break;
        //        }
        //    }
        //    return null;
        //}
        //void checkExpertise(DataRow[] drreq,DataTable dtConMat,DataRow drModule)
        //{

        //    DataTable dtTools=null;
        //    DataTable dtMath=null;
        //    DataTable dtResearch=null;
        //    DataTable dtPrograming=null;

        //    int User_ID = 0;
        //    if (Session["TOOL"] != null)
        //    {
        //         dtTools = (DataTable)Session["TOOL"];
        //    }
        //    if (Session["Mathmetic"] != null)
        //    {
        //         dtMath = (DataTable)Session["Mathmetic"];
        //    }
        //    if (Session["Programing"] != null)
        //    {
        //         dtPrograming = (DataTable)Session["Programing"];
        //    }
        //    if (Session["ResearchExp"] != null)
        //    {
        //        dtResearch = (DataTable)Session["ResearchExp"];
        //    }
        //    bool isFind=false;
        //   // DataRow[] dTselet;
        //    int TruePostive=0;
        //    int FalseNegtive=0;
        //    int AM_ID=0;
        //    DataRow drComp = null;
        //    foreach(DataRow dr in drreq)
        //    {
        //        //DataRow[] dTselet=null;
        //        drComp = null;
        //        int ReqExpertise=int.Parse(dr["E_ID"].ToString());
        //          AM_ID=int.Parse(dr["AM_ID"].ToString());
        //         int AA_ID = int.Parse(dr["AA_ID"].ToString());
        //        if(dtPrograming!=null)
        //        {
        //             drComp = CompareData(dtPrograming, dr["AA_ID"].ToString());
        //           //dTselet=dtPrograming.Select("AA_ID="+AA_ID);
        //           // foreach
        //            //if(dTselet.Length>0)
        //            //{
        //            //    isFind=true;
        //            //}
        //        }
        //        if(dtTools!=null)
        //        {
        //            if (drComp==null)
        //            {
        //                drComp = CompareData(dtTools, dr["AA_ID"].ToString());
        //            }
        //                //if(isFind==false)
        //                //{
        //                //    dTselet=dtTools.Select("AA_ID="+AA_ID);
        //                //        if(dTselet.Length>0)
        //                //        {
        //                //            isFind=true;
        //                //        }
        //                //}
        //        }
        //        if (dtMath != null)
        //        {
        //            if (drComp == null)
        //            {
        //                drComp = CompareData(dtMath, dr["AA_ID"].ToString());
        //            }
        //            // if(isFind==false)
        //            //{
        //            //    dTselet = dtMath.Select("AA_ID=" + AA_ID);
        //            //      if(dTselet.Length>0)
        //            //        {
        //            //            isFind=true;
        //            //        }
        //            //}
        //        }
        //        if (dtResearch != null)
        //        {
        //            if (drComp == null)
        //            {
        //                drComp = CompareData(dtResearch, dr["AA_ID"].ToString());
        //            }
        //            // if(isFind==false)
        //            //{
        //            //    dTselet = dtResearch.Select("AA_ID=" + AA_ID);
        //            //      if(dTselet.Length>0)
        //            //        {
        //            //            isFind=true;
        //            //        }
        //            //}
        //        }
        //        if (drComp != null)
        //         {
        //             if (drComp["NotAvailable"].ToString() == "0")
        //            {
        //                int Level = 1;
        //                if (drComp["Intermedite"].ToString() == "1")
        //                {

        //                    Level = 3;


        //                }
        //                else if (drComp["Expert"].ToString() == "1")
        //                {
        //                    Level = 4;
        //                }
        //                else if (drComp["Available"].ToString() == "1")
        //                {
        //                    Level = 2;

        //                }

        //                if(ReqExpertise>Level)
        //                    {
        //                            FalseNegtive++;
        //                    }
        //                    else 
        //                     {
        //                            TruePostive++;
        //                    }
        //            }
        //            else
        //            {
        //                FalseNegtive++;
        //            }

        //            }





        //    }
        //    if(AM_ID>0)
        //    {
        //        DataRow dr=dtConMat.NewRow();
        //        dr["AM_ID"]=AM_ID;
        //        dr["TruePostive"]=TruePostive;
        //        dr["Smester"] = drModule["Smester"];
        //        dr["Compulsory"] = drModule["Compulsory"];
        //        dr["FalseNegtive"]=FalseNegtive;
        //        dr["Credit hours"] = drModule["Credit hours"];
        //        //""
        //        dr["ACademic_Module"] = drModule["ACademic_Module"];
        //        float Re = ((float)TruePostive / (float)(TruePostive + FalseNegtive));
        //        dr["Recall"] = Re;
        //        dtConMat.Rows.Add(dr);
        //    }


        //    }
        //}

        //foreach (DataRow dr in dt.Rows)
        //{
        //    if (dr["NotAvailable"].ToString() == "0")
        //    {

        //        int AA_ID = int.Parse(dr["AA_ID"].ToString());
        //        int Level = 1;
        //        if (dr["Intermedite"].ToString() == "1")
        //        {
        //            Level = 3;
        //        }
        //        else if (dr["Expert"].ToString() == "1")
        //        {
        //            Level = 4;
        //        }
        //        else if (dr["Available"].ToString() == "1")
        //        {
        //            Level = 2;
        //        }

        //    }
        //}//protected void Pre_Click(object sender, EventArgs e)
        //{
        //    SetLoadStateData();
        //    Response.Redirect("~/Programing.aspx");
        //}
        //protected void NEXT_Click(object sender, EventArgs e)
        //{
        //    SetLoadStateData();
        //    Response.Redirect("~/Programing.aspx");
        //}
    }
}