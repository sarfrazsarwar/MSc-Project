using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic.Account
{
    public partial class Register : System.Web.UI.Page  //change//
    {

        protected void Page_Load(object sender, EventArgs e)
        {
           // RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
            if(!IsPostBack)
            Session.RemoveAll();
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)  //change//
        {
            //FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            BusinessLayer.LoginInfo m = new BusinessLayer.LoginInfo();
            if (m.DuplicateUserInfoRecord(UserName.Text) == 0)
            {
                List<string> strlist=new List<string>();  //change//
                strlist.Add(UserName.Text);
                strlist.Add(Password.Text);
                strlist.Add(Email.Text);
               
                m.InsertRecord(strlist);
                int noofRecord = m.GetUserInfoRecord(UserName.Text, Password.Text);  //change//
                Session.Add("UserID", noofRecord);
                Session.Add("UserName", UserName.Text);
                if (UserName.Text.ToUpper() == "ADMINISTRATOR" || UserName.Text.ToUpper() == "ADMIN")
                {
                    Response.Redirect("~/ModifyReq.aspx");
                }
                else
                Response.Redirect("~/Programing.aspx");
            }
            //else
            //{
            //    Response.Redirect("About.aspx");
            //}
          //  string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            //if (String.IsNullOrEmpty(continueUrl))
            //{
            //    continueUrl = "~/";
            //}
            //Response.Redirect(continueUrl);
        }

      

    }
}
