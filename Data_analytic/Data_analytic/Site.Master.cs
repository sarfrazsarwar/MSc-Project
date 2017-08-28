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
            
            //string stname = Session["UserName"].ToString();
            //if (stname.Length == 0)
            //{
            //    logout.Visible = false;

            //}
            //else
            //{
            //    Label1.Text = stname;
            //    logout.Visible = true;
            //}

            if (Session["UserID"] != null)
            {
                Button1.Visible = true;
                Button3.Visible = true;
                Button2.Visible = true;
                Label1.Text = Session["UserName"].ToString() +"   ";
            }
            else
            {
                Button1.Visible = false;
                Button3.Visible = false;
                Button2.Visible = false;
                Label1.Text = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        { 
           
            Session["call"] = "LOG";
            if (Session["Reviews"] != null)
            {
                string str = Session["Reviews"].ToString();
                if (str.Trim().Length == 0)
                {
                    ModalPopupExtender1.TargetControlID = "Button1";

                    ModalPopupExtender1.Show();
                    ModalPopupExtender1.Focus();
                }
                else
                {
                    Button1.Visible = false;
                    Button3.Visible = false;
                    Button2.Visible = false;
                    Label1.Text = "";
                    Response.Redirect("~/Default.aspx");
                }
            }
            else
            {
                Button1.Visible = false;
                Button3.Visible = false;
                Button2.Visible = false;
                Label1.Text = "";
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnOkay_Click(object sender, EventArgs e)
        {
            string msg = TextBox1.Text.Trim();
            if (msg.Length > 0 && Session["UserID"] != null)
            {
                int id=(int)Session["UserID"];
                BusinessLayer.LoginInfo m = new BusinessLayer.LoginInfo();
                Session["Reviews"] = msg;
                 m.UserReviewsUpdate(msg, id);
                //UpdatePanel record;
            }
            if (Session["call"] != null)
            {
               if( Session["call"].ToString() == "LOG")
                {
                    Button1.Visible = false;
                    Button3.Visible = false;
                    Button2.Visible = false;
                    Label1.Text = "";
                    Response.Redirect("~/Default.aspx");
                }
            }
           
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["call"] = "NOLOG";
            ModalPopupExtender1.TargetControlID = "Button3";
            ModalPopupExtender1.Show();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            String strPathAndQuery = HttpContext.Current.Request.Url.PathAndQuery;
            Session["URL"] = "~" + strPathAndQuery;
            Response.Redirect("~/Account/ChangePassword.aspx");
        }
    }
}
