using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

using System.Web.Services;
namespace PM.Web.steamtrap
{
    public partial class _default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                BindData();
            }
        }

        private void BindData() {
            string condition = " AND SPECCLASS='STEAM' AND CLASSSTRUCTUREID='P010101'";
            DataTable assets = PM.Data.Asset.FindAssetByCondition(condition);
            rptAsset.DataSource = assets;
            rptAsset.DataBind();
        }
    }
}