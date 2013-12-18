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

namespace PM.Web.admin.Asset {

    /// <summary>
    /// 资产列表
    /// </summary>
    public partial class AssetList : BasePage {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData() {

            DataTable dt = new DataTable();
            if (dt.Rows.Count == 0) {
                dt.Columns.Add("ASSETNUM");
                dt.Columns.Add("DESCRIPTION");
                dt.Columns.Add("PARENT");
                dt.Columns.Add("SITEID");
                dt.Columns.Add("STATUS");
                dt.Rows.Add();
            }
            rptAssets.DataSource = dt;
            rptAssets.DataBind();
        }

    }
}