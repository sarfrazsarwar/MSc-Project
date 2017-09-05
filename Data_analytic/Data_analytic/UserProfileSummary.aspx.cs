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
                ShowToolSummary();
                ShowProgSummary();
                ShowMathsSummary();
                ShowResSummary();
            }

        }

        /// <summary>
        //Show user profile selections associated to programing domain
        /// </summary>
        void ShowProgSummary()
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
        void ShowMathsSummary()
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
        void ShowResSummary()
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
        void ShowToolSummary()
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


        /// <summary>
        /// To save user profile to application database
        /// </summary>

        void SaveUserInputRec(string TblName, BusinessLayer.DataServices m)
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
                        if (dr["intermediate"].ToString() == "1")
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

                        m.InsertUserInputRec(User_ID, AcademicInfo_ID, Level);
                    }
                }
            }
        }

        // To delete any previous data in database related to student and call SaveUserInputRec() for each expertise domain

        protected void btnNext_Click(object sender, EventArgs e)
        {
             BusinessLayer.DataServices m = new BusinessLayer.DataServices();
             int User_ID = (int)Session["UserID"];
             m.DeleteUserInputRec(User_ID);
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    SaveUserInputRec("Programing", m);
                }
                else if (i == 1)
                {
                    SaveUserInputRec("Tool", m);
                }
                else if (i == 2)
                {
                    SaveUserInputRec("Mathmetic", m);
                }
                else if (i == 3)
                {
                    SaveUserInputRec("ResearchExp", m);
                }
            }
            Session["CallFromResult"] = "NotModify";
            Response.Redirect("~/Result.aspx");
        }

        //To modify Tool selections - Go to previous page

        protected void btnPre_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tool.aspx");
        }
    }
}