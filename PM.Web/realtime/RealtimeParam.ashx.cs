using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Data;

using PM.Common;

namespace PM.Web.realtime
{
    /// <summary>
    /// RealtimeParam 的摘要说明
    /// </summary>
    public class RealtimeParam : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml; charset=utf-8";
            DataSet ds = Business.Measurement.FindMeasurementByPointnum("S1", "2013-09-07 00:00", "2013-09-07 21:00", "DAY", 1, 15);
            context.Response.Write(ds.GetXml());


            //  return Utils.DataTableToJSON(ds.Tables[0]).Append(Utils.DataTableToJSON(ds.Tables["Pager"])).ToString()
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