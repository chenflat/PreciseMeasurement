using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using PM.Entity;

namespace PM.Web.analysis
{
    /// <summary>
    /// HandlerAnalyzeSetting 的摘要说明
    /// </summary>
    public class HandlerAnalyzeSetting : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";


            var data = context.Request;
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            var javaScriptSerializer = new JavaScriptSerializer();

            var List = javaScriptSerializer.Deserialize<List<AnalyzeSettingInfo>>(stream);

            string m_pointnum = context.Request["settings"];


            context.Response.Write("");
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