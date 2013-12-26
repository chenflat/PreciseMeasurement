using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using PM.Business.Pages;
using PM.Entity;
using PM.Common;


namespace PM.Web.analysis {
    public partial class streamtrap : BasePage {
        private int assetuid = 0;
        protected Dictionary<AssetInfo, List<AssetmeterInfo>> dicts = null;
        protected List<AssetmeterInfo> assetmeters = null;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                assetuid = PMRequest.GetInt("assetuid", 0);

                BindAssst();
            }
        }

        private void BindAssst() {
            string assetnum = "";
            if (assetuid > 0) {
                assetnum = PM.Data.Asset.GetAssetInfo(assetuid).Assetnum;
                assetmeters = PM.Data.Assetmeter.GetAssetmeterByAssetnum(assetnum);
            }
            dicts = new Dictionary<AssetInfo, List<AssetmeterInfo>>();
            string condition = " and SPECCLASS='STEAM' and SPECSUBCLASS='STEAMTRAP'";
            List<AssetInfo> list = PM.Data.Asset.GetAssetByCondition(condition);
            foreach (var item in list) {

              List<AssetmeterInfo> assetmeters = PM.Data.Assetmeter.GetAssetmeterByAssetnum(item.Assetnum);
              dicts.Add(item, assetmeters);
            }


            
        
        }



    }
}