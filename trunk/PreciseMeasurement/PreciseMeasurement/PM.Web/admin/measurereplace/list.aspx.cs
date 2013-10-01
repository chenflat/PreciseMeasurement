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

namespace PM.Web.admin.measurereplace
{
    public partial class list : BasePage
    {
        private int PageIndex = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            btnQuery.Click += new EventHandler(btnQuery_Click);
            if (!IsPostBack)
            {
                BindData();
            }
        }

        void btnQuery_Click(object sender, EventArgs e)
        {
           
        }

        private void BindData()
        {
            string condition = "";
            if (startdate.Text.Trim().Length>0 && Utils.IsDateString(startdate.Text.Trim()))
            {
                condition += string.Format(" and convert(varchar(10), [{0}MEASUREREPLACE].REPLACEDATE,120)>='" + startdate.Text.Trim() + "'", BaseConfigs.GetTablePrefix);
            }
            if (enddate.Text.Trim().Length > 0 && Utils.IsDateString(enddate.Text.Trim()))
            {
                condition += string.Format(" and convert(varchar(10),[{0}MEASUREREPLACE].REPLACEDATE,120)<='" + enddate.Text.Trim() + "'", BaseConfigs.GetTablePrefix);
            }
            if (pointnum.Text.Trim().Length>0)
            {
                condition += string.Format(" and [{0}MEASUREREPLACE].POINTNUM like '%{1}%'", BaseConfigs.GetTablePrefix, pointnum.Text.Trim());
            }
            if (status.SelectedValue.Length>0)
            {
                condition += string.Format(" and [{0}MEASUREREPLACE].STATUS='{1}'", BaseConfigs.GetTablePrefix, status.SelectedValue);
            }

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