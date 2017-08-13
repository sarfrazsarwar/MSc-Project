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
    public partial class Mathmetic : System.Web.UI.Page  //change//
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo(); //change//
            DataTable dt = m.GetMathmeticAcademicAssociatedInfo();  //change//  
            //if (RBT_Noexperience.Checked)
            //{
            //    dt.Clear();
            //}
            MATH_GD.DataSource = dt;
            MATH_GD.DataBind();

            DataTable dt1 = m.GetResearchAcademicAssociatedInfo();  //change//
            DG_RESEAECH.DataSource = dt1;
            DG_RESEAECH.DataBind();
            if (!IsPostBack)
            {
               
                
                if(Session["Mathmetic"] != null)
                LoadMathmeticSelectedState();
                if (Session["ResearchExp"] != null)
                LoadResearchSelectedState();
            }

        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e) //change//
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(MATH_GD, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e) //change//
        {

            foreach (GridViewRow row in MATH_GD.Rows)
            {
                if (row.RowIndex == MATH_GD.SelectedIndex)
                {
                   // row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void OnRowDataBound1(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e) //change//
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(DG_RESEAECH, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged1(object sender, EventArgs e)  //change//
        {

            foreach (GridViewRow row in DG_RESEAECH.Rows)
            {
                if (row.RowIndex == DG_RESEAECH.SelectedIndex)
                {
                   // row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        void LoadMathmeticSelectedState() //change//
        {
            DataTable dt = (DataTable)Session["Mathmetic"];  //change//
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = MATH_GD.Rows[i];
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
                else if (dr["Intermedite"].ToString() == "1")
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
        void SetMathmeticData()
        {
            DataTable dt = new DataTable();  //change//
            DataColumn dc = new DataColumn();  //change//
            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            //dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "AA_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));

            // dc.ColumnName = "Available";

            dt.Columns.Add(dc);

            dc = new DataColumn("NotAvailable", typeof(int));
            //dc = new DataColumn();
            //dc.ColumnName = "Available";

            //dt.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "NotAvailable";

            dt.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "Intermedite";
            dc = new DataColumn("Intermedite", typeof(int));
            dt.Columns.Add(dc);
            //dc = new DataColumn();

            //dc.ColumnName = "Expert";

            dc = new DataColumn("Expert", typeof(int));

            dt.Columns.Add(dc);
            foreach (GridViewRow row in MATH_GD.Rows)
            {
                DataRow dr = dt.NewRow();
                //    <asp:RadioButton ID="RowSelector1" runat="server" 
                //        GroupName="SuppliersGroup"  Width="100" />
                //</ItemTemplate>r
                dr["data"] = row.Cells[0].Text;
                dr["AA_ID"] = row.Cells[1].Text;
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
                    dr["Intermedite"] = 1;

                else
                    dr["Intermedite"] = 0;
                RadioButton r3 = (RadioButton)row.FindControl("RowSelector3");

                if (r3.Checked)
                    dr["Expert"] = 1;

                else
                    dr["Expert"] = 0;

                dt.Rows.Add(dr);
            }
            Session["Mathmetic"] = dt;
        }

        void LoadResearchSelectedState()
        {
            DataTable dt = (DataTable)Session["ResearchExp"];  //change//
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = DG_RESEAECH.Rows[i];
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
                else if (dr["Intermedite"].ToString() == "1")
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
        void SetResearchExprianceData()  //change//
        {
            DataTable dt = new DataTable(); //change//
            DataColumn dc = new DataColumn();  //change//
            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            //dt.Columns.Add(dc);
            dc = new DataColumn();
            dc.ColumnName = "AA_ID";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));

            // dc.ColumnName = "Available";

            dt.Columns.Add(dc);

            dc = new DataColumn("NotAvailable", typeof(int));
            //dc = new DataColumn();
            //dc.ColumnName = "Available";

            //dt.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "NotAvailable";

            dt.Columns.Add(dc);

            //dc = new DataColumn();
            //dc.ColumnName = "Intermedite";
            dc = new DataColumn("Intermedite", typeof(int));
            dt.Columns.Add(dc);
            //dc = new DataColumn();

            //dc.ColumnName = "Expert";

            dc = new DataColumn("Expert", typeof(int));

            dt.Columns.Add(dc);
            foreach (GridViewRow row in DG_RESEAECH.Rows)
            {
                DataRow dr = dt.NewRow();
                //    <asp:RadioButton ID="RowSelector1" runat="server" 
                //        GroupName="SuppliersGroup"  Width="100" />
                //</ItemTemplate>r
                dr["data"] = row.Cells[0].Text;
                dr["AA_ID"] = row.Cells[1].Text;
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
                    dr["Intermedite"] = 1;

                else
                    dr["Intermedite"] = 0;
                RadioButton r3 = (RadioButton)row.FindControl("RowSelector7");

                if (r3.Checked)
                    dr["Expert"] = 1;

                else
                    dr["Expert"] = 0;

                dt.Rows.Add(dr);
            }
            Session["ResearchExp"] = dt;
        }

        //void LoadSelectedState()
        //{
        //    DataTable dt = (DataTable)Session["Mathmetic"];
        //    int i = 0;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        GridViewRow gdrow = MATH_GD.Rows[i];
        //        RadioButton rbt = (RadioButton)gdrow.FindControl("RBT_AVAIABLE");
        //        RadioButton rbt1 = (RadioButton)gdrow.FindControl("RBT_NOTAVAIABLE");
        //        if (dr["Available"].ToString() == "1")
        //        {

        //            rbt.Checked = true;
        //        }

        //        else if (dr["NotAvailable"].ToString() == "1")
        //        {
        //            rbt1.Checked = true;
        //        }
        //        i++;
        //        // gdrow.
        //    }
        //}
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MATH_GD.PageIndex = e.NewPageIndex;
            MATH_GD.DataBind();
            //  this.BindGrid();
        }
        //void SetMathmeticData()
        //{
        //    DataTable dt = new DataTable();
        //    DataColumn dc = new DataColumn();

        //    dc.ColumnName = "data";

        //    dt.Columns.Add(dc);
        //    dc = new DataColumn("Available", typeof(int));
        //    // dc.ColumnName = "Available";

        //    dt.Columns.Add(dc);

        //    dc = new DataColumn("NotAvailable", typeof(int));
        //    //dc.ColumnName = "";

        //    dt.Columns.Add(dc);


        //    foreach (GridViewRow row in MATH_GD.Rows)
        //    {
        //        DataRow dr = dt.NewRow();
        //        //    <asp:RadioButton ID="RowSelector1" runat="server" 
        //        //        GroupName="SuppliersGroup"  Width="100" />
        //        //</ItemTemplate>r
        //        dr["data"] = row.Cells[0].Text;
        //        //if (RBT_Noexperience.Checked)
        //        //{
        //        //    dr["NotAvailable"] = 1;
        //        //    dr["Available"] = 0;
        //        //}
        //        //else
        //        {
        //            RadioButton r = (RadioButton)row.FindControl("RBT_AVAIABLE");
        //            if (r.Checked)
        //                dr["Available"] = 1;

        //            else
        //                dr["Available"] = 0;
        //            RadioButton r1 = (RadioButton)row.FindControl("RBT_NOTAVAIABLE");

        //            if (r1.Checked)
        //                dr["NotAvailable"] = 1;

        //            else
        //                dr["NotAvailable"] = 0;
        //        }
        //        dt.Rows.Add(dr);
        //    }
        //    Session["Mathmetic"] = dt;
        //    //if (CHK_MATH.Checked)
        //    //{
        //    //    Session["CHK_MATH"] = 1;
        //    //}
        //    //else
        //    //{
        //    //    Session["CHK_MATH"] = 0;
        //    //}
        //    if (RBT_Expert.Checked)
        //    {
        //        Session["CHK_MATH_VALUE"] = 4;
        //    }
        //    if (RBT_Intermediate.Checked)
        //    {
        //        Session["CHK_MATH_VALUE"] = 3;
        //    }
        //    if (RBT_Noexperience.Checked)
        //    {
        //        Session["CHK_MATH_VALUE"] = 1;
        //    }
        //    if (RBT_NOVOICE.Checked)
        //    {
        //        Session["CHK_MATH_VALUE"] = 2;
        //    }

        //    if (RBT_R_Expert.Checked)
        //    {
        //        Session["CHK_RE_VALUE"] = 4;
        //    }
        //    if (RBT_R_Inter.Checked)
        //    {
        //        Session["CHK_RE_VALUE"] = 3;
        //    }
        //    if (RBT_R_NOEXP.Checked)
        //    {
        //        Session["CHK_RE_VALUE"] = 1;
        //    }
        //    if (RBT_R_NOvice.Checked)
        //    {
        //        Session["CHK_RE_VALUE"] = 2;
        //    }
        //}
        protected void NEXT_Click(object sender, EventArgs e)
        {
            SetMathmeticData();
            SetResearchExprianceData();
            Response.Redirect("~/Tool.aspx");

        }
        protected void Pre_Click(object sender, EventArgs e)
        {
            SetMathmeticData();
            SetResearchExprianceData();
            Response.Redirect("~/Programing.aspx");
            
        }
    }
}