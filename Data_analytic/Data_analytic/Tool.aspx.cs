﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;


namespace Data_analytic
{
    public partial class Tool : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            TOOL_GV.DataSource = m.GetToolAcademicAssociatedInfo();
            TOOL_GV.DataBind();
            //Session.Add("UserName", "");
            if (Session["Tool"] != null && !IsPostBack)
            {
                LoadSelectedState();
                
            }
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(TOOL_GV, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in TOOL_GV.Rows)
            {
                if (row.RowIndex == TOOL_GV.SelectedIndex)
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
            DataTable dt=(DataTable)Session["Tool"];
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    GridViewRow gdrow = TOOL_GV.Rows[i];
                     RadioButton rbt=(RadioButton) gdrow.FindControl("RowSelector1");
                     RadioButton rbt1 = (RadioButton)gdrow.FindControl("RowSelector");
                     RadioButton rbt3 = (RadioButton)gdrow.FindControl("RowSelector2");
                     RadioButton rbt4 = (RadioButton)gdrow.FindControl("RowSelector3");
                     if (dr["Available"].ToString() == "1")
                    {
                      
                        rbt.Checked=true;
                    }
                    else if(dr["NotAvailable"].ToString() == "1")
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
            foreach (GridViewRow row in TOOL_GV.Rows)
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
            Session["Tool"] = dt;
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TOOL_GV.PageIndex = e.NewPageIndex;
            TOOL_GV.DataBind();
          //  this.BindGrid();
        }
        protected void Pre_Click(object sender, EventArgs e)
        {
            SetLoadStateData();
            Response.Redirect("~/Mathmetic.aspx");
        }
        protected void NEXT_Click(object sender, EventArgs e)
        {
            SetLoadStateData();
            Response.Redirect("~/Summary.aspx");
        }

        protected void CHK_TOOL_CheckedChanged(object sender, EventArgs e)
        {
            //if (CHK_TOOL.Checked)
            //{
            //    //BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            //    //Suppliers.DataSource = m.GetAcademicAssociatedInfo();
            //    //Suppliers.DataBind();
            //}
            //else
            //{
            //    BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            //    Suppliers.DataSource = m.GetAcademicAssociatedInfo();
            //    Suppliers.DataBind();
            //}
        }

       
    }
}