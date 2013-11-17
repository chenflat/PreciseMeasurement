using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM.Entity;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using PM.Common;

namespace PM.Web.report
{
    /// <summary>
    /// MeasurementReport 的摘要说明
    /// </summary>
    public class MeasurementReport : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string m_startdate = context.Request["startdate"];
            string m_enddate = context.Request["enddate"];
            string m_type = context.Request["type"];
            int pageindex = Utils.StrToInt(context.Request["pageindex"], 1);

            ReportType type;

            if (m_enddate == null || m_enddate == "")
                m_enddate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

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
            if (m_type == "ALL")
            {
                Pagination<MeasurementStatInfo> pagination = Business.Measurement.GetMeasurementByAllPoint(m_startdate, m_enddate, m_type, pageindex, 12);
                result = javaScriptSerializer.Serialize(pagination);
            }
            else { 
                
                
            }         
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