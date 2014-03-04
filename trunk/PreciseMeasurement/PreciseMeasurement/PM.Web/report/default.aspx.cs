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
    public partial class _default : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            btnExport.Click += new EventHandler(btnExport_Click);
            if (!IsPostBack)
            {
                BindDropDownList();
                BindData();
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


        private void BindData() {

            DataTable measurements = GetDataTable(1, 15);

            if (measurements.Rows.Count == 0)
            {
                measurements.Rows.Add();
               
            }

            gvMeasurementReport.DataSource = measurements;
            gvMeasurementReport.DataBind();
         
        }


        private DataTable GetDataTable(int pageindex,int pagesize) {
            if (pageindex == 0) pageindex = 1;
            if (pagesize == 0) pagesize = 15;

            string m_startdate = startdate.Text.Trim();
            string m_enddate = enddate.Text.Trim();
            string m_level = ddlLevel.SelectedValue;
            if (m_startdate == "")
            {
                m_startdate = DateTime.Now.AddDays(-8).ToString("yyyy-MM-dd");
            }
            if (m_enddate == "")
            {
                m_enddate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") + " 23:59:59";
            }

            DataTable measurements = Data.Measurement.FindMeasurementByAllPoint(m_startdate, m_enddate,m_level, "ALL",ddlOrgId.SelectedValue, pageindex, pagesize).Tables[0];

            return measurements;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DataTable table = GetDataTable(1, 10000);
            DataTable dtMain = ExcelHelper.GetToExcelTable(table, "GetAllData", Server.MapPath("ExcelCols.xml"));
            ExcelHelper.CreateExcel(dtMain, "计量点读数");
            //ExcelHelper.GetExcelFileAndToResponse(dtMain, "计量点读数");
        }

    }
}