using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using PM.Business.Pages;
using PM.Data;
using PM.Common.ExcelUtils;

namespace PM.Web.report
{
    public partial class month : BasePage
    {
        private string m_startdate = "";
        private string m_enddate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnMonthQuery.Click += new EventHandler(btnMonthQuery_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack)
            {
                if (txtYear.Text.Trim()=="")
                {
                    txtYear.Text = DateTime.Now.Year.ToString();
                }
                BindData();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            m_startdate = txtYear.Text.Trim() + "-01-01";
            m_enddate = txtYear.Text.Trim() + "-12-31";

            string fileName = "计量月报表_" + DateTime.Now.ToString("yyyyMM");
            DataTable table = PM.Data.Measurement.GetMeasurementReport(m_startdate, m_enddate, ddlLevel.SelectedValue, Entity.ReportType.Month);


            DateTime startDate = PM.Common.TypeConverter.ObjectToDateTime(m_startdate);
            string title = "蒸汽月用量表";
            ExcelHelper.CreateReportExcelFile(table, "计量月报表", startDate, title, "MONTH");
            
          //  ExcelHelper.CreateExcel(table, fileName);
        }

        private void btnMonthQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData() {

            m_startdate = txtYear.Text.Trim() + "-01-01";
            m_enddate = txtYear.Text.Trim() + "-12-31";


            gvMonthReport.DataSource = PM.Data.Measurement.GetMeasurementReport(m_startdate, m_enddate, ddlLevel.SelectedValue, Entity.ReportType.Month);
            gvMonthReport.DataBind();

        }

        

    }
}