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
                BindDropDownList();
                chkEnabled.Checked = true;
                string keyId = PMRequest.GetString("id");
                if (keyId != "" && Utils.IsNumeric(keyId))
                {
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
            ddlOrgId.DataSource = Business.Organizations.GetOrganizationTreeList("└");
            ddlOrgId.DataBind();
        }

        private void LoadUserInfo(int userid) {
            if (userid <= 0)
                return;
            UserInfo userinfo = Business.Users.GetUserInfo(userid);
            if (userinfo == null)
                return;
            hdnUserId.Value = userinfo.UserId.ToString();
            txtUserName.Text = userinfo.UserName;
            txtRealname.Text = userinfo.Realname;
            txtDisplayname.Text = userinfo.Displayname;
            ddlPasswordEncrypted.SelectedValue = userinfo.PasswordEncrypted.ToString();
            txtPassWord.Attributes.Add("value", userinfo.Password);
            txtConfirmPwd.Attributes.Add("value", userinfo.Password);
            txtReminderQueryQuestion.Text = userinfo.ReminderQueryQuestion;
            txtReminderQueryAnswer.Text = userinfo.ReminderQueryAnswer;
            txtEmailAddress.Text = userinfo.EmailAddress;
            txtWorkPhone.Text = userinfo.WorkPhone;
            txtWorkMobile.Text = userinfo.WorkMobile;
            txtPhone.Text = userinfo.Phone;
            txtMobile.Text = userinfo.Mobile;
            txtAddress.Text = userinfo.Address;
            txtWebsite.Text = userinfo.Website;
            ddlOrgId.SelectedValue = userinfo.Orgid;
            txtJobtitle.Text = userinfo.Jobtitle;
            rbSex.SelectedValue = userinfo.Sex;
            txtBirthday.Text = Utils.GetStandardDate(userinfo.Birthday.ToString());
            txtAnniversary.Text = Utils.GetStandardDate(userinfo.Anniversary.ToString());
            txtGreeting.Text = userinfo.Greeting;
            txtDigest.Text = userinfo.Digest;
            txtComments.Text = userinfo.Comments;
            chkEnabled.Checked = userinfo.Enabled;
            txtCreatedDate.Text = Utils.GetStandardDate(userinfo.CreatedDate.ToString());
            txtModifiedDate.Text = Utils.GetStandardDate(userinfo.ModifiedDate.ToString());
            txtPasswordModifiedDate.Text = Utils.GetStandardDate(userinfo.PasswordModifiedDate.ToString());
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
                userinfo.PasswordEncrypted = Utils.StrToInt(ddlPasswordEncrypted.SelectedValue,0);
                if (userinfo.UserId == -1)
                {
                    switch (userinfo.PasswordEncrypted)
                    {
                        case 1:
                            userinfo.Password = AES.Encode(txtPassWord.Text.Trim(),"CHENPING");
                            break;
                        case 2:
                            userinfo.Password = DES.Encode(txtPassWord.Text.Trim(), "CHENPING");
                            break;
                        default:
                            userinfo.Password = Utils.MD5(txtPassWord.Text.Trim());
                            break;
                    }
                }
                else {

                    UserInfo modifyUser = PM.Data.Users.GetUserInfo(userinfo.UserId);
                    if (modifyUser.Password!=Utils.MD5(txtPassWord.Text.Trim())) {
                        userinfo.Password = Utils.MD5(txtPassWord.Text.Trim());
                    } else {
                        userinfo.Password  = modifyUser.Password;
                    } 
                }
                userinfo.ReminderQueryQuestion = txtReminderQueryQuestion.Text.Trim();
                userinfo.ReminderQueryAnswer = txtReminderQueryAnswer.Text.Trim();
                userinfo.EmailAddress = txtEmailAddress.Text.Trim();
                userinfo.WorkPhone = txtWorkPhone.Text.Trim();
                userinfo.WorkMobile = txtWorkMobile.Text.Trim();
                userinfo.Phone = txtPhone.Text.Trim();
                userinfo.Mobile = txtMobile.Text.Trim();
                userinfo.Address = txtAddress.Text.Trim();
                userinfo.Website = txtWebsite.Text.Trim();
                userinfo.Orgid = ddlOrgId.SelectedValue;
                userinfo.Jobtitle = txtJobtitle.Text.Trim();
                userinfo.Sex = rbSex.SelectedValue;
                userinfo.Birthday = TypeConverter.ObjectToDateTime(txtBirthday.Text.Trim());
                userinfo.Anniversary = TypeConverter.ObjectToDateTime(txtAnniversary.Text.Trim());
                userinfo.Greeting = txtGreeting.Text.Trim();
                userinfo.Digest = txtDigest.Text.Trim();
                userinfo.Comments = txtComments.Text.Trim();
                userinfo.Enabled = chkEnabled.Checked;
                bool isSuccess = false;
                if (userinfo.UserId > 0)
                {
                    userinfo.ModifiedDate = DateTime.Now;
                    isSuccess = Business.Users.UpdateUser(userinfo);
                }
                else {
                    userinfo.CreatedDate = DateTime.Now;
                    userinfo.LastLoginDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                    userinfo.ModifiedDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                    userinfo.PasswordModifiedDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
                    isSuccess = Business.Users.CreateUser(userinfo);
                }

                if (isSuccess)
                {
                    Response.Redirect("list.aspx");
                }
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