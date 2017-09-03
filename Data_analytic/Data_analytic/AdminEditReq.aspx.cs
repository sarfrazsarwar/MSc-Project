using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data;

namespace Data_analytic
{
    public partial class AdminEditReq : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            BusinessLayer.EditModuleReq R = new BusinessLayer.EditModuleReq();
            DataTable dt= R.GetAssocitedMoudleinfo();
            grdRequirment.DataSource = dt;
            grdRequirment.DataBind();
             
           Label1.Text = Session["REQ_Module"].ToString();

           if (!IsPostBack)
           {
               CheckStateOnGrid();
           }
        }

        void CheckStateOnGrid()
        {
            BusinessLayer.EditModuleReq R = new BusinessLayer.EditModuleReq();

            int id = int.Parse(Session["REQ_ID"].ToString());
            DataTable dt1 = R.GetModuleRequirement(id);
            {
                foreach (DataRow dr in dt1.Rows)
                {
                    string str = dr["Academic_info"].ToString();
                    int idd=int.Parse(dr["ExpertiseLevel_ID"].ToString());
                    SetCheckState(str,idd);
                }
            }
        }
        //Set the Current requirment of modules
        void SetCheckState(string Text,int expertise)
        {
            
            
            foreach (GridViewRow gdrow in grdRequirment.Rows)
            {

                string text = gdrow.Cells[0].Text.Trim();
                if (text == Text.Trim())
                {
                    RadioButton rbt = (RadioButton)gdrow.FindControl("RowSelector");
                    RadioButton rbt1 = (RadioButton)gdrow.FindControl("RowSelector1");
                    RadioButton rbt3 = (RadioButton)gdrow.FindControl("RowSelector2");
                    RadioButton rbt4 = (RadioButton)gdrow.FindControl("RowSelector3");
                    if (expertise == 2)
                    {
                        rbt1.Checked = true;
                    }
                    if (expertise == 3)
                    {
                        rbt3.Checked = true;
                    }
                    if (expertise == 4)
                    {
                        rbt4.Checked = true;
                    }
                    break;
                }
               
            }
        }


        protected void OnRowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(grdRequirment, "Select$" + e.Row.RowIndex);
                e.Row.ToolTip = "Click to select this row.";
            }
        }

        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

            foreach (GridViewRow row in grdRequirment.Rows)
            {
                if (row.RowIndex == grdRequirment.SelectedIndex)
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
        //Save the requirement of module in data base and go back
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int AcademicModule_ID=int.Parse(Session["REQ_ID"].ToString());
            BusinessLayer.EditModuleReq R = new BusinessLayer.EditModuleReq();
            R.DeleteModuleReqrRecord(AcademicModule_ID);

             foreach (GridViewRow gdrow in grdRequirment.Rows)
            {

                int AcademicInfo_ID = int.Parse(gdrow.Cells[1].Text.Trim());
               
                
                    RadioButton rbt = (RadioButton)gdrow.FindControl("RowSelector");
                    RadioButton rbt1 = (RadioButton)gdrow.FindControl("RowSelector1");
                    RadioButton rbt3 = (RadioButton)gdrow.FindControl("RowSelector2");
                    RadioButton rbt4 = (RadioButton)gdrow.FindControl("RowSelector3");
                 if(rbt.Checked)
                 {
                 }
                 else
                 {
                     int level=1;
                     
                     if(rbt1.Checked)
                     {
                         level=2;
                     }
                     else  if(rbt3.Checked)
                     {
                         level=3;
                     }
                     else  if(rbt4.Checked)
                     {
                         level=4;
                     }
                     if(level>1)
                     R.InsertModuleReqRecord(AcademicModule_ID,AcademicInfo_ID,level);

                 }
                  
                }
             Response.Redirect("~/AdminPanel.aspx");
        
        }
        //goto previous page
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPanel.aspx");
        }
    }
}