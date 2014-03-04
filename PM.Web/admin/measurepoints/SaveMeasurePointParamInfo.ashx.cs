using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.IO;
using PM.Entity;
using Newtonsoft.Json;

namespace PM.Web.admin.measurepoints {
    /// <summary>
    /// SaveMeasurePointParamter 的摘要说明
    /// </summary>
    public class SaveMeasurePointParamter : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";


            var data = context.Request;
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            //反序列化
            var measurePointParamInfo = JsonConvert.DeserializeObject<MeasurePointParamInfo>(stream);


            //更新设置
            bool ret = PM.Business.MeasurePoint.UpdateMeasurePointParam(measurePointParamInfo);
            
            context.Response.Write(ret);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}