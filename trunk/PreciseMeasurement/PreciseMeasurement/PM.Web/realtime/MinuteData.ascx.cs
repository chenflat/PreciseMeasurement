using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
using System.Data;

namespace PM.Web.realtime
{
    public partial class MinuteData : RealtimeBaseControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            btnMinuteQuery.Click += new EventHandler(btnMinuteQuery_Click);
            if (!Page.IsPostBack)
            {
                setMeasureMeasurePointInfo();
                BindDummyRow();
            }
        }



        private void btnMinuteQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = MeasurePointInfo.Description;
            hdnPointNum.Value = MeasurePointInfo.Pointnum;
         
           // gvMeasurement.DataSource = Business.Measurement.FindMeasurementByPointnum(MeasurePointInfo.Pointnum, "2013-09-07 00:00", "2013-09-07 23:59", "DAY", 1, 15).Tables["Measurement"];
          //  gvMeasurement.DataBind();

        }


        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("MEASURETIME");
            dummy.Columns.Add("SW_TEMPERATURE");
            dummy.Columns.Add("SW_PRESSURE");
            dummy.Columns.Add("AF_FLOWINSTANT");
            dummy.Columns.Add("AT_FLOW");
            dummy.Columns.Add("AI_DENSITY");
            dummy.Rows.Add();

            gvMinuteMeasurement.DataSource = dummy;
            gvMinuteMeasurement.DataBind();
        }


        /// <summary>
        /// 数据绑定
        /// </summary>
        private void BindData() {
            if (!IsPostBack) PageControl1.PageSize = gvMinuteMeasurement.PageSize;
            gvMinuteMeasurement.PageSize = PageControl1.PageSize;



            Pagination<MeasurementInfo> pagination = Business.Measurement.GetMeasurementByPointnum(hdnPointNum.Value, txtStartDate.Text.Trim(), txtEndDate.Text.Trim(), "MINUTE", PageControl1.CurrentPageIndex, PageControl1.PageSize);

            PageControl1.RecordCount = pagination.PagerInfo.RecordCount;
            gvMinuteMeasurement.PageIndex = PageControl1.CurrentPageIndex - 1;
            gvMinuteMeasurement.DataSource = pagination.List;
            gvMinuteMeasurement.DataBind();
            PageControl1.SetPageLabel(PageControl1.CurrentPageIndex);
        }


    }
}