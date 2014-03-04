using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PM.Common;

using PM.Business.Pages;
using PM.Data;
using PM.Common.ExcelUtils;

namespace PM.Web.report
{
    public partial class week : BasePage
    {
        private string m_startdate = "";
        private string m_enddate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            btnWeekQuery.Click += new EventHandler(btnWeekQuery_Click);
            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack)
            {
                if (weekstartdate.Text.Trim()=="")
                {
                    weekstartdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                }
                BindData();
                BindDropDownList();
            }

        }

        /// <summary>
        /// 绑定DropDownList数据源
        /// </summary>
        private void BindDropDownList() {
            ddlOrgId.Items.Clear();
            ddlOrgId.DataTextField = "DESCRIPTION";
            ddlOrgId.DataValueField = "ORGID";
            ddlOrgId.DataSource = Business.Organizations.GetOrganizationTreeList("└");
            ddlOrgId.DataBind();
            ddlOrgId.Items.Insert(0, new ListItem(""));
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

            gvReport.DataSource = PM.Data.Measurement.GetMeasurementReport(m_startdate, m_enddate, ddlLevel.SelectedValue, ddlOrgId.SelectedValue, Entity.ReportType.Week);
            gvReport.DataBind();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
             m_enddate = weekstartdate.Text.Trim();
            int weeks = Utils.StrToInt(ddlWeeks.SelectedValue, 1);
            int days = weeks * 7;
            m_startdate = DateTime.Parse(m_enddate).AddDays(-days).ToString("yyyy-MM-dd");

            string fileName = "计量周报表_" + DateTime.Now.ToString("yyyyMMdd");

            DataTable table = PM.Data.Measurement.GetMeasurementReport(m_startdate, m_enddate, ddlLevel.SelectedValue,ddlOrgId.SelectedValue, Entity.ReportType.Week);
            ExcelHelper.CreateExcel(table, fileName);
        }
    }
}