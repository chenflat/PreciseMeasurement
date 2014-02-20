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
using PM.Config;

namespace PM.Web.admin.system {
    public partial class config : BasePage {
        protected void Page_Load(object sender, EventArgs e) {

            btnSave.Click += btnSave_Click;
            if (!IsPostBack) {

               SystemInfo systemInfo = SystemConfigs.GetConfig();
               if (systemInfo.SystemItemInfoCollection.Count == 0) {
                   systemInfo = SystemInfo.CreateInstance();
                   SystemConfigs.SaveConfig(systemInfo);
               }

               txtSysname.Text = systemInfo.Sysname;
               this.txtVersion.Text = systemInfo.Version;
               this.txtCopyright.Text = systemInfo.Copyright;
               this.txtSysifno.Text = systemInfo.Sysinfo;

               this.rptSystemItems.DataSource = systemInfo.SystemItemInfoCollection;
               this.rptSystemItems.DataBind();

            }
        }

        void btnSave_Click(object sender, EventArgs e) {
            SystemInfo systemInfo = SystemConfigs.GetConfig();
            systemInfo.Sysname = txtSysname.Text.Trim();
            systemInfo.Version = txtVersion.Text.Trim();
            systemInfo.Copyright = txtCopyright.Text.Trim();
            systemInfo.Sysinfo = txtSysifno.Text.Trim();

            SystemConfigs.SaveConfig(systemInfo);
            


        }
    }
}