using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class ResultSummary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                showToolSummary();
                showProgramingSummary();
                showMathmeticSummary();
                showResearchSummary();
                 BusinessLayer.CalcualteResult obj = new BusinessLayer.CalcualteResult();
                   
                int User_ID =(int)Session["UserID"];
                 DataTable dtModuleSemester2=  obj.GetPreRecordSM2(User_ID);
                 grdSugSemester2.DataSource = dtModuleSemester2;
                 grdSugSemester2.DataBind();
                 DataTable dtModuleSemester1 = obj.GetPreRecordSM1(User_ID);
                 grdSugSemester1.DataSource = dtModuleSemester1;
                 grdSugSemester1.DataBind();
            }
           
        }

        // To implement web link column for module details grid

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

        // To implement web link column for module details grid
        protected string GetUrl(object id)
        {
            return "http://" + id;
        }

        /// <summary>
        //Show user profile selections associated to Programming domain
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
                    if (dr["intermediate"].ToString() == "1")
                    {
                        str = "intermediate";
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
        //Show user profile selections associated to Maths domain
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
                    if (dr["intermediate"].ToString() == "1")
                    {
                        str = "intermediate";
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
        //Show user profile selections associated to Research domain
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
                    if (dr["intermediate"].ToString() == "1")
                    {
                        str = "intermediate";
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
        //Show user profile selections associated to Tools domain
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
                        if (dr["intermediate"].ToString() == "1")
                        {
                            str = "intermediate";
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


        //Go to Programming page for any modificatiosn in expertise and recalculate modules of semester 1 and semester 2
        protected void btnModifyExpertise_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Programming.aspx");
        }
         

        // Go to result page for readjusting the semester 1 and semester 2  modules
        protected void btnModifyModule_Click(object sender, EventArgs e)
        {
            Session["CallFromResult"] = "Modify";
            Response.Redirect("~/Result.aspx");
        }
    }
}