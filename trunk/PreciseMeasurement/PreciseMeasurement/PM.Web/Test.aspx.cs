using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web
{
    public partial class Test : System.Web.UI.Page
    {
        private string startDate = "2013-09-01 00:00:00"; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            string endDate = "";
            PM.Data.Measurement measurement = new Data.Measurement();
            measurement.CreateMeasurementStatData(startDate,endDate, ReportType.Hour);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //string startDate = "2013-09-07 00:00:00";
            string endDate = "";
            PM.Data.Measurement measurement = new Data.Measurement();
            measurement.CreateMeasurementStatData(startDate, endDate, ReportType.Day);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
           // string startDate = "2013-09-01 00:00:00";
            string endDate = "";
            PM.Data.Measurement measurement = new Data.Measurement();
            measurement.CreateMeasurementStatData(startDate, endDate, ReportType.Month);
        }
    }
}