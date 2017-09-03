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


                BusinessLayer.CalcualteResult obj = new BusinessLayer.CalcualteResult();
                obj.CalculateResults(dtTools, dtMath, dtResearch, dtPrograming);
                //DsSemester1 contain 2 table of Semester 1..table[0] have sugesstion module  and table[1] have non sugestion module
                DataSet dsSemester1 = obj.SortSmester1Data();
                grdSugSemester1.DataSource = dsSemester1.Tables[0];
                grdSugSemester1.DataBind();
                grdNonSugSemester1.DataSource = dsSemester1.Tables[1];
                grdNonSugSemester1.DataBind();

                //Set the total range of credit hr of semester 1 and semester 2
                obj.setTotalCridetHr(120,125);

                //DsSemester2 contain 2 table of Semester 2..table[0] have sugesstion module  and table[1] have non sugestion module
                DataSet dsSemester2 = obj.SortSmester2Data();

                grdSugSemester2.DataSource = dsSemester2.Tables[0];
                grdSugSemester2.DataBind();
                grdNonSugSemester2.DataSource = dsSemester2.Tables[1];
                grdNonSugSemester2.DataBind();



                DataTable dtSemster1 = obj.GetSM1RecordInfo();

                DataColumn dc = new DataColumn("none Selected");
                dtSemster1.Columns.Add(dc);
                Add_falseNegetive(dsSemester1.Tables[0], dtSemster1);
                Add_falseNegetive(dsSemester1.Tables[1], dtSemster1);


                grdSemester1Detail.DataSource = dtSemster1;
                   grdSemester1Detail.DataBind();
                   DataTable dtSemester2 = obj.GetSM2RecordInfo();

                   Add_falseNegetive(dsSemester2.Tables[0], dtSemester2);
                   Add_falseNegetive(dsSemester2.Tables[1], dtSemester2);

                   grdSemester2Detail.DataSource = dtSemester2;
                   grdSemester2Detail.DataBind();
            }
        }
        protected string SetUrl(object o)
        {
            if (o.ToString().Trim() == "")
            {
                return "";
            }
            else
            {
                return "WebLink";
            }
        }
        protected string GetUrl(object id)
        {
            return "http://" + id;
        }
        void Add_falseNegetive(DataTable dtSrc, DataTable dtDes)
        {
            foreach (DataRow dr in dtSrc.Rows)
                {
                    foreach (DataRow dr1 in dtDes.Rows)
                    {
                        if (dr["ACademic_Module"].ToString().Trim() == dr1["ACademic_Module"].ToString().Trim())
                        {
                            if (dr["none Selected"].ToString() == "")
                            {
                                dr1["none Selected"] = "Nil";
                            }
                            else
                            {
                                dr1["none Selected"] = dr["none Selected"];
                            }
                                break;
                        }
                    }
                }

        }
        //call when binding the tabel with grid non Sugestion Module of semester 1
        protected void SM1NON_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdNonSugSemester1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                string str = e.Row.Cells[2].Text.ToString();
                if(e.Row.Cells[2].Text.ToString()=="True")
                    e.Row.ForeColor = ColorTranslator.FromHtml("#FF0000");



            }
        }
        //Semester 1 Row Selection of Detail Grid When  Selecting of Row Suggestion module or non Suggestion module
        void selectROw(GridViewRow rowSEl)
        {
            foreach (GridViewRow row in grdSemester1Detail.Rows)
            {
                if (row.Cells[0].Text.Trim() == rowSEl.Cells[0].Text.Trim())
                {
                    grdSemester1Detail.SelectedIndex = row.RowIndex;
                }
                
            }
        }
        //Semester 2 Row Selection of Detail Grid When  Selecting of Row Suggestion module or non Suggestion module
        void selectSM2Row(GridViewRow rowSEl)
        {
            foreach (GridViewRow row in grdSemester2Detail.Rows)
            {
                if (row.Cells[0].Text.Trim() == rowSEl.Cells[0].Text.Trim())
                {
                    grdSemester2Detail.SelectedIndex = row.RowIndex;
                }

            }
        }

        //call when Row selection Index change  on non Suggestion Module in Semester 1
        protected void SM1NON_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in grdNonSugSemester1.Rows)
            {
                if (row.RowIndex == grdNonSugSemester1.SelectedIndex)
                {
                    
                    row.ToolTip = string.Empty;
                    SelROw = row;
                    selectROw(SelROw);
                    if (grdSugSemester1.SelectedIndex >= 0)
                    {
                        
                        UpdatePanel1.Update();
                        grdSugSemester1.SelectedIndex = -1;
                    }
                    UpdatePanel5.Update();
                }
                else
                {
                    
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        //call when binding the tabel with grid Sugestion Module semester 1
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdSugSemester1, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                string str = e.Row.Cells[2].Text.ToString();
                if (e.Row.Cells[2].Text.ToString() == "True")
                    e.Row.ForeColor = ColorTranslator.FromHtml("#FF0000");
            }
        }

        //call when Row selection Index change  on Suggestion Module in Semester 1
        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in grdSugSemester1.Rows)
            {
                if (row.RowIndex == grdSugSemester1.SelectedIndex)
                {
                   
                    row.ToolTip = string.Empty;
                    SelROw = row;
                    selectROw(SelROw);
                    if (grdNonSugSemester1.SelectedIndex >= 0)
                    {
                        grdNonSugSemester1.SelectedIndex = -1;
                       
                        UpdatePanel4.Update();
                    }
                    UpdatePanel5.Update();
                }
                else
                {
                    
                    row.ToolTip = "Click to select this row.";
                }
            }
        }



        //call when binding the tabel with grid non Sugestion Module of semester 2
        protected void SM2NON_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdNonSugSemester2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                string str = e.Row.Cells[2].Text.ToString();
                if (e.Row.Cells[2].Text.ToString() == "True")
                    e.Row.ForeColor = ColorTranslator.FromHtml("#FF0000");
            }
        }
        //call when Row selection Index change  on non Suggestion Module in Semester 2
        protected void SM2NON_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in grdNonSugSemester2.Rows)
            {
                if (row.RowIndex == grdNonSugSemester2.SelectedIndex)
                {
                  
                    row.ToolTip = string.Empty;
                    SelROw = row;
                    selectSM2Row(SelROw);
                    if (grdSugSemester2.SelectedIndex >= 0)
                    {
                        grdSugSemester2.SelectedIndex = -1;
                        UpdatePanel3.Update();
                    }
                    UpdatePanel6.Update();
                }
                else
                {
               
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        //call when binding the tabel with grid  Sugestion Module of semester 2
        protected void SM2_OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdSugSemester2, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
                if (e.Row.Cells[2].Text.ToString() == "True")
                    e.Row.ForeColor = ColorTranslator.FromHtml("#FF0000");
            }
        }
        //call when Row selection Index change  on  Suggestion Module in Semester 2
        protected void SM2_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            SelROw = null;
            foreach (GridViewRow row in grdSugSemester2.Rows)
            {
                if (row.RowIndex == grdSugSemester2.SelectedIndex)
                {
             
                    row.ToolTip = string.Empty;
                    SelROw = row;
                    selectSM2Row(SelROw);
                    if (grdNonSugSemester2.SelectedIndex >= 0)
                    {
                        grdNonSugSemester2.SelectedIndex = -1;
                        UpdatePanel2.Update();
                    }
                    UpdatePanel6.Update();
                }
                else
                {
                    
                    row.ToolTip = "Click to select this row.";
                }
            }
        }


        //Checked and move  Suggeston module To non Suggestion module Gride during Manual shifting of Semester 1
        void RemoveSm1MoudleSugest()
        {
            LBLerror.Text = "";
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AcademicModule_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit_hours");
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
            dc = new DataColumn("Exam_Weightage");
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
            foreach (GridViewRow row in grdSugSemester1.Rows)
            {
                if (row.RowIndex == grdSugSemester1.SelectedIndex)
                {
                    drRemove = dtSMAT.NewRow();
                    drRemove["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                  
                    drRemove["Recall"] = row.Cells[1].Text.ToString().Trim();
                  
                    drRemove["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                    drRemove["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    drRemove["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();

                    string str=drRemove["Compulsory"].ToString();

                    if (str.ToUpper()=="TRUE")
                    {
                        dtSMAT.Rows.Add(drRemove);
                        drRemove = null;
                        LBLerror.Text = "Compulsory Module cannot Shifted";
                      
                    }
                    //remove Selection 
                }
                else
                {
                    DataRow dr = dtSMAT.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                    
                    dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                    dtSMAT.Rows.Add(dr);
                }
            }
            grdSugSemester1.DataSource = dtSMAT;
            grdSugSemester1.DataBind();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in grdNonSugSemester1.Rows)
            {

                DataRow dr = dtSm2.NewRow();
                dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                    dtSm2.Rows.Add(dr);
                
            }
            if (drRemove != null)
            {
                DataRow drTemp = dtSm2.NewRow();
                drTemp["ACademic_Module"] = drRemove["ACademic_Module"];
                drTemp["Recall"] = drRemove["Recall"];
                drTemp["Credit_hours"] = drRemove["Credit_hours"];
                drTemp["Compulsory"] = drRemove["Compulsory"];
                drTemp["AcademicModule_ID"] = drRemove["AcademicModule_ID"];
                dtSm2.Rows.Add(drTemp);
            }
            grdNonSugSemester1.DataSource = dtSm2;
            grdNonSugSemester1.DataBind();
        }
        //validate Credit hr per Semester 
        //Validate Total credit hr of semester 1 and Semester 2 when Submit Button pressed
        bool validateSmesterCreditHr()
        {
            int creditHr = 0;
            foreach (GridViewRow row in grdSugSemester1.Rows)
            {
                creditHr = creditHr+int.Parse(row.Cells[3].Text.ToString().Trim());
            }
            if (creditHr < 50)
            {
                return false;
            }
            foreach (GridViewRow row in grdSugSemester2.Rows)
            {
                creditHr = creditHr + int.Parse(row.Cells[3].Text.ToString().Trim());
            }
            if (creditHr < 120)
            {
                return false;
            }
            else if(creditHr > 125)
            {
                return false;
            }
            else
                return true;
        }


    //Checked and move non Suggeston module To Suggestion module Gride during Manual shifting of Semester 1

        void RemoveSm1MoudleNonSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AcademicModule_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit_hours");
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
            dc = new DataColumn("Exam_Weightage");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtSMAT.Columns.Add(dc);
            int totalcreditHour = 0;
            int totalcreditHour2 = 0;


            foreach (GridViewRow row in grdSugSemester2.Rows)
            {


                totalcreditHour2 = totalcreditHour2 + int.Parse(row.Cells[3].Text.ToString().Trim());
                
            }

            foreach (GridViewRow row in grdSugSemester1.Rows)
            {
                
                    DataRow dr = dtSMAT.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                    dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();

                    totalcreditHour = totalcreditHour + int.Parse(dr["Credit_hours"].ToString());
                    dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                    dtSMAT.Rows.Add(dr);
            }
           

            // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in grdNonSugSemester1.Rows)
            {
                if (row.RowIndex == grdNonSugSemester1.SelectedIndex)
                {

                     int temphour=   int.Parse(row.Cells[3].Text.ToString().Trim());

                     totalcreditHour = totalcreditHour + temphour;
                     if (totalcreditHour <= 70 && ((totalcreditHour2+totalcreditHour)<=125))
                     {
                         DataRow dr = dtSMAT.NewRow();
                         dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                         dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                         dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                         dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                         dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                         dtSMAT.Rows.Add(dr);
                     }
                     else
                     {
                         DataRow dr = dtSm2.NewRow();
                         dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                         dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                         dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                         dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                         dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                         dtSm2.Rows.Add(dr);
                         if(totalcreditHour>70)
                         LBLerror.Text = "Maximum 70 crdit hr in Smester";
                         else
                          LBLerror.Text = "Maximum 120 to 125 crdit hr both Smester";
                       
                     }
                }
                else
                {
                    DataRow dr = dtSm2.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                    dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                    dtSm2.Rows.Add(dr);
                }
            }
            grdSugSemester1.DataSource = dtSMAT;
            grdSugSemester1.DataBind();
            grdNonSugSemester1.DataSource = dtSm2;
            grdNonSugSemester1.DataBind();
        }

        //Checked and move  Suggeston module To non Suggestion module Gride during Manual shifting of Semester 2
        void RemoveSm2MoudleSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AcademicModule_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit_hours");
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
            dc = new DataColumn("Exam_Weightage");
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
            foreach (GridViewRow row in grdSugSemester2.Rows)
            {
                if (row.RowIndex == grdSugSemester2.SelectedIndex)
                {
                    drRemove = dtSMAT.NewRow();
                    drRemove["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    drRemove["Recall"] = row.Cells[1].Text.ToString().Trim();
                    //dr["Smester"] = row.Cells[5].ToString().Trim();
                    drRemove["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                    drRemove["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    drRemove["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();

                    string str = drRemove["Compulsory"].ToString();

                    if (str.ToUpper() == "TRUE")
                    {
                        dtSMAT.Rows.Add(drRemove);

                        drRemove = null;
                        Label1.Text = "Compulsory module can not Shifted";
                       
                    }
                    //remove Selection 
                }
                else
                {
                    DataRow dr = dtSMAT.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();

                    dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                    dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                    dtSMAT.Rows.Add(dr);
                }
            }
            grdSugSemester2.DataSource = dtSMAT;
            grdSugSemester2.DataBind();

            // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in grdNonSugSemester2.Rows)
            {

                DataRow dr = dtSm2.NewRow();
                dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();

                dr["Recall"] = row.Cells[1].Text.ToString().Trim();

                dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                dtSm2.Rows.Add(dr);

            }
            if (drRemove != null)
            {
                DataRow drTemp = dtSm2.NewRow();
                drTemp["ACademic_Module"] = drRemove["ACademic_Module"];

                drTemp["Recall"] = drRemove["Recall"];
                drTemp["Credit_hours"] = drRemove["Credit_hours"];
                drTemp["Compulsory"] = drRemove["Compulsory"];
                drTemp["AcademicModule_ID"] = drRemove["AcademicModule_ID"];
                dtSm2.Rows.Add(drTemp);
            }
            grdNonSugSemester2.DataSource = dtSm2;
            grdNonSugSemester2.DataBind();
        }

        //Checked and move non Suggeston module To Suggestion module Gride during Manual shifting of Semester 2
        void RemoveSm2MoudleNonSugest()
        {
            DataTable dtSMAT = new DataTable();
            DataColumn dc = new DataColumn("AcademicModule_ID");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("ACademic_Module");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("TruePostive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("FalseNegtive");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Recall");
            dtSMAT.Columns.Add(dc);



            dc = new DataColumn("Credit_hours");
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
            dc = new DataColumn("Exam_Weightage");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("courswork Weightage");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Exam Type");
            dtSMAT.Columns.Add(dc);

            dc = new DataColumn("Theritical Lecture");
            dtSMAT.Columns.Add(dc);
            dc = new DataColumn("Practicle Lab");
            dtSMAT.Columns.Add(dc);
            int totalcreditHour = 0;
            int totalcreditHour2 = 0;
            foreach (GridViewRow row in grdSugSemester1.Rows)
            {
                totalcreditHour2 = totalcreditHour2 + int.Parse(row.Cells[3].Text.ToString().Trim());
            }

            foreach (GridViewRow row in grdSugSemester2.Rows)
            {

                DataRow dr = dtSMAT.NewRow();
                dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();

                totalcreditHour = totalcreditHour + int.Parse(dr["Credit_hours"].ToString());
                dtSMAT.Rows.Add(dr);
            }


            // dtSMAT.Clear();
            DataTable dtSm2 = dtSMAT.Clone();
            foreach (GridViewRow row in grdNonSugSemester2.Rows)
            {
                if (row.RowIndex == grdNonSugSemester2.SelectedIndex)
                {

                    int temphour = int.Parse(row.Cells[3].Text.ToString().Trim());

                    totalcreditHour = totalcreditHour + temphour;
                    if (totalcreditHour <= 70 && ((totalcreditHour+totalcreditHour2)<=125))
                    {
                        DataRow dr = dtSMAT.NewRow();
                        dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                        dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                        dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                        dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                        dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                        dtSMAT.Rows.Add(dr);
                    }
                    else
                    {
                        DataRow dr = dtSm2.NewRow();
                        dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                        dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                        dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                        dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                        dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                        dtSm2.Rows.Add(dr);
                        if(totalcreditHour>70)
                        Label1.Text = "Maximum 70 crdit hr in Smester";
                        else
                          Label1.Text = "Maximum 120 to 125 crdit hr both Smester";
                    }
                }
                else
                {
                    DataRow dr = dtSm2.NewRow();
                    dr["ACademic_Module"] = row.Cells[0].Text.ToString().Trim();
                    dr["Recall"] = row.Cells[1].Text.ToString().Trim();
                    dr["Credit_hours"] = row.Cells[3].Text.ToString().Trim();
                    dr["Compulsory"] = row.Cells[2].Text.ToString().Trim();
                    dr["AcademicModule_ID"] = row.Cells[4].Text.ToString().Trim();
                    dtSm2.Rows.Add(dr);
                }
            }
            grdSugSemester2.DataSource = dtSMAT;
            grdSugSemester2.DataBind();
            grdNonSugSemester2.DataSource = dtSm2;
            grdNonSugSemester2.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblErrorMian.Text = "";
            if (validateSmesterCreditHr())
            {
                BusinessLayer.CalcualteResult obj = new BusinessLayer.CalcualteResult();

                int User_ID = (int)Session["UserID"];;
                obj.DeleteUserSelectionRecord(User_ID);
                foreach (GridViewRow row in grdSugSemester1.Rows)
                {
                    int AcademicModule_ID = int.Parse(row.Cells[4].Text.ToString().Trim());
                    float p = float.Parse(row.Cells[1].Text.ToString().Trim());
                    obj.InsertUserInputRecord(User_ID, AcademicModule_ID, p);
                }
                foreach (GridViewRow row in grdSugSemester2.Rows)
                {
                    int AcademicModule_ID = int.Parse(row.Cells[4].Text.ToString().Trim());
                    float p = float.Parse(row.Cells[1].Text.ToString().Trim());
                    obj.InsertUserInputRecord(User_ID, AcademicModule_ID, p);
                }

                Response.Redirect("~/ResultSummary.aspx");
            }
            else
            {
                lblErrorMian.Text = "Smestr 1 and Smester 2 must have 120 to 125 crdit Hr";
            }
        }

        protected void btnSemster1LeftShift_Click(object sender, EventArgs e)
        {
            LBLerror.Text = "";
            Label1.Text = "";
            lblErrorMian.Text = "";
            RemoveSm1MoudleNonSugest();
            UpdatePanel1.Update();
            UpdatePanel4.Update();
            UpdatePanel12.Update();
            UpdatePanel11.Update();
        }

        protected void btnSemster1RightShift_Click(object sender, EventArgs e)
        {
            LBLerror.Text = "";
            Label1.Text = "";
            lblErrorMian.Text = "";
            RemoveSm1MoudleSugest();
            UpdatePanel1.Update();
            UpdatePanel4.Update();
            UpdatePanel12.Update();
            UpdatePanel11.Update();
        }

        protected void btnSemster2LeftShift_Click(object sender, EventArgs e)
        {
            LBLerror.Text = "";
            Label1.Text = "";
            lblErrorMian.Text = "";
            RemoveSm2MoudleNonSugest();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel12.Update();
            UpdatePanel11.Update();
        }

        protected void btnSemster2RightShift_Click(object sender, EventArgs e)
        {
            LBLerror.Text = "";
            Label1.Text = "";
            lblErrorMian.Text = "";
            RemoveSm2MoudleSugest();
            UpdatePanel2.Update();
            UpdatePanel3.Update();
            UpdatePanel12.Update();
            UpdatePanel11.Update();
           
        }
        //Reset Manual Shifting of Semester 2
        protected void btnResetSemester2_Click(object sender, EventArgs e)
        {
            LBLerror.Text = "";
            Label1.Text = "";
            lblErrorMian.Text = "";
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

            int creditHr = 0;
            foreach (GridViewRow row in grdSugSemester1.Rows)
            {
                creditHr = creditHr + int.Parse(row.Cells[3].Text.ToString().Trim());
            }
            int rangfrom = 60;
            int rang = 125 - creditHr;
            if (rang >= 70)
            {
                rang = 70;
            }
            else
            {
                rangfrom = 50;
            }

            BusinessLayer.CalcualteResult obj = new BusinessLayer.CalcualteResult();
            obj.setTotalCridetHr(rangfrom, rang);
            obj.CalculateResults(dtTools, dtMath, dtResearch, dtPrograming);
            DataSet dtsm2 = obj.SortSmester2Data();

            grdSugSemester2.DataSource = dtsm2.Tables[0];
            grdSugSemester2.DataBind();
            grdNonSugSemester2.DataSource = dtsm2.Tables[1];
            grdNonSugSemester2.DataBind();

            DataTable dttemp = obj.GetSM2RecordInfo();
            DataColumn dc = new DataColumn("none Selected");
            dttemp.Columns.Add(dc);

            Add_falseNegetive(dtsm2.Tables[0], dttemp);
            Add_falseNegetive(dtsm2.Tables[1], dttemp);

            grdSemester2Detail.DataSource = dttemp;
            grdSemester2Detail.DataBind();
           
        }

        //Reset Manual Shifting of Semester 1
        protected void btnResetSemester1_Click(object sender, EventArgs e)
        {
            LBLerror.Text = "";
            Label1.Text = "";
            lblErrorMian.Text = "";
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
            int creditHr = 0;
            foreach (GridViewRow row in grdSugSemester2.Rows)
            {
                creditHr = creditHr + int.Parse(row.Cells[3].Text.ToString().Trim());
            }
            int rangfrom = 60;
            int rang = 125 - creditHr;
            if (rang >= 70)
            {
                rang = 70;
            }
            else
            {
                rangfrom = 50;
            }
            BusinessLayer.CalcualteResult obj = new BusinessLayer.CalcualteResult();
            obj.setTotalCridetHr(rangfrom, rang);
            obj.CalculateResults(dtTools, dtMath, dtResearch, dtPrograming);
            DataSet dtsm1 = obj.SortSmester1Data();
            grdSugSemester1.DataSource = dtsm1.Tables[0];
            grdSugSemester1.DataBind();
            grdNonSugSemester1.DataSource = dtsm1.Tables[1];
            grdNonSugSemester1.DataBind();

            DataTable dt = obj.GetSM1RecordInfo();
            DataColumn dc = new DataColumn("none Selected");
            dt.Columns.Add(dc);
            Add_falseNegetive(dtsm1.Tables[0], dt);
            Add_falseNegetive(dtsm1.Tables[1], dt);
            grdSemester1Detail.DataSource = dt;
            grdSemester1Detail.DataBind();
            
           
        }

      
  
    }
}