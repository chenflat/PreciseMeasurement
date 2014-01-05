using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.admin.organizations
{
    /// <summary>
    /// 保存组织机构信息
    /// </summary>
    public partial class edit : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                BindDropDownList();
                string keyId = PMRequest.GetString("id");
                if (keyId == "")
                {
                    //Response.Redirect("list.aspx");
                    btnDelte.Enabled = false;
                }
                else
                {
                    LoadOrganizationInfo(PMRequest.GetInt("id", -1));
                }


            }
        }

        /// <summary>
        /// 绑定下拉框数据
        /// </summary>
        private void BindDropDownList()
        {
            ddlParent.DataTextField = "Description";
            ddlParent.DataValueField = "ORGID";
            ddlParent.DataSource = Business.Organizations.GetOrganizationTreeList("-");
            ddlParent.DataBind();
            ddlParent.Items.Insert(0, new ListItem("", ""));
        }


        public void LoadOrganizationInfo(long id)
        {
            OrganizationInfo orginfo = Organizations.GetOrganizationInfo(id);
            if (orginfo == null)
                return;
            tbOrgid.Attributes.Add("readonly", "readonly");
            tbOrgid.Text = orginfo.Orgid;
            description.Text = orginfo.Description;
            orgtype.SelectedValue = orginfo.Orgtype;
            ddlParent.SelectedValue = orginfo.Parent;
            leader.Text = orginfo.Leader;
            phone.Text = orginfo.Phone;
            address.Text = orginfo.Address;
            comments.Text = orginfo.Comments;
            hdnOrganizationid.Value = orginfo.Organizationid.ToString();

        }

        void btnSave_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                long m_organizationid = Utils.StrToInt(hdnOrganizationid.Value, 0);
                bool isnew = m_organizationid == 0;
                if (isnew && PM.Data.Organizations.GetOrganizationInfoByOrgId(tbOrgid.Text.Trim()) != null) {
                    ShowMessage(this, MsgType.DANGER, "组织机构代码已经存在");
                    return;
                }

                OrganizationInfo orgInfo = new OrganizationInfo();
                orgInfo.Organizationid = m_organizationid;
                orgInfo.Orgid = tbOrgid.Text.Trim();
                orgInfo.Description = description.Text.Trim();
                orgInfo.Orgtype = orgtype.SelectedValue;
                orgInfo.Parent = ddlParent.SelectedValue;
                orgInfo.Leader = leader.Text.Trim();
                orgInfo.Phone = phone.Text.Trim();
                orgInfo.Address = address.Text.Trim();
                orgInfo.Comments = comments.Text.Trim();
                bool isSuccess = false;
                if (isnew)
                {
                    isSuccess = Organizations.CreateOrganizationInfo(orgInfo) > 0;
                }
                else
                {
                    isSuccess = Organizations.UpdateOrganizationInfo(orgInfo) > 0;
                }

                if (isSuccess)
                {
                    PM.Business.Organizations.RemoveTreeList();
                    Response.Redirect("list.aspx");
                }
            }


        }

        void btnDelte_Click(object sender, EventArgs e)
        {
            Organizations.DeleteOrganizationInfo(PMRequest.GetInt("id", -1));
            Response.Redirect("list.aspx");
            // base.RegisterStartupScript("PAGE", "window.location.href='global_announcegrid.aspx';");

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