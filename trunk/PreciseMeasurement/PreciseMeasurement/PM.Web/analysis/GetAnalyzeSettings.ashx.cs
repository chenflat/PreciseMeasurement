using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

using PM.Entity;

namespace PM.Web.analysis
{
    /// <summary>
    /// 获取分析设置
    /// </summary>
    public class GetAnalyzeSettings : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            int m_userid = PM.Common.Utils.StrToInt(context.Request["userid"].ToString(),0);
            string m_orgid = context.Request["orgid"].ToString();

            List<AnalyzeSettingInfo> list = PM.Business.AnalyzeSetting.GetUserAnalyzeSettingInfoList(m_userid, m_orgid);
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