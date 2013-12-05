﻿using System;
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
    public partial class list : BasePage
    {
        public List<OrganizationInfo> organizationInfoList;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // organizationInfoList = Organizations.GetOrganizationTreeList("");

                rptOrganizations.DataSource = Organizations.GetOrganizationTreeList("");
                rptOrganizations.DataBind();
            }
        }
    }
}