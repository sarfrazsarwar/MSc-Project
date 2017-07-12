using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                showToolSummary();
                showProgramingSummary();
                showMathmeticSummary();
                showResearchSummary();
            }
            //if (Session["CHK_MATH_VALUE"] != null)
            //{
            //    string str = Session["CHK_MATH_VALUE"].ToString();
            //    string str2 = "";
            //    if (str == "1")
            //    {
            //        str2 = "   No Expriance";
            //    }
            //    else if (str == "2")
            //    {
            //        str2 = "   NOVICE";
            //    }
            //    else if (str == "3")
            //    {
            //        str2 = "   Intermadite";
            //    }
            //    else if (str == "4")
            //    {
            //        str2 = "   Expert";
            //    }

            //    LBL_MATH.Text = "Mathmatic Aplitude   " + str2;
            //}
            //if (Session["CHK_PROG_VALUE"] != null)
            //{
            //    string str = Session["CHK_PROG_VALUE"].ToString();
            //    string str2 = "";
            //    if (str == "1")
            //    {
            //        str2 = "   No Expriance";
            //    }
            //    else if (str == "2")
            //    {
            //        str2 = "   NOVICE";
            //    }
            //    else if (str == "3")
            //    {
            //        str2 = "   Intermadite";
            //    }
            //    else if (str == "4")
            //    {
            //        str2 = "   Expert";
            //    }

            //    LBL_Programing.Text = "Programing   " + str2;
            //}
            
            //if (Session["CHK_RE_VALUE"] != null)
            //{
            //    string str= Session["CHK_RE_VALUE"].ToString();
            //    string str2 = "";
            //    if (str == "1")
            //    {
            //        str2 = "   No Expriance";
            //    }
            //    else if (str == "2")
            //    {
            //        str2 = "   NOVICE";
            //    }
            //    else if (str == "3")
            //    {
            //        str2 = "   Intermadite";
            //    }
            //    else  if (str == "4")
            //    {
            //        str2 = "   Expert";
            //    }

            //    LBL_RESearch.Text = "Research Expriance  " + str2;
            //}
            //SetLoadStateData();
          //  
        }

        void showProgramingSummary()
        {
            if (Session["Programing"] != null)
            {
                DataTable dt = (DataTable)Session["Programing"];
                DataRow[] result = dt.Select("NotAvailable=0");
                DataTable dt1=new DataTable();
                DataColumn dc= new DataColumn();
                dc.ColumnName="Data";
                dt1.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dt1.Columns.Add(dc);
                foreach (DataRow dr in result)
                {
                    DataRow drn = dt1.NewRow();
                    drn["Data"] = dr["Data"];
                    string str = "";
                    if (dr["Intermedite"].ToString() == "1")
                    {
                        str = "Intermedite";
                    }
                    else if (dr["Expert"].ToString() == "1")
                    {
                        str = "Expert";
                    }
                    else if (dr["Available"].ToString() == "1")
                    {
                        str = "Novice";
                    }
                    drn["Expertise"] = str;
                    dt1.Rows.Add(drn);
                }
                GD_PRO.DataSource = dt1;
                GD_PRO.DataBind();
            }
        }
        void showMathmeticSummary()
        {
            if (Session["Mathmetic"] != null)
            {
                DataTable dt = (DataTable)Session["Mathmetic"];
                DataRow[] result = dt.Select("NotAvailable=0");
                DataTable dt1 = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dt1.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dt1.Columns.Add(dc);
                foreach (DataRow dr in result)
                {
                    DataRow drn = dt1.NewRow();
                    drn["Data"] = dr["Data"];
                    string str="";
                    //Expert
                    if(dr["Intermedite"].ToString()=="1")
                    {
                        str="Intermedite";
                    }
                    else if(dr["Expert"].ToString()=="1")
                    {
                        str="Expert";
                    }
                    else if(dr["Available"].ToString()=="1")
                    {
                        str="Novice";
                    }
                    drn["Expertise"] = str;
                    dt1.Rows.Add(drn);
                }
                GD_MATH.DataSource = dt1;
                GD_MATH.DataBind();
            }
        }

        void showResearchSummary()
        {
            if (Session["ResearcExp"] != null)
            {
                DataTable dt = (DataTable)Session["ResearcExp"];
                DataRow[] result = dt.Select("NotAvailable=0");
                DataTable dt1 = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dt1.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dt1.Columns.Add(dc);
                foreach (DataRow dr in result)
                {
                    DataRow drn = dt1.NewRow();
                    drn["Data"] = dr["Data"];
                    string str = "";
                    //Expert
                    if (dr["Intermedite"].ToString() == "1")
                    {
                        str = "Intermedite";
                    }
                    else if (dr["Expert"].ToString() == "1")
                    {
                        str = "Expert";
                    }
                    else if (dr["Available"].ToString() == "1")
                    {
                        str = "Novice";
                    }
                    drn["Expertise"] = str;
                    dt1.Rows.Add(drn);
                }
                GD_RESearch.DataSource = dt1;
                GD_RESearch.DataBind();
            }
        }
        //foreach (DataRow dr in dt.Rows)
        //        {
        //            if (dr["Available"].ToString() == "1")
        //            {
        //                DataRow drn = dt1.NewRow();
        //                drn["Data"] = dr["Data"];
        //            }
        //        }
        void showToolSummary()
        {
            if (Session["Tool"] != null)
            {
                DataTable dt = (DataTable)Session["Tool"];
               // DataRow[] result = dt.Select("NotAvailable==0");
                DataTable dt1 = new DataTable();
                DataColumn dc = new DataColumn();
                dc.ColumnName = "Data";
                dt1.Columns.Add(dc);
                dc = new DataColumn();
                dc.ColumnName = "Expertise";
                dt1.Columns.Add(dc);
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["NotAvailable"].ToString() == "0")
                    {
                        DataRow drn = dt1.NewRow();
                        drn["Data"] = dr["Data"];
                        string str="";
                        if (dr["Intermedite"].ToString() == "1")
                        {
                            str = "Intermedite";
                        }
                        else if (dr["Expert"].ToString() == "1")
                        {
                            str = "Expert";
                        }
                        else if (dr["Available"].ToString() == "1")
                        {
                            str = "Novice";
                        }
                        drn["Expertise"] = str;
                        dt1.Rows.Add(drn);
                    }
                }
                GD_TOOL.DataSource = dt1;
                GD_TOOL.DataBind();
            }
        }
        protected void NEXT_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Result.aspx");
        }
        protected void Pre_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tool.aspx");
        }
    }
}