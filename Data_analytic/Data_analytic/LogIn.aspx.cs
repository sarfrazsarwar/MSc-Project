using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class LogIn : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            RegisterHyperLink.NavigateUrl = "Account/RegisterUser.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!IsPostBack)
                Session.RemoveAll();
        }


        // To login
        protected void LoginButton_Click(object sender, EventArgs e)
        {

            BusinessLayer.LogInInfoCalc m = new BusinessLayer.LogInInfoCalc();
            int UserID = m.GetUserInfoRecord(LoginUser.UserName, LoginUser.Password);
            if (UserID >= 1)
            {
                Session["Reviews"] = m.GetReviews();
                Session.Add("UserID", UserID);
                Session.Add("UserName", LoginUser.UserName.Trim());

                if (LoginUser.UserName.ToUpper() == "ADMINISTRATOR" || LoginUser.UserName.ToUpper() == "ADMIN")
                {
                    Session["Reviews"] = "NotShow";
                    Response.Redirect("~/AdminPanel.aspx");
                }
                else
                {
                    
                    BusinessLayer.PrResultSummary pr = new BusinessLayer.PrResultSummary();
                    DataTable dtProg = pr.GetProg_Selection(UserID);
                    DataTable dtTool = pr.GetTool_Selection(UserID);
                    DataTable dtmath = pr.GetMathmetic_Selection(UserID);
                    DataTable dtresearch = pr.GetResearch_Selection(UserID);

                    if (dtProg.Rows.Count == 0 && dtTool.Rows.Count == 0 && dtmath.Rows.Count == 0 && dtresearch.Rows.Count == 0)
                        Response.Redirect("~/Programming.aspx");
                    else
                    {
                        Session["Programing"] = dtProg;
                        Session["ResearchExp"] = dtresearch;
                        Session["Mathmetic"] = dtmath;
                        Session["TOOL"] = dtTool;
                        Response.Redirect("~/ResultSummary.aspx");

                    }
                }
                }


        }

        
    }
}
