using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;
using PM.Business;

namespace PM.Web.admin.measurepoints
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

        private void BindData()
        {
            rptMeasurePoint.DataSource = MeasurePoint.FindMeasurePointByCondition("");
            rptMeasurePoint.DataBind();
        }



    }
}