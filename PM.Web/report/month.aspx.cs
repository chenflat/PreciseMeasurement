using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Business.Pages;
using PM.Data;

namespace PM.Web.report
{
    public partial class month : BasePage
    {
        private string m_startdate = "";
        private string m_enddate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnMonthQuery.Click += new EventHandler(btnMonthQuery_Click);
            if (!IsPostBack)
            {
                if (txtYear.Text.Trim()=="")
                {
                    txtYear.Text = DateTime.Now.Year.ToString();
                }
                BindData();
            }
        }

        private void btnMonthQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() {

            m_startdate = txtYear.Text.Trim() + "-01-01";
            m_enddate = txtYear.Text.Trim() + "-12-31";


            gvMonthReport.DataSource = PM.Data.Measurement.GetMeasurementReport(m_startdate, m_enddate, Entity.ReportType.Month);
            gvMonthReport.DataBind();

           

        }

    }
}