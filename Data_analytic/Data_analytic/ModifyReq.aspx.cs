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
    public partial class ModifyReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            
            //int id = Module_GD.SelectedIndex;
            //if (id >= 0)
            //{
            //    int y = 0;
            //}
           // if (!IsPostBack)
            {
                BusinessLayer.EditRequirment R = new BusinessLayer.EditRequirment();

                DataTable dt = R.GetModuleInfo();

                Module_GD.DataSource = dt;
                Module_GD.DataBind();

                //if (id >= 0)
                //{
                //   int mmID=int.Parse(Module_GD.Rows[id].Cells[1].Text);
                //    if (REQ_GD.Rows.Count > 0)
                //    {
                        
                //    }
                //    DataTable dt1 = R.GetModuleRequirement(mmID);
                //  REQ_GD.DataSource=dt1;
                //    REQ_GD.DataBind();
                //}
            }

           
        }
        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(Module_GD, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in Module_GD.Rows)
            {
                if (row.RowIndex == Module_GD.SelectedIndex)
                {
                   // row.BackColor = ColorTranslator.FromHtml("#A1DCF2");
                    row.ToolTip = string.Empty;

                    BusinessLayer.EditRequirment R = new BusinessLayer.EditRequirment();
                    {
                        int mmID = int.Parse(row.Cells[1].Text);
                        string str= row.Cells[0].Text;
                        Session.Add("REQ_Module", str);
                        Session.Add("REQ_ID", mmID);
                        if (REQ_GD.Rows.Count > 0)
                        {

                        }
                        DataTable dt1 = R.GetModuleRequirement(mmID);
                        REQ_GD.DataSource = dt1;
                        REQ_GD.DataBind();
                        UpdatePanel1.Update();
                    }

                }
                else
                {
                    row.BackColor = ColorTranslator.FromHtml("#FFFFFF");
                    row.ToolTip = "Click to select this row.";
                }
            }
        }
        protected void TestLink(object sender, EventArgs e)
        {
            int id = Module_GD.SelectedIndex;
            if (id >= 0)
            {
                int y = 0;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["REQ_Module"] == null && Session["REQ_ID"] == null)
            {
                  
         
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Select The Module');", true);
           
            }
            else
            {
                Response.Redirect("~/EditReq.aspx");
            }
        }

        //TestLink()
    }
}