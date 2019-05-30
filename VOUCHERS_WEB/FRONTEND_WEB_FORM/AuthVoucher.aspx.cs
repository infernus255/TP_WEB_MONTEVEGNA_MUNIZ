using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FRONTEND_WEB_FORM
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected  void btnAuth_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("PrizePage.aspx", true);
        }
    }
}