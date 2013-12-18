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
                BindData();
            }
        }

       
        /// <summary>
        /// 设置计量器组信息
        /// </summary>
        private void SetMeterGroup() {
            if (metergroupid == 0)
                return;

        }

        /// <summary>
        /// 绑定组包含的计量器
        /// </summary>
        private void BindData() {
            DataTable dt = new DataTable();
            if (dt.Rows.Count==0) {
                dt.Columns.Add("SEQUENCE");
                dt.Columns.Add("METERNAME");
                dt.Columns.Add("METERDESCRIPTION");
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
            
        }
    }
}