using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.Meter {

    /// <summary>
    /// 计量器组
    /// </summary>
    public partial class MeterGroupList : BasePage {

        protected void Page_Load(object sender, EventArgs e) {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack) {
                BindData();
            }
        }

        private void btnExport_Click(object sender, EventArgs e) {
           
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            BindData();
        }

        private void BindData() {
            string condition = "";
            if (txtKeyword.Text.Trim()!="") {
                condition = string.Format(" and {0} like '%{1}%'", ddlFields.SelectedValue, txtKeyword.Text.Trim());
            }
            DataTable dt = new DataTable();
            if (dt.Rows.Count == 0) {
                dt.Columns.Add("GROUPNAME");
                dt.Columns.Add("DESCRIPTION");
                dt.Rows.Add();
                dt.NewRow();
            }
            rptMeterGroup.DataSource = dt;
            rptMeterGroup.DataBind();
        }
    }
}