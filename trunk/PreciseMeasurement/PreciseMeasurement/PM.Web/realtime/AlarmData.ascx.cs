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

namespace PM.Web.realtime
{
    public partial class AlarmData : RealtimeBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                setMeasureMeasurePointInfo();
            }
        }

        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = MeasurePointInfo.Description;

            BindData();

        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {

            string m_startdate = txtStartDate.Text.Trim();
            string m_enddate = txtEndDate.Text.Trim();

            int m_status = Utils.StrToInt(ddlStatus.SelectedValue, -1);
            DataTable dt = PM.Data.Alarmlog.FindAlarmlogInfo(m_startdate, m_enddate, "", -1, Orgid, 1, 15).Tables[0];
            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add();
            }
            gvAlarmData.DataSource = dt;
            gvAlarmData.DataBind();

        }
    }
}