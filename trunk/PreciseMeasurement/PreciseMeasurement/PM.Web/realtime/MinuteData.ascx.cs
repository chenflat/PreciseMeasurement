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
            if (!Page.IsPostBack)
            {
                setMeasureMeasurePointInfo();
                BindDummyRow();
            }
        }

        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = MeasurePointInfo.Description;
         
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
    }
}