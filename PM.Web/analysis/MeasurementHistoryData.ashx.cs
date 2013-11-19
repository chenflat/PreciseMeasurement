using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using PM.Entity;
using System.Text.RegularExpressions;

namespace PM.Web.analysis
{
    /// <summary>
    /// MeasurementHistoryData 的摘要说明
    /// </summary>
    public class MeasurementHistoryData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string m_pointnum = context.Request["pointnum"];
            string m_startdate = context.Request["startdate"];
            string m_enddate = context.Request["enddate"];
            string m_type = context.Request["type"];
            ReportType type;

            if (m_startdate == null || m_startdate == "")
                m_startdate = DateTime.Now.AddHours(-12).ToString("yyyy-MM-dd hh:mm:ss");
            if (m_enddate == null || m_enddate == "")
                m_enddate = DateTime.Now.ToString("yyyy-MM-dd hh:00:00");

            if (m_type == "MINUTE")
            {
                type = ReportType.Minute;
            }
            else if (m_type == "HOUR")
            {
                type = ReportType.Hour;
            }
            else
            {
                type = ReportType.Minute;
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";
            List<MeasurementInfo> measurements = PM.Business.Measurement.GetMeasurementHistoryData(m_pointnum, m_startdate, m_enddate, type);
            result = javaScriptSerializer.Serialize(measurements);
            result = Regex.Replace(result, @"\""\\/Date\((\d+)\)\\/\""", "$1");
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