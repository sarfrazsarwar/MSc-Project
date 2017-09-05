using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;

namespace Data_analytic
{

    // The code is being written to implement future work (Project report - Section 5.5), proposed in project - Not completed yet

    public partial class AcademicInterests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static string[] GetCustomers(string prefix)
        {
            List<string> customers = new List<string>();
            BusinessLayer.DataServices m = new BusinessLayer.DataServices();
           DataTable dt= m.GetResearchAcademicAssociatedInfo1(prefix);
           foreach (DataRow dr in dt.Rows)
           {
               customers.Add(string.Format("{0}", dr["Sug_Word"]));
           }
            return customers.ToArray();
        }
        protected void Submit(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Maximum Five word can Enter');", true);
            if (ListBox1.Items.Count == 5)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Maximum Five word can Enter');", true);
            }
            else
            ListBox1.Items.Add(txtSearch.Text);
            txtSearch.Text = "";

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int i = ListBox1.SelectedIndex;
            if(i>=0)
            ListBox1.Items.Remove(ListBox1.Items[i]);
        }
        protected void BTN_SUB_Click(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count == 5)
            {
            }
        }
        
    }
}