﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

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
                //if (Session["CHK_PROG"].ToString() == "1")
                //{
                //    CHK_PROG.Checked = true;
                //}
                //else
                //{
                //    CHK_PROG.Checked = false;
                //}
                if (Session["CHK_PROG_VALUE"].ToString() == "1")
                {
                    RBT_Noexperience.Checked = true;

                }
                if (Session["CHK_PROG_VALUE"].ToString() == "2")
                {
                    RBT_NOVOICE.Checked = true;

                }
                if (Session["CHK_PROG_VALUE"].ToString() == "3")
                {
                    RBT_Intermediate.Checked = true;

                }
                if (Session["CHK_PROG_VALUE"].ToString() == "4")
                {
                    RBT_Expert.Checked = true;

                }


            }
           
        }
        void LoadSelectedState()
        {
            DataTable dt = (DataTable)Session["Programing"];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = PRO_GD.Rows[i];
                RadioButton rbt = (RadioButton)gdrow.FindControl("RBT_AVAILABLE_PRO") as RadioButton;
                RadioButton rbt1 = (RadioButton)gdrow.FindControl("RBT_NOTAVAILABLE_PRO") as RadioButton;
                if (dr["Available"].ToString() == "1")
                {

                    rbt.Checked = true;
                }
                
                else // if (dr["NotAvailable"].ToString() == "1")
                {
                    rbt1.Checked = true;
                }
                i++;
                // gdrow.
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PRO_GD.PageIndex = e.NewPageIndex;
            PRO_GD.DataBind();
            //  this.BindGrid();
        }

        protected void NEXT_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();
            dc.ColumnName = "data";

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


            foreach (GridViewRow row in PRO_GD.Rows)
            {
                DataRow dr = dt.NewRow();
                //    <asp:RadioButton ID="RowSelector1" runat="server" 
                //        GroupName="SuppliersGroup"  Width="100" />
                //</ItemTemplate>r
                dr["data"] = row.Cells[0].Text;
                if (RBT_Noexperience.Checked)
                {
                    dr["NotAvailable"] = 1;
                    dr["Available"] = 0;
                }
                else
                {
                    RadioButton r = (RadioButton)row.FindControl("RBT_NOTAVAILABLE_PRO");
                    if (r.Checked)
                        dr["NotAvailable"] = 1;

                    else
                        dr["NotAvailable"] = 0;
                    RadioButton r1 = (RadioButton)row.FindControl("RBT_AVAILABLE_PRO");

                    if (r1.Checked)
                        dr["Available"] = 1;

                    else
                        dr["Available"] = 0;
                    }
                    dt.Rows.Add(dr);
               
            }
            Session["Programing"] = dt;
            //if (CHK_PROG.Checked)
            //{
            //    Session["CHK_PROG"] = 1;
            //}
            //else
            //{
            //    Session["CHK_PROG"] = 0;
            //}
            if (RBT_Expert.Checked)
            {
                Session["CHK_PROG_VALUE"] = 4;
            }
            if (RBT_Intermediate.Checked)
            {
                Session["CHK_PROG_VALUE"] = 3;
            }
            if (RBT_Noexperience.Checked)
            {
                Session["CHK_PROG_VALUE"] = 1;
            }
            if (RBT_NOVOICE.Checked)
            {
                Session["CHK_PROG_VALUE"] = 2;
            }
            Response.Redirect("~/Mathmetic.aspx");
            
        }

    }
}