using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.Asset {
    public partial class AssetForm : BasePage {

        private long m_assetuid = 0;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Request.QueryString["assetuid"] != null) {
                    m_assetuid = Convert.ToInt64(PMRequest.GetInt("assetuid", 0));
                    SetAssetForm();
                }
            }
        }

        private void SetAssetForm() {
            if (m_assetuid <= 0)
                return;
            AssetInfo assetInfo = PM.Data.Asset.GetAssetInfo(m_assetuid);
            txtAssetNum.Text = assetInfo.Assetnum;
            txtDescription.Text = assetInfo.Description;
        }

    }
}