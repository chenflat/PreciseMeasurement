using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using PM.Entity;


namespace PM.Web.services
{
    /// <summary>
    /// 保存计量点信息
    /// </summary>
    public class SaveMeasurePoint : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";


            var data = context.Request;
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            var javaScriptSerializer = new JavaScriptSerializer();
            //反序列化
            var list = javaScriptSerializer.Deserialize<List<MeasurePointInfo>>(stream);
            //保存设置
            bool ret = PM.Business.MeasurePoint.UpdateMeasurePointCoordinates(list);

            context.Response.Write(ret);
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