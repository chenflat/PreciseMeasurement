using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business.Pages;

namespace PM.Web.alarm
{
    public partial class _default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (txtStartDate.Text.Trim() == "") {
                    txtStartDate.Text = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");
                }
                if (txtEndDate.Text.Trim()=="")
                {
                    txtEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }

                BindData();
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData() { 
        
            string m_startdate = txtStartDate.Text.Trim();
            string m_enddate = txtEndDate.Text.Trim();

            int m_status = Utils.StrToInt(ddlStatus.SelectedValue,0);
            gvAlarmData.DataSource = PM.Data.Alarmlog.FindAlarmlogInfo(m_startdate, m_enddate, 0, orgid, 1, 15).Tables[0];
            gvAlarmData.DataBind();

        }
    }
}