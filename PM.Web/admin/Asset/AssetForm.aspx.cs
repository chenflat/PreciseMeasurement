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

                BindDropDownData();
                ltStatus.Text = "新增";
                if (Request.QueryString["assetuid"] != null) {
                    ltStatus.Text = "编辑";
                    m_assetuid = Convert.ToInt64(PMRequest.GetInt("assetuid", 0));
                    SetAssetForm();
                }

            }
        }

        private void BindDropDownData() {
            //子系统
            ddlSpecClass.DataTextField = "DESCRIPTION";
            ddlSpecClass.DataValueField = "VALUE";
            ddlSpecClass.DataSource = PM.Data.Pmdomain.FindPMDomainByDomainId("SUBSYS");
            ddlSpecClass.DataBind();

            //父资产
            string condition = "";
            if (m_assetuid > 0) {
                condition = " and [ASSETNUM]<>'" + txtAssetNum.Text.Trim() + "'";
            }
            ddlParent.DataTextField = "DESCRIPTION";
            ddlParent.DataValueField = "ASSETNUM";
            ddlParent.DataSource = PM.Data.Asset.FindAssetByCondition(condition);
            ddlParent.DataBind();
            ddlParent.Items.Insert(0, new ListItem("",""));

            //计量器组
            ddlGroupName.DataTextField = "DESCRIPTION";
            ddlGroupName.DataValueField = "GROUPNAME";
            ddlGroupName.DataSource = PM.Data.Metergroup.FindMetergroupByCondition("");
            ddlGroupName.DataBind();
        }

        private void SetAssetForm() {
            if (m_assetuid <= 0)
                return;
            AssetInfo assetInfo = PM.Data.Asset.GetAssetInfo(m_assetuid);
            txtAssetNum.Text = assetInfo.Assetnum;
            txtDescription.Text = assetInfo.Description;
            txtStatus.Text = assetInfo.Status;
            txtSiteId.Text = assetInfo.Siteid;
            ddlSpecClass.SelectedValue = assetInfo.Specclass;
            ddlParent.SelectedValue = assetInfo.Parent;
            chkMainthierchy.Checked = assetInfo.Mainthierchy;
            ddlGroupName.SelectedValue = assetInfo.Groupname;
            txtUsage.Text = assetInfo.Usage;
            txtX.Text = assetInfo.Ec1;
            txtY.Text = assetInfo.Ec2;
            txtZ.Text = assetInfo.Ec3;
            txtPriority.Text = assetInfo.Priority.ToString();
            txtSerialnum.Text = assetInfo.Serialnum;
            txtFailurecode.Text = assetInfo.Failurecode;
            txtVendor.Text = assetInfo.Vendor;
            txtManufacturer.Text = assetInfo.Manufacturer;
            txtInstalldate.Text = assetInfo.Installdate.ToString("yyyy-MM-dd");
            chkIsrunning.Checked = assetInfo.Isrunning;
            txtStatusDate.Text = assetInfo.Statusdate.ToString("yyyy-MM-dd HH:mm:ss");
            txtTotdowntime.Text = "";
            hdnAssetuid.Value = m_assetuid.ToString();
        }

    }
}