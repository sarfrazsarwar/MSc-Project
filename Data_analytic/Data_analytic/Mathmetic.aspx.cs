using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class Mathmetic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            DataTable dt = m.GetMathmeticAcademicAssociatedInfo();
            //if (RBT_Noexperience.Checked)
            //{
            //    dt.Clear();
            //}
            MATH_GD.DataSource = dt;
            MATH_GD.DataBind();
            //Session.Add("UserName", "");
            if (Session["Mathmetic"] != null && !IsPostBack)
            {
               
                //if (Session["CHK_MATH"].ToString() == "1")
                //{
                //    CHK_MATH.Checked = true;
                //}
                //else
                //{
                //    CHK_MATH.Checked = false;
                //}
                if (Session["CHK_MATH_VALUE"].ToString() == "1")
                {
                    RBT_Noexperience.Checked = true;

                }
                if (Session["CHK_MATH_VALUE"].ToString() == "2")
                {
                    RBT_NOVOICE.Checked = true;

                }
                if (Session["CHK_MATH_VALUE"].ToString() == "3")
                {
                    RBT_Intermediate.Checked = true;

                }
                if (Session["CHK_MATH_VALUE"].ToString() == "4")
                {
                    RBT_Expert.Checked = true;

                }

                LoadSelectedState();
            }

        }
        void LoadSelectedState()
        {
            DataTable dt = (DataTable)Session["Mathmetic"];
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                GridViewRow gdrow = MATH_GD.Rows[i];
                RadioButton rbt = (RadioButton)gdrow.FindControl("RBT_AVAIABLE");
                RadioButton rbt1 = (RadioButton)gdrow.FindControl("RBT_NOTAVAIABLE");
                if (dr["Available"].ToString() == "1")
                {

                    rbt.Checked = true;
                }

                else if (dr["NotAvailable"].ToString() == "1")
                {
                    rbt1.Checked = true;
                }
                i++;
                // gdrow.
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            MATH_GD.PageIndex = e.NewPageIndex;
            MATH_GD.DataBind();
            //  this.BindGrid();
        }
        void SetMathmeticData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            dc.ColumnName = "data";

            dt.Columns.Add(dc);
            dc = new DataColumn("Available", typeof(int));
            // dc.ColumnName = "Available";

            dt.Columns.Add(dc);

            dc = new DataColumn("NotAvailable", typeof(int));
            //dc.ColumnName = "";

            dt.Columns.Add(dc);


            foreach (GridViewRow row in MATH_GD.Rows)
            {
                DataRow dr = dt.NewRow();
                //    <asp:RadioButton ID="RowSelector1" runat="server" 
                //        GroupName="SuppliersGroup"  Width="100" />
                //</ItemTemplate>r
                dr["data"] = row.Cells[0].Text;
                if (RBT_Noexperience.Checked)
                {
                    dr["NotAvailable"] = 1;
                    dr["Available"] = 0;
                }
                else
                {
                    RadioButton r = (RadioButton)row.FindControl("RBT_AVAIABLE");
                    if (r.Checked)
                        dr["Available"] = 1;

                    else
                        dr["Available"] = 0;
                    RadioButton r1 = (RadioButton)row.FindControl("RBT_NOTAVAIABLE");

                    if (r1.Checked)
                        dr["NotAvailable"] = 1;

                    else
                        dr["NotAvailable"] = 0;
                }
                dt.Rows.Add(dr);
            }
            Session["Mathmetic"] = dt;
            //if (CHK_MATH.Checked)
            //{
            //    Session["CHK_MATH"] = 1;
            //}
            //else
            //{
            //    Session["CHK_MATH"] = 0;
            //}
            if (RBT_Expert.Checked)
            {
                Session["CHK_MATH_VALUE"] = 4;
            }
            if (RBT_Intermediate.Checked)
            {
                Session["CHK_MATH_VALUE"] = 3;
            }
            if (RBT_Noexperience.Checked)
            {
                Session["CHK_MATH_VALUE"] = 1;
            }
            if (RBT_NOVOICE.Checked)
            {
                Session["CHK_MATH_VALUE"] = 2;
            }

            if (RBT_R_Expert.Checked)
            {
                Session["CHK_RE_VALUE"] = 4;
            }
            if (RBT_R_Inter.Checked)
            {
                Session["CHK_RE_VALUE"] = 3;
            }
            if (RBT_R_NOEXP.Checked)
            {
                Session["CHK_RE_VALUE"] = 1;
            }
            if (RBT_R_NOvice.Checked)
            {
                Session["CHK_RE_VALUE"] = 2;
            }
        }
        protected void NEXT_Click(object sender, EventArgs e)
        {
            SetMathmeticData();
            Response.Redirect("~/Tool.aspx");

        }
        protected void Pre_Click(object sender, EventArgs e)
        {
            SetMathmeticData();
            Response.Redirect("~/Programing.aspx");
        }
    }
}