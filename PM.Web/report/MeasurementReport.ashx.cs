using System;
using System.Collections.Generic;
using System.Web;
using System.Data;

using PM.Entity;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using PM.Common;
using Newtonsoft.Json;

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

            string m_pointnum = context.Request["pointnum"] == null ? "" : context.Request["pointnum"];
            string m_formula = context.Request["formula"] == null ? "" : context.Request["formula"];
            string m_startdate = context.Request["startdate"];
            string m_level = context.Request["level"] == null ? "" : context.Request["level"];
            string m_enddate = context.Request["enddate"];
            string m_type = context.Request["type"];
            int pageindex = Utils.StrToInt(context.Request["pageindex"], 1);
            bool m_iscustom = context.Request["iscustom"] == null ? false : Utils.StrToBool(context.Request["iscustom"],false);

            ReportType type;

            if (m_enddate == null || m_enddate == "")
                m_enddate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            type = (ReportType)Enum.Parse(typeof(ReportType), m_type);

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";

            if (m_iscustom)
            {
                DataTable dt = Data.Measurement.GetMeasurementCustomReport(m_pointnum, m_startdate, m_enddate, type, m_formula);
                
                System.Collections.ArrayList dic = new System.Collections.ArrayList();
                foreach (DataRow dr in dt.Rows)
                {
                    System.Collections.Generic.Dictionary<string, object> drow = new System.Collections.Generic.Dictionary<string, object>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        drow.Add(dc.ColumnName, dr[dc.ColumnName]);
                    }
                    dic.Add(drow);

                }
                //result = javaScriptSerializer.Serialize(dic);
                result = JsonConvert.SerializeObject(dic); 
              
            }
            else
            {
                if (m_type == "All")
                {
                    Pagination<MeasurementStatInfo> pagination = Business.Measurement.GetMeasurementByAllPoint(m_startdate, m_enddate,m_level, m_type, pageindex, 12);
                    //result = javaScriptSerializer.Serialize(pagination);
                    result = JsonConvert.SerializeObject(pagination);
                }
                else
                {

                }
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