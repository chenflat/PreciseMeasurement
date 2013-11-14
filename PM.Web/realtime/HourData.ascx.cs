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
    public partial class HourData : RealtimeBaseControl
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
        }

      
        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("POINTNUM");
            dummy.Columns.Add("LEVEL");
            dummy.Columns.Add("MEASURETIME");
            dummy.Columns.Add("STARTVALUE");
            dummy.Columns.Add("LASTVALUE");
            dummy.Columns.Add("VALUE");
            dummy.Rows.Add();

            gvHourMeasurement.DataSource = dummy;
            gvHourMeasurement.DataBind();
        }
    }
}