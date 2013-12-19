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
using PM.Common.ExcelUtils;

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
            DataTable dt = GetMeterGroup();
            string fileName = "计量器组_" + DateTime.Now.ToString("yyyyMMdd");
            ExcelHelper.CreateExcel(dt, fileName);
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            BindData();
        }


        private DataTable GetMeterGroup() {
            string condition = "";
            if (txtKeyword.Text.Trim() != "") {
                condition = string.Format(" and {0} like '%{1}%'", ddlFields.SelectedValue, txtKeyword.Text.Trim());
            }
            DataTable meterGroupData = PM.Data.Metergroup.FindMetergroupByCondition(condition);
            if (meterGroupData.Rows.Count == 0) {
                meterGroupData.Rows.Add();
            }
            return meterGroupData;
        }

        private void BindData() {
            DataTable dt = GetMeterGroup();
            rptMeterGroup.DataSource = dt;
            rptMeterGroup.DataBind();
        }
    }
}