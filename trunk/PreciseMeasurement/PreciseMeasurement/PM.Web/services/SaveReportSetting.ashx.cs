using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using PM.Entity;


namespace PM.Web.services {
    /// <summary>
    /// 保存报表设置
    /// </summary>
    public class SaveReportSetting : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";


            var data = context.Request;
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            var javaScriptSerializer = new JavaScriptSerializer();
            //反序列化
            var list = javaScriptSerializer.Deserialize<List<ReportSettingInfo>>(stream);
            //保存设置
            bool ret = PM.Business.ReportSetting.SaveReportSetting(list);

           context.Response.Write(ret);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}