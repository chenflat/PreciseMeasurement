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

namespace PM.Web.admin.Class {

    /// <summary>
    /// 类别结构
    /// </summary>
    public partial class ClassStructureList : BasePage {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                BindData();
            }
        }

        /// <summary>
        /// 绑定类别结构数据
        /// </summary>
        private void BindData() {

            DataTable dt = PM.Data.Classstructure.FindClassstructureByCondition("");
            if (dt.Rows.Count == 0) {
                dt = new DataTable();
                dt.Columns.Add("CLASSIFICATIONID");
                dt.Columns.Add("Description");
                dt.Columns.Add("PARENT");
                dt.Rows.Add();
            }

            rptClassStructure.DataSource = dt;
            rptClassStructure.DataBind();
        }

    }
}