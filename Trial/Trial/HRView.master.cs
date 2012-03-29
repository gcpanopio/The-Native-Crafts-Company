using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trial
{
    public partial class HRView : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setEmployeeNo()
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewEmployee.aspx", false);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewLocation.aspx", false);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRViewInventory.aspx", false);
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("HRCommission.aspx", false);
        }
     }
}