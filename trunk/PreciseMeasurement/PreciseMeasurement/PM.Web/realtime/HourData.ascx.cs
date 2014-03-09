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
        private string m_startdate = "";
        private string m_enddate = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                m_startdate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
                m_enddate = DateTime.Now.ToString("yyyy-MM-dd");

                setMeasureMeasurePointInfo();
                BindDummyRow();
            }
            
        }

        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = string.Format("[{0}]{1}", MeasurePointInfo.Pointnum, MeasurePointInfo.Description);

            gvHourMeasurement.DataSource = Measurement.GetMeasurementByPointnum(MeasurePointInfo.Pointnum, m_startdate, m_enddate, "", "HOUR", "", 1, 12).List;
            gvHourMeasurement.DataBind();

        }

     

        

      
        private void BindDummyRow()
        {
            DataTable dummy = new DataTable();
            dummy.Columns.Add("POINTNUM");
            dummy.Columns.Add("LEVEL");
            dummy.Columns.Add("Starttime");
            dummy.Columns.Add("STARTVALUE");
            dummy.Columns.Add("Endtime");
            dummy.Columns.Add("LASTVALUE");
            dummy.Columns.Add("VALUE");
            dummy.Rows.Add();

            gvHourMeasurement.DataSource = dummy;
            gvHourMeasurement.DataBind();
        }
    }
}