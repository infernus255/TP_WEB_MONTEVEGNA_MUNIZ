using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FRONTEND_WEB_FORM
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnAuth_ServerClick(object sender, EventArgs e)
        {
            pnlCarga.Visible = true;
            pnlPremios.Visible = false;
        }
        protected void btnCancel_ServerClick(object sender, EventArgs e)
        {
            pnlCarga.Visible = false;
            pnlPremios.Visible = true;
        }
        protected void btnLoad_ServerClick(object sender, EventArgs e)
        {
            pnlCarga.Visible = false;
            pnlPremios.Visible = true;
        }

    }
}