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
    public partial class Programing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            DataTable dtb = m.GetProgramingAcademicAssociatedInfo();
            //if (RBT_Noexperience.Checked)
            //{
            //    dtb.Clear();
            //}

            PRO_GD.DataSource = dtb;
            PRO_GD.DataBind();
            //Session.Add("UserName", "");
            if (Session["Programing"] != null && !IsPostBack)
            {
                LoadSelectedState();
                ////if (Session["CHK_PROG"].ToString() == "1")
                ////{
                ////    CHK_PROG.Checked = true;
                ////}
                ////else
                ////{
                ////    CHK_PROG.Checked = false;
                ////}
                //if (Session["CHK_PROG_VALUE"].ToString() == "1")
                //{
                //    RBT_Noexperience.Checked = true;

                //}
                //if (Session["CHK_PROG_VALUE"].ToString() == "2")
                //{
                //    RBT_NOVOICE.Checked = true;

                //}
                //if (Session["CHK_PROG_VALUE"].ToString() == "3")
                //{
                //    RBT_Intermediate.Checked = true;

                //}
                //if (Session["CHK_PROG_VALUE"].ToString() == "4")
                //{
                //    RBT_Expert.Checked = true;

                //}


            }
           
        }

        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(PRO_GD, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in PRO_GD.Rows)
            {
                if (row.RowIndex == PRO_GD.SelectedIndex)
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
        void LoadSelectedState()
        {
            DataTable dt = (DataTable)Session["programing"];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = PRO_GD.Rows[i];
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
        void SetLoadStateData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
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
            foreach (GridViewRow row in PRO_GD.Rows)
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
            Session["Programing"] = dt;
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PRO_GD.PageIndex = e.NewPageIndex;
            PRO_GD.DataBind();
            //  this.BindGrid();
        }

        protected void NEXT_Click(object sender, EventArgs e)
        {
            SetLoadStateData();
            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn();
            //dc.ColumnName = "data";

            //dt.Columns.Add(dc);

            //dc = new DataColumn("Available", typeof(int));
            //// dc.ColumnName = "Available";

            //dt.Columns.Add(dc);

            //dc = new DataColumn("NotAvailable", typeof(int));
            ////dc = new DataColumn();
            ////dc.ColumnName = "Available";

            ////dt.Columns.Add(dc);

            ////dc = new DataColumn();
            ////dc.ColumnName = "NotAvailable";

            //dt.Columns.Add(dc);


            //foreach (GridViewRow row in PRO_GD.Rows)
            //{
            //    DataRow dr = dt.NewRow();
            //    //    <asp:RadioButton ID="RowSelector1" runat="server" 
            //    //        GroupName="SuppliersGroup"  Width="100" />
            //    //</ItemTemplate>r
            //    dr["data"] = row.Cells[0].Text;
            //    if (RBT_Noexperience.Checked)
            //    {
            //        dr["NotAvailable"] = 1;
            //        dr["Available"] = 0;
            //    }
            //    else
            //    {
            //        RadioButton r = (RadioButton)row.FindControl("RBT_NOTAVAILABLE_PRO");
            //        if (r.Checked)
            //            dr["NotAvailable"] = 1;

            //        else
            //            dr["NotAvailable"] = 0;
            //        RadioButton r1 = (RadioButton)row.FindControl("RBT_AVAILABLE_PRO");

            //        if (r1.Checked)
            //            dr["Available"] = 1;

            //        else
            //            dr["Available"] = 0;
            //        }
            //        dt.Rows.Add(dr);
               
            //}
            //Session["Programing"] = dt;
            ////if (CHK_PROG.Checked)
            ////{
            ////    Session["CHK_PROG"] = 1;
            ////}
            ////else
            ////{
            ////    Session["CHK_PROG"] = 0;
            ////}
            //if (RBT_Expert.Checked)
            //{
            //    Session["CHK_PROG_VALUE"] = 4;
            //}
            //if (RBT_Intermediate.Checked)
            //{
            //    Session["CHK_PROG_VALUE"] = 3;
            //}
            //if (RBT_Noexperience.Checked)
            //{
            //    Session["CHK_PROG_VALUE"] = 1;
            //}
            //if (RBT_NOVOICE.Checked)
            //{
            //    Session["CHK_PROG_VALUE"] = 2;
            //}
            Response.Redirect("~/Mathmetic.aspx");
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            DataTable dtb = m.GetProgramingAcademicAssociatedInfo();
            //if (RBT_Noexperience.Checked)
            //{
            //    dtb.Clear();
            //}

            PRO_GD.DataSource = dtb;
            PRO_GD.DataBind();
            //foreach (GridViewRow row in PRO_GD.Rows)
            //{
            //    RadioButton r1 = (RadioButton)row.FindControl("RowSelector");
            //    r1.Checked = true;
            //}
        }

    }
}