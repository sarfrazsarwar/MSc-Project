using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
namespace Data_analytic
{
    public partial class MathematicsResearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.DataServices m = new BusinessLayer.DataServices();
            DataTable dtMath = m.GetMathAcademicInfo();
          
            grdMath.DataSource = dtMath;
            grdMath.DataBind();

            DataTable dtResearch = m.GetResAcademicInfo();
            grdResearch.DataSource = dtResearch;
            grdResearch.DataBind();
            if (!IsPostBack)
            {
               
                
                if(Session["Mathmetic"] != null)
                LoadMathsSelState();
                if (Session["ResearchExp"] != null)
                LoadResSelState();
            }

        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdMath, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in grdMath.Rows)
            {
                if (row.RowIndex == grdMath.SelectedIndex)
                {

                    row.ToolTip = string.Empty;

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void OnRowDataBound1(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdResearch, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged1(object sender, EventArgs e)
        {

            foreach (GridViewRow row in grdResearch.Rows)
            {
                if (row.RowIndex == grdResearch.SelectedIndex)
                {

                    row.ToolTip = string.Empty;

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }


        //To load previous selections of the student, during same session (Maths domain)
        void LoadMathsSelState()
        {
            DataTable dt = (DataTable)Session["Mathmetic"];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = grdMath.Rows[i];
                RadioButton rbt = (RadioButton)gdrow.FindControl("RowSelector1");
                RadioButton rbt1 = (RadioButton)gdrow.FindControl("RowSelector");
                RadioButton rbt3 = (RadioButton)gdrow.FindControl("RowSelector2");
                RadioButton rbt4 = (RadioButton)gdrow.FindControl("RowSelector3");
                if (dr["Available"].ToString() == "1")
                {

                    rbt.Checked = true;
                }
                else if (dr["NotAvailable"].ToString() == "1")
                {
                    rbt1.Checked = true;
                }
                else if (dr["intermediate"].ToString() == "1")
                {
                    rbt3.Checked = true;
                }
                else
                {
                    rbt4.Checked = true;
                }

                i++;
            }
        }


        // To maintain the user selections within session variable for subsequent use (Maths domain)
        void SetMathsData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "AcademicInfo_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));


            dt.Columns.Add(dc);

            dc = new DataColumn("NotAvailable", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("intermediate", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Expert", typeof(int));

            dt.Columns.Add(dc);
            foreach (GridViewRow row in grdMath.Rows)
            {
                DataRow dr = dt.NewRow();
              
                dr["data"] = row.Cells[0].Text;
                dr["AcademicInfo_ID"] = row.Cells[1].Text;
                RadioButton r = (RadioButton)row.FindControl("RowSelector1");
                if (r.Checked)
                    dr["Available"] = 1;

                else
                    dr["Available"] = 0;
                RadioButton r1 = (RadioButton)row.FindControl("RowSelector");

                if (r1.Checked)
                    dr["NotAvailable"] = 1;

                else
                    dr["NotAvailable"] = 0;
                RadioButton r2 = (RadioButton)row.FindControl("RowSelector2");

                if (r2.Checked)
                    dr["intermediate"] = 1;

                else
                    dr["intermediate"] = 0;
                RadioButton r3 = (RadioButton)row.FindControl("RowSelector3");

                if (r3.Checked)
                    dr["Expert"] = 1;

                else
                    dr["Expert"] = 0;

                dt.Rows.Add(dr);
            }
            Session["Mathmetic"] = dt;
        }

        //To load previous selections of the student, during same session (Research domain)
        void LoadResSelState()
        {
            DataTable dt = (DataTable)Session["ResearchExp"];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = grdResearch.Rows[i];
                RadioButton rbt = (RadioButton)gdrow.FindControl("RowSelector5");
                RadioButton rbt1 = (RadioButton)gdrow.FindControl("RowSelector4");
                RadioButton rbt3 = (RadioButton)gdrow.FindControl("RowSelector6");
                RadioButton rbt4 = (RadioButton)gdrow.FindControl("RowSelector7");
                if (dr["Available"].ToString() == "1")
                {

                    rbt.Checked = true;
                }
                else if (dr["NotAvailable"].ToString() == "1")
                {
                    rbt1.Checked = true;
                }
                else if (dr["intermediate"].ToString() == "1")
                {
                    rbt3.Checked = true;
                }
                else
                {
                    rbt4.Checked = true;
                }

                i++;
            }
        }


        // To maintain the user selections within session variable for subsequent use (Research domain)
        void SetResExpData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

            dt.Columns.Add(dc);

            dc = new DataColumn();
            dc.ColumnName = "AcademicInfo_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));

            dt.Columns.Add(dc);

            dc = new DataColumn("NotAvailable", typeof(int));

            dt.Columns.Add(dc);
            dc = new DataColumn("intermediate", typeof(int));
            dt.Columns.Add(dc);
            dc = new DataColumn("Expert", typeof(int));

            dt.Columns.Add(dc);
            foreach (GridViewRow row in grdResearch.Rows)
            {
                DataRow dr = dt.NewRow();
            
                dr["data"] = row.Cells[0].Text;
                dr["AcademicInfo_ID"] = row.Cells[1].Text;
                RadioButton r = (RadioButton)row.FindControl("RowSelector5");
                if (r.Checked)
                    dr["Available"] = 1;

                else
                    dr["Available"] = 0;
                RadioButton r1 = (RadioButton)row.FindControl("RowSelector4");

                if (r1.Checked)
                    dr["NotAvailable"] = 1;

                else
                    dr["NotAvailable"] = 0;
                RadioButton r2 = (RadioButton)row.FindControl("RowSelector6");

                if (r2.Checked)
                    dr["intermediate"] = 1;

                else
                    dr["intermediate"] = 0;
                RadioButton r3 = (RadioButton)row.FindControl("RowSelector7");

                if (r3.Checked)
                    dr["Expert"] = 1;

                else
                    dr["Expert"] = 0;

                dt.Rows.Add(dr);
            }
            Session["ResearchExp"] = dt;
        }

        // Go to next page
        protected void btnNext_Click(object sender, EventArgs e)
        {
            SetMathsData();
            SetResExpData();
            Response.Redirect("~/Tool.aspx");

        }

        // Go to previous page
        protected void btnPre_Click(object sender, EventArgs e)
        {
            SetMathsData();
            SetResExpData();
            Response.Redirect("~/Programming.aspx");
            
        }


        // Reset to default options
        protected void btnReset_Click(object sender, EventArgs e)
        {
            BusinessLayer.DataServices m = new BusinessLayer.DataServices();
            DataTable dtMath = m.GetMathAcademicInfo();
            grdMath.DataSource = dtMath;
            grdMath.DataBind();

            DataTable dtResearch = m.GetResAcademicInfo();
            grdResearch.DataSource = dtResearch;
            grdResearch.DataBind();
        }
    }
}