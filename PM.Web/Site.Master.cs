using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business;
using PM.Entity;

namespace PM.Web
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CURRENTSYSTEM"]==null) {
                Session["CURRENTSYSTEM"] = "";
            }
           

        }
    }
}
