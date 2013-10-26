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
               // BindDummyRow();
            }
        }

        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = MeasurePointInfo.Description;
            hdnPointnum.Value = MeasurePointInfo.Pointnum;

            gvMeasurement.DataSource = Business.Measurement.FindMeasurementByPointnum(MeasurePointInfo.Pointnum, "2013-09-07 00:00", "2013-09-07 23:59", "DAY", 1, 15).Tables["Measurement"];
            gvMeasurement.DataBind();

        }

    }
}