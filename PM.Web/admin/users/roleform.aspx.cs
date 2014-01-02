using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Business.Pages;
using PM.Entity;

namespace PM.Web.admin.users {

    public partial class roleform : BasePage {

        private int groupId = 0;

        protected void Page_Load(object sender, EventArgs e) {
            btnSave.Click += new EventHandler(btnSave_Click);
            if (!IsPostBack) {
                groupId = PMRequest.GetInt("groupid",0);
                SetGroupInfo();
            }
        }

        private void SetGroupInfo() {
            if (groupId <= 0)
                return;
            GroupInfo groupInfo = PM.Data.UserGroup.GetGroupInfo(groupId);
            txtGroupName.Text = groupInfo.GroupName;
            txtDescription.Text = groupInfo.Description;
            hdnGroupId.Value = groupInfo.GroupId.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (Page.IsValid) {
                bool isnew = (hdnGroupId.Value == "" || hdnGroupId.Value == "0");
                GroupInfo groupInfo = new GroupInfo();
                groupInfo.GroupName = txtGroupName.Text.Trim();
                groupInfo.Description = txtDescription.Text.Trim();
                if (isnew) {
                    PM.Data.UserGroup.CreateUserGroup(groupInfo);
                }
                else {
                    groupInfo.GroupId = Utils.StrToInt(hdnGroupId.Value, 0);
                    PM.Data.UserGroup.UpdateUserGroup(groupInfo);
                }

            }
        }
    }
}