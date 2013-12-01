using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
using System.Web.Script.Serialization;

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

        protected void Button4_Click(object sender, EventArgs e) {
           // RealtimeData.LoadDll();

           // object share = PM.Business.RealtimeDataProvider.GetShareInstance();
            //share.GetRealData("");

            ltMessage.Text = "";

            object data = RealtimeData.GetRealtimeData("13912345670");
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string ret = javaScriptSerializer.Serialize(data);
            Console.Write(ret);

            ltMessage.Text = ret;


            object data1 = RealtimeData.GetRealtimeData("13912095330");

            string ret1 = javaScriptSerializer.Serialize(data1);
            Console.Write(ret1);
            ltMessage.Text += ret1;
        }
    }
}