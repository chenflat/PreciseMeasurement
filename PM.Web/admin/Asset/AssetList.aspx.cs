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

namespace PM.Web.admin.Asset {

    /// <summary>
    /// 资产列表
    /// </summary>
    public partial class AssetList : BasePage {

        protected void Page_Load(object sender, EventArgs e) {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack) {
                BindData();
            }
        }

        private void btnExport_Click(object sender, EventArgs e) {
            DataTable assetDT = GetAssetData();
            string fileName = "资产_" + DateTime.Now.ToString("yyyyMMdd");
            ExcelHelper.CreateExcel(assetDT, fileName);
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData() {

            DataTable assetDT = GetAssetData();
            rptAssets.DataSource = assetDT;
            rptAssets.DataBind();
        }


        /// <summary>
        /// 获取资产数据
        /// </summary>
        /// <returns></returns>
        private DataTable GetAssetData() {

            string condition = "";
            if (txtKeyword.Text.Trim() != "") {
                condition += string.Format(" and {0} like '%{1}%'", ddlFields.SelectedValue, txtKeyword.Text.Trim());
            }
            if (ddlSpecclass.SelectedValue != "") {
                condition += string.Format(" and SPECCLASS='{0}'", ddlSpecclass.SelectedValue);
            }

            DataTable dt = PM.Data.Asset.FindAssetByCondition(condition);
            if (dt.Rows.Count == 0) {
                dt.Rows.Add();
            }
            return dt;
        }
    }
}