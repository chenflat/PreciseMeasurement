using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
using PM.Config;

namespace PM.Web.admin.users
{
    public partial class list : BasePage
    {
        private string condition = "";
        private int PageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            if (!IsPostBack)
            {
                BindDropDownList();
                BindData();
            }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 绑定DropDownList数据源
        /// </summary>
        private void BindDropDownList()
        {
            ddlOrgId.Items.Clear();
            ddlOrgId.DataTextField = "DESCRIPTION";
            ddlOrgId.DataValueField = "ORGID";
            ddlOrgId.DataSource = Business.Organizations.GetOrganizationTreeList("└");
            ddlOrgId.DataBind();
            ddlOrgId.Items.Insert(0, new ListItem(""));
        }

        private void BindData() {
            if (ddlOrgId.SelectedValue.Length > 0)
            {
                condition += string.Format(" and [{0}USERS].ORGID='{1}'",
                    BaseConfigs.GetTablePrefix, ddlOrgId.SelectedValue);
            }
            if (txtUsername.Text.Trim().Length>0)
            {
                condition += string.Format(" and [{0}USERS].USERNAME='{1}'",
                    BaseConfigs.GetTablePrefix, txtUsername.Text.Trim());
            }

            if (!IsPostBack) PageControl1.PageSize = gvUsers.PageSize;
            gvUsers.PageSize = PageControl1.PageSize;
            if (PageIndex != 0)
                PageControl1.CurrentPageIndex = PageIndex;
            else
                PageIndex = PageControl1.CurrentPageIndex;
            PageControl1.RecordCount = Business.Users.UsersCount(condition);
            PageControl1.CurrentPageIndex = gvUsers.PageIndex + 1;
            gvUsers.DataSource = Business.Users.FindUserTableByCondition(condition);
            gvUsers.DataBind();
            PageControl1.SetPageLabel(PageControl1.CurrentPageIndex);
        }
    }
}