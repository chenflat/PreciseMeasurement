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
    public partial class day : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnExport.Click += new EventHandler(btnExport_Click);
            btnDayQuery.Click += new EventHandler(btnDayQuery_Click);
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

        private void btnDayQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = "计量日报表_" + DateTime.Now.ToString("yyyyMMdd");
            DataTable table = PM.Data.Measurement.GetMeasurementReport(startdate.Text.Trim(), enddate.Text.Trim(),ddlLevel.SelectedValue, Entity.ReportType.Day);
            //ExcelHelper.CreateExcel(table, fileName);

            DateTime startDate = PM.Common.TypeConverter.ObjectToDateTime(startdate.Text.Trim());
            string title = "蒸汽日用量表";
            ExcelHelper.CreateReportExcelFile(table, "计量日报表", startDate, title,"DAY");

        }

        private void BindData() {

            gvReport.DataSource = PM.Data.Measurement.GetMeasurementReport(startdate.Text.Trim(), enddate.Text.Trim(),ddlLevel.SelectedValue, Entity.ReportType.Day);
            gvReport.DataBind();

        }

        

       
    }
}