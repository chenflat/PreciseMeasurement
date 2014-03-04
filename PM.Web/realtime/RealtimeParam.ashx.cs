using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;

using PM.Common;
using System.Text;
using System.Web.Script.Serialization;
using PM.Entity;
using System.Text.RegularExpressions;

namespace PM.Web.realtime
{
    /// <summary>
    /// RealtimeParam 的摘要说明
    /// </summary>
    public class RealtimeParam : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string pointnum = context.Request["pointnum"];
            string startdate = context.Request["startdate"];
            string enddate = context.Request["enddate"];
            string type = context.Request["type"];
            int pageindex = Utils.StrToInt(context.Request["pageindex"], 1);

            if (startdate == null || startdate == "")
                startdate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss");
            if (enddate == null || enddate == "")
                enddate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            if (type == null || type == "")
                type = "MINUTE";


            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";
            if (type == "MINUTE")
            {
                Pagination<MeasurementInfo> pagination = Business.Measurement.GetMinuteMeasurementByPointnum(pointnum, startdate, enddate, type, pageindex, 12);
                result = javaScriptSerializer.Serialize(pagination);
            }
            else
            {
                Pagination<MeasurementStatInfo> pagination = Business.Measurement.GetMeasurementByPointnum(pointnum, startdate, enddate,"", type,"", pageindex, 12);
                result = javaScriptSerializer.Serialize(pagination);

                result = Regex.Replace(result, @"\""\\/Date\((\d+)\)\\/\""", "$1");
             
            }
            context.Response.Write(result);
            

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }



    }
}