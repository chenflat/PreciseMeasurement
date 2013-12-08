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
using Newtonsoft.Json;

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

            string devicenum = txtDeviceNum.Text.Trim();
            if (devicenum == "") {
                devicenum = "00000000004";
                txtDeviceNum.Text = devicenum;
            }

            ltMessage.Text = "";

            object data = RealtimeData.GetRealtimeData(devicenum);

            string ret = JsonConvert.SerializeObject(data);
            Console.Write(ret);

            ltMessage.Text += ret;

        }

        protected void Button5_Click(object sender, EventArgs e) {
          MeasurementInfo info =  Data.Measurement.GetFirstMeasurement("S3");
        }

        protected void Button6_Click(object sender, EventArgs e) {
           System.IntPtr ptr = PM.Business.RealtimeDataInvoke.GetRealData("00000000004");
        }
    }
}