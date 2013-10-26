using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;

using PM.Common;
using System.Text;
using System.Web.Script.Serialization;
using PM.Entity;

namespace PM.Web.realtime
{
    /// <summary>
    /// RealtimeParam 的摘要说明
    /// </summary>
    public class RealtimeParam : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string pointnum = context.Request["pointnum"];
            string startdate = context.Request["startdate"];
            string enddate = context.Request["enddate"];
            string type = context.Request["type"];
            int pageindex = Utils.StrToInt(context.Request["pageindex"], 1);


            PagerInfo pagerInfo = new PagerInfo();

            List<MeasurementInfo> list = Business.Measurement.GetMeasurementByPointnum("S1", "2013-09-07 00:00", "2013-09-07 21:00", "DAY", pageindex, 15, out pagerInfo);

            Pagination<MeasurementInfo> pagination = new Pagination<MeasurementInfo>();
            pagination.List = list;
            pagination.PagerInfo = pagerInfo;

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string strMeasurements = javaScriptSerializer.Serialize(pagination);
            context.Response.Write(strMeasurements);

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