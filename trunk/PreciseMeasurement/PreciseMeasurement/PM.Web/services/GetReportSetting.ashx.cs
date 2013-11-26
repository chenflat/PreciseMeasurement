using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

using PM.Entity;

namespace PM.Web.services
{
    /// <summary>
    /// 获取报表设置
    /// </summary>
    public class GetReportSetting : IHttpHandler
    {

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            int m_userid = PM.Common.Utils.StrToInt(context.Request["userid"].ToString(), 0);
            string m_orgid = context.Request["orgid"].ToString();

            List<ReportSettingInfo> list = PM.Business.ReportSetting.GetReportSettingByUserId(m_userid, m_orgid);
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";
            result = javaScriptSerializer.Serialize(list);
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