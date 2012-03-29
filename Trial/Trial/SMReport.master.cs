using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trial
{
    public partial class SMReport : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setEmployeeNo()
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMViewEmployee.aspx", false);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMViewLocation.aspx", false);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMViewInventory.aspx", false);
        }
    }
}