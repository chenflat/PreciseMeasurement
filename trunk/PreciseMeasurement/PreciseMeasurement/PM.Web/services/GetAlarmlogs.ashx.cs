using System;
using System.Collections.Generic;
using System.Web;
using PM.Entity;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using PM.Common;
using Newtonsoft.Json;


namespace PM.Web.services
{
    /// <summary>
    /// GetAlarmlogs 的摘要说明
    /// </summary>
    public class GetAlarmlogs : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string m_startdate = context.Request["startdate"];
            string m_enddate = context.Request["enddate"];
            string m_pointnum = context.Request["pointnum"] == null ? "" : context.Request["pointnum"];

            int m_status = Utils.StrToInt(context.Request["status"], -1);
            string orgid = context.Request["orgid"];
            int m_pageindex = Utils.StrToInt(context.Request["pageindex"], 1);
            int m_pagesize = Utils.StrToInt(context.Request["pagesize"], 15);


            if (m_enddate == null || m_enddate == "")
                m_enddate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");


            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";

            Pagination<AlarmlogInfo> pagination = PM.Business.Alarmlog.FindAlarmlogInfo(m_startdate, m_enddate, m_pointnum, m_status, orgid, m_pageindex, m_pagesize);
            //result = javaScriptSerializer.Serialize(pagination);

            result= JsonConvert.SerializeObject(pagination);

            //result = Regex.Replace(result, @"\""\\/Date\((\d+)\)\\/\""", "$1");
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