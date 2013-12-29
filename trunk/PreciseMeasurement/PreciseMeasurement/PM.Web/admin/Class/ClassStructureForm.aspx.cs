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
    /// 类别结构表单
    /// </summary>
    public partial class ClassStructureForm : BasePage {

        private long m_classstructureuid = 0;

        protected void Page_Load(object sender, EventArgs e) {

            if (!IsPostBack) {

                m_classstructureuid = PMRequest.GetInt("Classstructureuid", 0);

                BindDropDownList();

                if (m_classstructureuid > 0) {
                    SetClassStructureForm();
                }

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

        /// <summary>
        /// 设置类别结构表单
        /// </summary>
        private void SetClassStructureForm() {

            ClassstructureInfo classstructureInfo = PM.Data.Classstructure.GetClassstructureInfo(m_classstructureuid);
            if (classstructureInfo == null)
                return;
            txtClassstructureid.Text = classstructureInfo.Classstructureid;
            txtDescription.Text = classstructureInfo.Description;
            ddlOrgId.SelectedValue = classstructureInfo.Orgid;
            hdnClassstructureuid.Value = classstructureInfo.Classstructureuid.ToString();

            string condition = string.Format(" and [PARENT]='{0}'", classstructureInfo.Classstructureid);
            DataTable dtChildren = PM.Data.Classstructure.FindClassstructureByCondition(condition);
            rptChildren.DataSource = dtChildren;
            rptChildren.DataBind();

        }


    }
}