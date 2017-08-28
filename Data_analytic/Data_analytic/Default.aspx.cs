using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class _Default : System.Web.UI.Page
    {
        [System.Web.Services.WebMethod]
        public static string GetText()
        {
            for (int i = 0; i < 10; i++)
            {
                // In actual projects this action may be a database operation.
                //For demsonstration I have made this loop to sleep.
              
            }
            return "Download Complete...";
        }        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            RegisterHyperLink.NavigateUrl = "Account/Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!IsPostBack)
                Session.RemoveAll();
        }

        protected void LoginButton_Click(object sender, EventArgs e) //change//
        {

            BusinessLayer.LoginInfo m = new BusinessLayer.LoginInfo();
            int noofRecord = m.GetUserInfoRecord(LoginUser.UserName, LoginUser.Password);
            if (noofRecord >= 1)
            {
                Session["Reviews"] = m.GetReviews();
                Session.Add("UserID", noofRecord);
                Session.Add("UserName", LoginUser.UserName.Trim());

                if (LoginUser.UserName.ToUpper() == "ADMINISTRATOR" || LoginUser.UserName.ToUpper() == "ADMIN")
                {
                    Session["Reviews"] = "NotShow";
                    Response.Redirect("~/ModifyReq.aspx");
                }
                else
                {
                    
                    BusinessLayer.previous_Result pr = new BusinessLayer.previous_Result();
                    DataTable dtProg = pr.GetProg_Selection(noofRecord);
                    DataTable dtTool = pr.GetTool_Selection(noofRecord);
                    DataTable dtmath = pr.GetMathmetic_Selection(noofRecord);
                    DataTable dtresearch = pr.GetResearch_Selection(noofRecord);

                    if (dtProg.Rows.Count == 0 && dtTool.Rows.Count == 0 && dtmath.Rows.Count == 0 && dtresearch.Rows.Count == 0)
                        Response.Redirect("~/Programing.aspx");
                    else
                    {
                        Session["Programing"] = dtProg;
                        Session["ResearchExp"] = dtresearch;
                        Session["Mathmetic"] = dtmath;
                        Session["TOOL"] = dtTool;
                        Response.Redirect("~/Previous_summary.aspx");

                    }
                }
                }



        }

        
    }
}
