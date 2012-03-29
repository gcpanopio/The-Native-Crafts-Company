using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Trial
{
    public partial class Report : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void setEmployeeNo()
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("UMViewEmployee.aspx", false);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UMViewInventory.aspx", false);
        }
    }
}