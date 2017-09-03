using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class UserProfileSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showToolSummary();
                showProgramingSummary();
                showMathmeticSummary();
                showResearchSummary();
            }

        }

        /// <summary>
        //show User selection in programing page during its vists
        /// </summary>
        void showProgramingSummary()
        {
            if (Session["Programing"] != null)
            {
                DataTable dtPrograming = (DataTable)Session["Programing"];
                DataRow[] result = dtPrograming.Select("NotAvailable=0");
                DataTable dtSelectPrograming = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dtSelectPrograming.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dtSelectPrograming.Columns.Add(dc);
                foreach (DataRow dr in result)
                {
                    DataRow drn = dtSelectPrograming.NewRow();
                    drn["Data"] = dr["Data"];
                    string str = "";
                    if (dr["Intermedite"].ToString() == "1")
                    {
                        str = "Intermedite";
                    }
                    else if (dr["Expert"].ToString() == "1")
                    {
                        str = "Expert";
                    }
                    else if (dr["Available"].ToString() == "1")
                    {
                        str = "Novice";
                    }
                    drn["Expertise"] = str;
                    dtSelectPrograming.Rows.Add(drn);
                }
                grdPrograming.DataSource = dtSelectPrograming;
                grdPrograming.DataBind();
            }
        }
        /// <summary>
        //show User selection in Research and Mathmetic  page during its vists
        /// </summary>
        void showMathmeticSummary()
        {
            if (Session["Mathmetic"] != null)
            {
                DataTable dtMath = (DataTable)Session["Mathmetic"];
                DataRow[] result = dtMath.Select("NotAvailable=0");
                DataTable dtSelectionMath = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dtSelectionMath.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dtSelectionMath.Columns.Add(dc);
                foreach (DataRow dr in result)
                {
                    DataRow drn = dtSelectionMath.NewRow();
                    drn["Data"] = dr["Data"];
                    string str = "";
                    //Expert
                    if (dr["Intermedite"].ToString() == "1")
                    {
                        str = "Intermedite";
                    }
                    else if (dr["Expert"].ToString() == "1")
                    {
                        str = "Expert";
                    }
                    else if (dr["Available"].ToString() == "1")
                    {
                        str = "Novice";
                    }
                    drn["Expertise"] = str;
                    dtSelectionMath.Rows.Add(drn);
                }
                grdMath.DataSource = dtSelectionMath;
                grdMath.DataBind();
            }
        }
        /// <summary>
        //show User selection in Research and Mathmetic  page during its vists
        /// </summary>
        void showResearchSummary()
        {
            if (Session["ResearchExp"] != null)
            {
                DataTable dtResearch = (DataTable)Session["ResearchExp"];
                DataRow[] result = dtResearch.Select("NotAvailable=0");
                DataTable dtSelectionResearch = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dtSelectionResearch.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dtSelectionResearch.Columns.Add(dc);
                foreach (DataRow dr in result)
                {
                    DataRow drn = dtSelectionResearch.NewRow();
                    drn["Data"] = dr["Data"];
                    string str = "";
                    //Expert
                    if (dr["Intermedite"].ToString() == "1")
                    {
                        str = "Intermedite";
                    }
                    else if (dr["Expert"].ToString() == "1")
                    {
                        str = "Expert";
                    }
                    else if (dr["Available"].ToString() == "1")
                    {
                        str = "Novice";
                    }
                    drn["Expertise"] = str;
                    dtSelectionResearch.Rows.Add(drn);
                }
                grdResearch.DataSource = dtSelectionResearch;
                grdResearch.DataBind();
            }
        }
        /// <summary>
        //show User selection in tool page during its vists
        /// </summary>
        void showToolSummary()
        {
            if (Session["Tool"] != null)
            {
                DataTable dtTool = (DataTable)Session["Tool"];
                DataTable dtSelectionTools = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dtSelectionTools.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dtSelectionTools.Columns.Add(dc);
                foreach (DataRow dr in dtTool.Rows)
                {
                    if (dr["NotAvailable"].ToString() == "0")
                    {
                        DataRow drn = dtSelectionTools.NewRow();
                        drn["Data"] = dr["Data"];
                        string str = "";
                        if (dr["Intermedite"].ToString() == "1")
                        {
                            str = "Intermedite";
                        }
                        else if (dr["Expert"].ToString() == "1")
                        {
                            str = "Expert";
                        }
                        else if (dr["Available"].ToString() == "1")
                        {
                            str = "Novice";
                        }
                        drn["Expertise"] = str;
                        dtSelectionTools.Rows.Add(drn);
                    }
                }
                grdTools.DataSource = dtSelectionTools;
                grdTools.DataBind();
            }
        }


        /// <summary>
        /// Save user record in Data base that selection during vists programing ,Tool,Mathmetic and Research
        /// </summary>
        
        void SaveUserInputRecord(string TblName, BusinessLayer.DataServices m)
        {
            if (Session[TblName] != null)
            {
                DataTable dt = (DataTable)Session[TblName];
                int User_ID =  (int)Session["UserID"];
               
                
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["NotAvailable"].ToString() == "0")
                    {
                        
                        int AcademicInfo_ID= int.Parse(dr["AcademicInfo_ID"].ToString());
                        int Level = 1;
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

                        m.InsertUserInputRecord(User_ID, AcademicInfo_ID, Level);
                    }
                }
            }
        }
        // To Selection the Sugest The Module When clicking next
        protected void btnNext_Click(object sender, EventArgs e)
        {
             BusinessLayer.DataServices m = new BusinessLayer.DataServices();
             int User_ID = (int)Session["UserID"];
             m.DeleteUserInputRecord(User_ID);
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    SaveUserInputRecord("Programing", m);
                }
                else if (i == 1)
                {
                    SaveUserInputRecord("Tool", m);
                }
                else if (i == 2)
                {
                    SaveUserInputRecord("Mathmetic", m);
                }
                else if (i == 3)
                {
                    SaveUserInputRecord("ResearchExp", m);
                }
            }
            Response.Redirect("~/Result.aspx");
        }
        //To Modify Tool Selections

        protected void btnPre_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tool.aspx");
        }
    }
}