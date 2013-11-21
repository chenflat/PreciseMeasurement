using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business;
using PM.Business.Pages;

namespace PM.Web.structure
{
    public partial class _default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData() {

            rptMeasurePoint.DataSource = MeasurePoint.FindMeasurePointAndLocation();
            rptMeasurePoint.DataBind();

        }

    }
}