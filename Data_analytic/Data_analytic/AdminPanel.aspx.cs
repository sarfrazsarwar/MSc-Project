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
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
            
            {
                BusinessLayer.EditModuleReq R = new BusinessLayer.EditModuleReq();

                DataTable dt = R.GetModuleInfo();

                Module_GD.DataSource = dt;
                Module_GD.DataBind();
            }

           
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Module_GD, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in Module_GD.Rows)
            {
                if (row.RowIndex == Module_GD.SelectedIndex)
                {

                    row.ToolTip = string.Empty;

                    BusinessLayer.EditModuleReq R = new BusinessLayer.EditModuleReq();
                    {
                        int mmID = int.Parse(row.Cells[1].Text);
                        string str= row.Cells[0].Text;
                        Session.Add("REQ_Module", str);
                        Session.Add("REQ_ID", mmID);
                        if (grdRequirment.Rows.Count > 0)
                        {

                        }
                        DataTable dt1 = R.GetModuleReq(mmID);
                        grdRequirment.DataSource = dt1;
                        grdRequirment.DataBind();
                        UpdatePanel1.Update();
                    }

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row";
                }
            }
        }
       
        //Event function to modify module requirements 
        protected void btnModify_Click(object sender, EventArgs e)
        {

            lblError.Text = "";
            if (Session["REQ_Module"] == null && Session["REQ_ID"] == null)
            {

                lblError.Text = "Click to select appropriate academic module";

           
            }
            else
            {
                Response.Redirect("~/AdminEditReq.aspx");
            }
        }

    }
}