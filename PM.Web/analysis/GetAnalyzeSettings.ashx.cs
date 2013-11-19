using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PM.Web.analysis
{
    /// <summary>
    /// 获取分析设置
    /// </summary>
    public class GetAnalyzeSettings : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
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