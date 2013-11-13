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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string startDate = "2013-10-01 00:00:00";
            PM.Data.Measurement measurement = new Data.Measurement();
            measurement.CreateMeasurementStatData(startDate, ReportType.Hour);
        }
    }
}