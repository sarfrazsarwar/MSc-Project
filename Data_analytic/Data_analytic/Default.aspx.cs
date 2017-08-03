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
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
            RegisterHyperLink.NavigateUrl = "Account/Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!IsPostBack)
                Session.RemoveAll();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {

            BusinessLayer.LoginInfo m = new BusinessLayer.LoginInfo();
            int noofRecord = m.GetUserInfoRecord(LoginUser.UserName, LoginUser.Password);
            if (noofRecord >= 1)
            {

                if (LoginUser.UserName.ToUpper() == "ADMINISTRATOR" || LoginUser.UserName.ToUpper() == "ADMIN")
                {
                    Response.Redirect("~/ModifyReq.aspx");
                }
                else
                {
                    Session.Add("UserID", noofRecord);
                    Session.Add("UserName", LoginUser.UserName);
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
