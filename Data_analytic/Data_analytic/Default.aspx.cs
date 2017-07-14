using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Data_analytic
{
    public partial class _Default : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            RegisterHyperLink.NavigateUrl = "Account/Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            BusinessLayer.LoginInfo m = new BusinessLayer.LoginInfo();
            int noofRecord = m.GetUserInfoRecord(LoginUser.UserName, LoginUser.Password);
            if (noofRecord >= 1)
            {
                Session.Add("UserID", noofRecord);
                Session.Add("UserName", LoginUser.UserName);
                Response.Redirect("~/Programing.aspx");
            }


        }

        
    }
}
