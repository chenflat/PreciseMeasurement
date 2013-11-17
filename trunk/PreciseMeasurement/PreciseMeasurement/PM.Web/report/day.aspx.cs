using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using PM.Business.Pages;
using PM.Data;

namespace PM.Web.report
{
    public partial class day : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (startdate.Text.Trim()=="")
                {
                    int days = DateTime.Now.Day - 1;
                    startdate.Text = DateTime.Now.AddDays(-days).ToString("yyyy-MM-dd");
                }
                if (enddate.Text.Trim()=="")
                {
                    enddate.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                }

                BindData();
            }
        }

        private void BindData() {

            gvReport.DataSource = PM.Data.Measurement.GetMeasurementReport(startdate.Text.Trim(), enddate.Text.Trim(), Entity.ReportType.Day);
            gvReport.DataBind();

        }
       
    }
}