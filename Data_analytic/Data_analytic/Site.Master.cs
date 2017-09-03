using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace Data_analytic
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["UserID"] != null)
            {
                btnLogout.Visible = true;
                btnContactUs.Visible = true;
                btnChgPswd.Visible = true;
                lblUserName.Text = Session["UserName"].ToString() +"   ";
            }
            else
            {
                btnLogout.Visible = false;
                btnContactUs.Visible = false;
                btnChgPswd.Visible = false;
                lblUserName.Text = "";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        { 
           
            Session["call"] = "LOG";
            if (Session["Reviews"] != null)
            {
                string str = Session["Reviews"].ToString();
                if (str.Trim().Length == 0)
                {
                    ModalPopupExtender1.TargetControlID = "btnLogout";

                    ModalPopupExtender1.Show();
                    ModalPopupExtender1.Focus();
                }
                else
                {
                    btnLogout.Visible = false;
                    btnContactUs.Visible = false;
                    btnChgPswd.Visible = false;
                    lblUserName.Text = "";
                    Response.Redirect("~/LogIn.aspx");
                }
            }
            else
            {
                btnLogout.Visible = false;
                btnContactUs.Visible = false;
                btnChgPswd.Visible = false;
                lblUserName.Text = "";
                Response.Redirect("~/LogIn.aspx");
            }
        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            string msg = TextBox1.Text.Trim();
            if (msg.Length > 0 && Session["UserID"] != null)
            {
                int id=(int)Session["UserID"];
                BusinessLayer.LogInInfoCalc m = new BusinessLayer.LogInInfoCalc();
                Session["Reviews"] = msg;
                 m.UserReviewsUpdate(msg, id);
                //UpdatePanel record;
            }
            if (Session["call"] != null)
            {
               if( Session["call"].ToString() == "LOG")
                {
                    btnLogout.Visible = false;
                    btnContactUs.Visible = false;
                    btnChgPswd.Visible = false;
                    lblUserName.Text = "";
                    Response.Redirect("~/LogIn.aspx");
                }
            }
           
           
        }

        protected void btnContactUs_Click(object sender, EventArgs e)
        {
            Session["call"] = "NOLOG";
            ModalPopupExtender1.TargetControlID = "btnContactUs";
            ModalPopupExtender1.Show();
        }

        protected void btnChgPswd_Click(object sender, EventArgs e)
        {

            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            Session["URL"] = "~" + strPathAndQuery;
            Response.Redirect("~/Account/ChangePassword.aspx");
        }
    }
}
