using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;

namespace PM.Web
{
    public partial class MeasureSystem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["CURRENTSYSTEM"] = "measuresystem.aspx";
        }
    }
}