using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using PM.Business.Pages;
using PM.Business;
using PM.Common;
using PM.Config;
using PM.Common.ExcelUtils;

namespace PM.Web.admin.measurereplace
{
    /// <summary>
    /// 换表记录列表
    /// </summary>
    public partial class list : BasePage
    {
        private int PageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnExport.Click += new EventHandler(btnExport_Click);
            btnQuery.Click += new EventHandler(btnQuery_Click);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        /// <summary>
        /// 导出换表数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = "换表信息_" + DateTime.Now.ToString("yyyyMMdd");
            DataTable table = MeasureReplace.FindMeasureReplaceTableByCondition(GetCondition());
            ExcelHelper.CreateExcel(table, fileName);
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string GetCondition() {
            string condition = "";
            if (startdate.Text.Trim().Length > 0 && Utils.IsDateString(startdate.Text.Trim()))
            {
                condition += string.Format(" and convert(varchar(10), [{0}MEASUREREPLACE].REPLACEDATE,120)>='" + startdate.Text.Trim() + "'", BaseConfigs.GetTablePrefix);
            }
            if (enddate.Text.Trim().Length > 0 && Utils.IsDateString(enddate.Text.Trim()))
            {
                condition += string.Format(" and convert(varchar(10),[{0}MEASUREREPLACE].REPLACEDATE,120)<='" + enddate.Text.Trim() + "'", BaseConfigs.GetTablePrefix);
            }
            if (pointnum.Text.Trim().Length > 0)
            {
                condition += string.Format(" and [{0}MEASUREREPLACE].POINTNUM like '%{1}%'", BaseConfigs.GetTablePrefix, pointnum.Text.Trim());
            }
            if (status.SelectedValue.Length > 0)
            {
                condition += string.Format(" and [{0}MEASUREREPLACE].STATUS='{1}'", BaseConfigs.GetTablePrefix, status.SelectedValue);
            }
            return condition;
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        private void BindData()
        {
            string condition = GetCondition();

            if (!IsPostBack) PageControl1.PageSize = gvMeasureReplace.PageSize;
            gvMeasureReplace.PageSize = PageControl1.PageSize;
            if (PageIndex != 0)
                PageControl1.CurrentPageIndex = PageIndex;
            else
                PageIndex = PageControl1.CurrentPageIndex;
            DataTable measureReplaceDT = MeasureReplace.FindMeasureReplaceTableByCondition(condition);
            PageControl1.RecordCount = MeasureReplace.MeasureReplaceCount(condition);
            PageControl1.CurrentPageIndex = gvMeasureReplace.PageIndex + 1;
            gvMeasureReplace.DataSource = measureReplaceDT;
            gvMeasureReplace.DataBind();
            PageControl1.SetPageLabel(PageControl1.CurrentPageIndex);


        }
    }
}