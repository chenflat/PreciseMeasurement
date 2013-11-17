using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PM.Common;

using PM.Business.Pages;
using PM.Data;

namespace PM.Web.report
{
    public partial class week : BasePage
    {
        private string m_startdate = "";
        private string m_enddate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnWeekQuery.Click += new EventHandler(btnWeekQuery_Click);
            if (!IsPostBack)
            {
                if (weekstartdate.Text.Trim()=="")
                {
                    weekstartdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                BindData();
            }

        }

        private void btnWeekQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }


        private void BindData() {

            m_enddate = weekstartdate.Text.Trim();
            int weeks = Utils.StrToInt(ddlWeeks.SelectedValue, 1);
            int days = weeks * 7;
            m_startdate = DateTime.Parse(m_enddate).AddDays(-days).ToString("yyyy-MM-dd");

            gvReport.DataSource = PM.Data.Measurement.GetMeasurementReport(m_startdate, m_enddate, Entity.ReportType.Week);
            gvReport.DataBind();
        }

    }
}