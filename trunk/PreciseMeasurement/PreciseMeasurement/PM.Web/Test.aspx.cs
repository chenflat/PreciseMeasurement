using System;
using System.Collections.Generic;
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
       // private string startDate = "2013-11-17 00:00:00"; 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Measurement.CreateMeasurementStatData(ReportType.Hour);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Measurement.CreateMeasurementStatData(ReportType.Day);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Measurement.CreateMeasurementStatData(ReportType.Month);
        }
    }
}