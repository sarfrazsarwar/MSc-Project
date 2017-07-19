using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace Data_analytic
{
    public partial class Result : System.Web.UI.Page
    {
        GridViewRow SelROw;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                Gv_SM1_NO.DataSource = dtsm1.Tables[1];
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
        }

        protected void SM1NON_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gv_SM1_NO, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void SM1NON_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in Gv_SM1_NO.Rows)
            {
                if (row.RowIndex == Gv_SM1_NO.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    SelROw = row;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GV_SM1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in GV_SM1.Rows)
            {
                if (row.RowIndex == GV_SM1.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    SelROw = row;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }




        protected void SM2NON_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Gv_SM2_NO, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void SM2NON_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in Gv_SM2_NO.Rows)
            {
                if (row.RowIndex == Gv_SM2_NO.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    SelROw = row;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void SM2_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(GV_SM2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void SM2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in GV_SM2.Rows)
            {
                if (row.RowIndex == GV_SM2.SelectedIndex)
                {
                    row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;
                    SelROw = row;
                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }



        void RemoveSm1MoudleSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AM_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit hours");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Smester");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Compulsory");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleManager");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Email");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleNo");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Weightage");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtSMAT.Columns.Add(dc);
            DataRow drRemove=null;
            foreach (GridViewRow row in GV_SM1.Rows)
            {
                if (row.RowIndex == GV_SM1.SelectedIndex)
                {
                    drRemove = dtSMAT.NewRow();
                    drRemove["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    drRemove["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    drRemove["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    drRemove["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    drRemove["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    drRemove["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    drRemove["AM_ID"] = row.Cells[6].Text.ToString().Trim();

                    string str=drRemove["Compulsory"].ToString();

                    if (str.ToUpper()=="TRUE")
                    {
                        dtSMAT.Rows.Add(drRemove);
                        drRemove = null;
                    }
                    //remove Selection 
                }
                else
                {
                    DataRow dr = dtSMAT.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                    dtSMAT.Rows.Add(dr);
                }
            }
            GV_SM1.DataSource = dtSMAT;
            GV_SM1.DataBind();

           // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in Gv_SM1_NO.Rows)
            {

                DataRow dr = dtSm2.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                    dtSm2.Rows.Add(dr);
                
            }
            if (drRemove != null)
            {
                DataRow drTemp = dtSm2.NewRow();
                drTemp["ACademic_Module"] = drRemove["ACademic_Module"];
                drTemp["TruePostive"] = drRemove["TruePostive"];
                drTemp["FalseNegtive"] = drRemove["FalseNegtive"];
                drTemp["Recall"] = drRemove["Recall"];
                drTemp["Credit hours"] = drRemove["Credit hours"];
                drTemp["Compulsory"] = drRemove["Compulsory"];
                drTemp["AM_ID"] = drRemove["AM_ID"];
                dtSm2.Rows.Add(drTemp);
            }
            Gv_SM1_NO.DataSource = dtSm2;
            Gv_SM1_NO.DataBind();
        }

        bool validateSmester1CreditHr()
        {
            int creditHr = 0;
            foreach (GridViewRow row in GV_SM1.Rows)
            {
                creditHr = creditHr+int.Parse(row.Cells[5].Text.ToString().Trim());
            }
            if (creditHr < 60)
            {
                return false;
            }
            else
                return true;
        }


        bool validateSmester2CreditHr()
        {
            int creditHr = 0;
            foreach (GridViewRow row in GV_SM2.Rows)
            {
                creditHr = creditHr + int.Parse(row.Cells[5].Text.ToString().Trim());
            }
            if (creditHr < 60)
            {
                return false;
            }
            else
                return true;
        }

        void RemoveSm1MoudleNonSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AM_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit hours");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Smester");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Compulsory");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleManager");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Email");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleNo");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Weightage");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtSMAT.Columns.Add(dc);
            DataRow drRemove = null;
            int totalcreditHour = 0;
            foreach (GridViewRow row in GV_SM1.Rows)
            {
                
                    DataRow dr = dtSMAT.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();

                    totalcreditHour = totalcreditHour + int.Parse(dr["Credit hours"].ToString());
                    dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                    dtSMAT.Rows.Add(dr);
            }
           

            // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in Gv_SM1_NO.Rows)
            {
                if (row.RowIndex == Gv_SM1_NO.SelectedIndex)
                {

                     int temphour=   int.Parse(row.Cells[5].Text.ToString().Trim());

                     totalcreditHour = totalcreditHour + temphour;
                     if (totalcreditHour <= 70)
                     {
                         DataRow dr = dtSMAT.NewRow();
                         dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                         dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                         dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                         dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                         //dr["Smester"] = row.Cells[5].ToString().Trim();
                         dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                         dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                         dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                         dtSMAT.Rows.Add(dr);
                     }
                     else
                     {
                         DataRow dr = dtSm2.NewRow();
                         dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                         dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                         dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                         dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                         //dr["Smester"] = row.Cells[5].ToString().Trim();
                         dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                         dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                         dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                         dtSm2.Rows.Add(dr);
                     }
                }
                else
                {
                    DataRow dr = dtSm2.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                    dtSm2.Rows.Add(dr);
                }
            }
            GV_SM1.DataSource = dtSMAT;
            GV_SM1.DataBind();
            Gv_SM1_NO.DataSource = dtSm2;
            Gv_SM1_NO.DataBind();
        }


        void RemoveSm2MoudleSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AM_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit hours");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Smester");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Compulsory");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleManager");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Email");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleNo");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Weightage");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtSMAT.Columns.Add(dc);
            DataRow drRemove = null;
            foreach (GridViewRow row in GV_SM2.Rows)
            {
                if (row.RowIndex == GV_SM2.SelectedIndex)
                {
                    drRemove = dtSMAT.NewRow();
                    drRemove["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    drRemove["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    drRemove["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    drRemove["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    drRemove["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    drRemove["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    drRemove["AM_ID"] = row.Cells[6].Text.ToString().Trim();

                    string str = drRemove["Compulsory"].ToString();

                    if (str.ToUpper() == "TRUE")
                    {
                        dtSMAT.Rows.Add(drRemove);
                        drRemove = null;
                    }
                    //remove Selection 
                }
                else
                {
                    DataRow dr = dtSMAT.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                    dtSMAT.Rows.Add(dr);
                }
            }
            GV_SM2.DataSource = dtSMAT;
            GV_SM2.DataBind();

            // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in Gv_SM2_NO.Rows)
            {

                DataRow dr = dtSm2.NewRow();
                dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                //dr["Smester"] = row.Cells[5].ToString().Trim();
                dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                dtSm2.Rows.Add(dr);

            }
            if (drRemove != null)
            {
                DataRow drTemp = dtSm2.NewRow();
                drTemp["ACademic_Module"] = drRemove["ACademic_Module"];
                drTemp["TruePostive"] = drRemove["TruePostive"];
                drTemp["FalseNegtive"] = drRemove["FalseNegtive"];
                drTemp["Recall"] = drRemove["Recall"];
                drTemp["Credit hours"] = drRemove["Credit hours"];
                drTemp["Compulsory"] = drRemove["Compulsory"];
                drTemp["AM_ID"] = drRemove["AM_ID"];
                dtSm2.Rows.Add(drTemp);
            }
            Gv_SM2_NO.DataSource = dtSm2;
            Gv_SM2_NO.DataBind();
        }


        void RemoveSm2MoudleNonSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AM_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit hours");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Smester");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Compulsory");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleManager");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Email");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("ModuleNo");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Weightage");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtSMAT.Columns.Add(dc);
            DataRow drRemove = null;
            int totalcreditHour = 0;
            foreach (GridViewRow row in GV_SM2.Rows)
            {

                DataRow dr = dtSMAT.NewRow();
                dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                //dr["Smester"] = row.Cells[5].ToString().Trim();
                dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();

                totalcreditHour = totalcreditHour + int.Parse(dr["Credit hours"].ToString());
                dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                dtSMAT.Rows.Add(dr);
            }


            // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in Gv_SM2_NO.Rows)
            {
                if (row.RowIndex == Gv_SM2_NO.SelectedIndex)
                {

                    int temphour = int.Parse(row.Cells[5].Text.ToString().Trim());

                    totalcreditHour = totalcreditHour + temphour;
                    if (totalcreditHour <= 70)
                    {
                        DataRow dr = dtSMAT.NewRow();
                        dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                        dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                        dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                        dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                        //dr["Smester"] = row.Cells[5].ToString().Trim();
                        dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                        dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                        dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                        dtSMAT.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dtSm2.NewRow();
                        dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                        dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                        dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                        dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                        //dr["Smester"] = row.Cells[5].ToString().Trim();
                        dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                        dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                        dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                        dtSm2.Rows.Add(dr);
                    }
                }
                else
                {
                    DataRow dr = dtSm2.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["TruePostive"] = row.Cells[1].Text.ToString().Trim();
                    dr["FalseNegtive"] = row.Cells[2].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[3].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    dr["Credit hours"] = row.Cells[5].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[4].Text.ToString().Trim();
                    dr["AM_ID"] = row.Cells[6].Text.ToString().Trim();
                    dtSm2.Rows.Add(dr);
                }
            }
            GV_SM2.DataSource = dtSMAT;
            GV_SM2.DataBind();
            Gv_SM2_NO.DataSource = dtSm2;
            Gv_SM2_NO.DataBind();
        }
        protected void Save_Click(object sender, EventArgs e)
        {

            if (validateSmester1CreditHr() && validateSmester2CreditHr())
            {
                BusinessLayer.calculateResult obj = new BusinessLayer.calculateResult();

                int user_id = (int)Session["UserID"];
                obj.DeleteUserSelectionRecord(user_id);
                foreach (GridViewRow row in GV_SM1.Rows)
                {
                    string str = row.Cells[5].ToString().Trim();
                    int AM_ID = int.Parse(row.Cells[6].Text.ToString().Trim());
                    float p = float.Parse(row.Cells[3].Text.ToString().Trim());
                    obj.InsertUserInputRecord(user_id, AM_ID,p);
                }
                foreach (GridViewRow row in GV_SM2.Rows)
                {
                    int AM_ID = int.Parse(row.Cells[6].Text.ToString().Trim());
                    float p = float.Parse(row.Cells[3].Text.ToString().Trim());
                    obj.InsertUserInputRecord(user_id, AM_ID,p);
                }

                Response.Redirect("~/Previous_summary.aspx");
            }
        }

        protected void BTN_UP_SM1_Click(object sender, EventArgs e)
        {
            RemoveSm1MoudleNonSugest();
        }

        protected void BTN_DOWN_SM1_Click(object sender, EventArgs e)
        {
            RemoveSm1MoudleSugest();
        }

        protected void BTN_SM2_UP_Click(object sender, EventArgs e)
        {
            RemoveSm2MoudleNonSugest();
        }

        protected void BTN_SM2_DOWN_Click(object sender, EventArgs e)
        {
            RemoveSm2MoudleSugest();
        }

      
  
    }
}