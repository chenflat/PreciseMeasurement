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
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string keyId = PMRequest.GetString("id");
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
                    BindDropDownList();
                    btnDelte.Visible = true;
                    btnDelte.Attributes.Add("onclick", "return confirm('删除数据不可恢复，确定要删除码');");
                    LoadUserInfo(PMRequest.GetInt("id", -1));
                }
            }

        }

        private void BindDropDownList()
        {
            ddlOrgId.DataTextField = "Description";
            ddlOrgId.DataValueField = "ORGID";
            ddlOrgId.DataSource = Business.Organizations.GetOrganizationTreeList("-");
            ddlOrgId.DataBind();
        }

        private void LoadUserInfo(int userid) { 
            
        }


        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                UserInfo userinfo = new UserInfo();
                userinfo.UserId = Utils.StrToInt(hdnUserId.Value, -1);
                userinfo.UserName = txtUserName.Text.Trim();
                userinfo.Realname = txtRealname.Text.Trim();
                userinfo.Displayname = txtDisplayname.Text.Trim();
                userinfo.Password = Utils.MD5(txtPassWord.Text.Trim());
                
            }
        }

        void btnDelte_Click(object sender, EventArgs e)
        {
            Business.Users.DeleteUserByUidlist(PMRequest.GetInt("id", -1).ToString());

            Response.Redirect("list.aspx");
        }

        #region Web 窗体设计器生成的代码

        protected override void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            btnSave.Click += new EventHandler(btnSave_Click);
            btnDelte.Click += new EventHandler(btnDelte_Click);
        }

        #endregion
    }
}