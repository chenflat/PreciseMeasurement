using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using PM.Entity;

namespace PM.Web.services
{
    /// <summary>
    /// 获取测点列表
    /// </summary>
    public class GetMeasurePoints : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            //序列化对象
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            List<MeasurePointInfo> list = PM.Business.MeasurePoint.FindMeasurePointAndLocation();
            string result = javaScriptSerializer.Serialize(list);
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