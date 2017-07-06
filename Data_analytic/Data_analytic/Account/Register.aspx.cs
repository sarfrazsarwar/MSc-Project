﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            BusinessLayer.LoginInfo m = new BusinessLayer.LoginInfo();
            if (m.GetUserInfoRecord(UserName.Text, Password.Text) == 0)
            {
                List<string> strlist=new List<string>();
                strlist.Add(UserName.Text);
                strlist.Add(Password.Text);
                strlist.Add(Email.Text);
               
                m.InsertRecord(strlist);
                Session.Add("UserName", UserName.Text);
                Response.Redirect("~/Programing.aspx");
            }
            else
            {
                Response.Redirect("About.aspx");
            }
          //  string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (String.IsNullOrEmpty(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }

      

    }
}