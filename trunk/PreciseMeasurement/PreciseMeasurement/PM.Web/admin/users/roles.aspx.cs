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

namespace PM.Web.admin.users
{
    public partial class roles : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnQuery.Click += new EventHandler(btnQuery_Click);
            if (!IsPostBack) {
                BindData();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e) {
            BindData();
        }

        

        private void BindData() {
            string condition = "";
            if (txtGroupName.Text.Trim() != "") {
                condition = string.Format(" and GROUP_NAME like '%{0}%'",txtGroupName.Text.Trim());
            }

            DataTable groupDT = PM.Data.UserGroup.FindUserGroupByCondition(condition);
            rptGroup.DataSource = groupDT;
            rptGroup.DataBind();


        }

    }
}