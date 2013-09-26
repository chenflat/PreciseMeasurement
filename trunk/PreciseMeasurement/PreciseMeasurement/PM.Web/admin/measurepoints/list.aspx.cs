using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;
using PM.Business;
using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Web.admin.measurepoints
{
    public partial class list : BasePage
    {
        private string condition = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnQuery.Click += new EventHandler(btnQuery_Click);

            if (!IsPostBack)
            {
                BindData();
            }
        }  

        private void BindData()
        {
            rptMeasurePoint.DataSource = Business.MeasurePoint.FindMeasurePointByCondition(condition);
            rptMeasurePoint.DataBind();
        }

        void btnQuery_Click(object sender, EventArgs e)
        {

            if (ddlOrgId.SelectedValue.Length>0)
            {
                condition += string.Format(" and {0}MEASUREPOINT.ORGID='{1}'", 
                    BaseConfigs.GetTablePrefix,ddlOrgId.SelectedValue);
            }
            if (txtDescription.Text.Trim().Length>0)
            {
                condition += string.Format(" and {0}MEASUREPOINT.DESCRIPTION='{1}'",
                    BaseConfigs.GetTablePrefix, txtDescription.Text.Trim());
            }
            if (ddlCarrier.SelectedValue.Length > 0)
            {
                condition += string.Format(" and {0}MEASUREPOINT.CARRIER='{1}'",
                    BaseConfigs.GetTablePrefix, ddlCarrier.SelectedValue);
            }

            if (condition.Length>0)
            {
                BindData();
            }
        }


    }
}