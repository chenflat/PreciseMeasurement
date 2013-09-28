using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
namespace PM.Web.admin.locations
{
    public partial class list : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData() {
            rptLocations.DataSource = Business.Locations.GetLocationsTreeList("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
            rptLocations.DataBind();
        }
    }
}