using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.Class {

    /// <summary>
    /// 类别结构表单
    /// </summary>
    public partial class ClassStructureForm : BasePage {

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {
                BindDropDownList();
            }

        }

        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void BindDropDownList() {
            ddlOrgId.DataTextField = "Description";
            ddlOrgId.DataValueField = "ORGID";
            ddlOrgId.DataSource = Business.Organizations.GetOrganizationTreeList("-");
            ddlOrgId.DataBind();
        }
    }
}