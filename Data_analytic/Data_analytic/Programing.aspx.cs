using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Data_analytic
{
    public partial class Programing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BusinessLayer.AssociateModuleInfo m = new BusinessLayer.AssociateModuleInfo();
            DataTable dtb = m.GetProgramingAcademicAssociatedInfo();
            //if (RBT_Noexperience.Checked)
            //{
            //    dtb.Clear();
            //}
            PRO_GD.DataSource = dtb;
            PRO_GD.DataBind();
            //Session.Add("UserName", "");
           
           
        }
        
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PRO_GD.PageIndex = e.NewPageIndex;
            PRO_GD.DataBind();
            //  this.BindGrid();
        }

        protected void NEXT_Click(object sender, EventArgs e)
        {

            
        }

    }
}