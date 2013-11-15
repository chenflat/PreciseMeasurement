using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Business.Pages;
using PM.Data;

namespace PM.Web.report
{
    public partial class _default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData() {
            string m_startdate = startdate.Text.Trim();
            string m_enddate = enddate.Text.Trim();
            if (m_startdate == "") {
                m_startdate = DateTime.Now.AddDays(-8).ToString("yyyy-MM-dd");
            }
            if (m_enddate == "") {
                m_enddate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
            }

            DataTable measurements = Data.Measurement.FindMeasurementByAllPoint(m_startdate, m_enddate, "ALL", 1, 15).Tables[0];

            if (measurements.Rows.Count == 0)
            {
                measurements.Rows.Add();
               
            }
           
            gvReportMeasurement.DataSource = measurements;
            gvReportMeasurement.DataBind();
         
        }

    }
}