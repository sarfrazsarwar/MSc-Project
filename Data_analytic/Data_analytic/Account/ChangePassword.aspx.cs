using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data_analytic.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            string str = Session["UserName"].ToString().Trim();
            BusinessLayer.LogInInfoCalc m = new BusinessLayer.LogInInfoCalc();
            int noofRecord = m.GetUserInfoRecord(str, CurrentPassword.Text.Trim());
            if (noofRecord > 0)
            {
                int ID = int.Parse(Session["UserID"].ToString());
                m.UserpasswordUpdate(NewPassword.Text.Trim(), ID);
                Response.Redirect("~/Account/ChangePasswordSuccess.aspx");
            }
            else
            {
                Label1.Text= "Current Password incorrect";
            }
            
        }

        protected void CancelPushButton_Click(object sender, EventArgs e)
        {
            string str = Session["URL"].ToString().Trim();
            Response.Redirect(str);
        }
    }
}
