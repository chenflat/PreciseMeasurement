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
    /// 计量器组表单
    /// </summary>
    public partial class MeterGroupForm : BasePage {

        //计量器组ID
        private long metergroupid = 0;

        protected void Page_Load(object sender, EventArgs e) {
            btnSave.Click += new EventHandler(btnSave_Click);
            if (!IsPostBack) {
                if (Request.QueryString["metergroupid"] != null) {
                    metergroupid = long.Parse(PMRequest.GetString("metergroupid"));
                }
                SetMeterGroup();
             
            }
        }

       
        /// <summary>
        /// 设置计量器组信息
        /// </summary>
        private void SetMeterGroup() {
            DataTable dt = null;

            if (metergroupid == 0) {
                dt = new DataTable();
                dt.Rows.Add();
                return;
            }
            MetergroupInfo metergroupInfo = PM.Data.Metergroup.GetMetergroupInfo(metergroupid);
            txtGroupName.Text = metergroupInfo.Groupname;
            txtDescription.Text = metergroupInfo.Description;
            hdnMetergroupid.Value = metergroupid.ToString();

            //绑定组包含的计量器
            dt = PM.Data.Meteringroup.FindMeteringroupByGroup(metergroupInfo.Groupname);
            if (dt.Rows.Count==0) {
                dt.Rows.Add();
            }
            rptMeteringroup.DataSource = dt;
            rptMeteringroup.DataBind();

        }

        

        /// <summary>
        /// 保存计量器组信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e) {
            if (this.IsValid) { 
                
            }
        }
    }
}