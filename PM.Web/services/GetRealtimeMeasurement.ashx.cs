using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PM.Entity;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using PM.Common;


using ShareData;

namespace PM.Web.services
{
    /// <summary>
    /// 获取实时计量数据
    /// </summary>
    public class GetRealtimeMeasurement : IHttpHandler
    {
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string devicenum = context.Request["devicenum"];

            Share share = new Share();
            devvalue realvalue = share.GetRealData(devicenum);

            //序列化数据
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(realvalue);
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