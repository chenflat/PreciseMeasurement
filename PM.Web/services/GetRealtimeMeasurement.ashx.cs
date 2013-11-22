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

            //序列化数据
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";
            //如果设备编号不为空设置，返回指定设置的实时数据，否则返回所有计量点的实时数据
            if (devicenum!="")
            {
                Share share = new Share();
                devvalue realvalue = share.GetRealData(devicenum);
                result = javaScriptSerializer.Serialize(realvalue);
            }
            else { 
                //获取所有测点的实时数据
                List<MeasurePointInfo> points = PM.Business.MeasurePoint.FindMeasurePointAndLocation();
                List<MeasurementInfo> measurements = new List<MeasurementInfo>();
                foreach (var item in points)
                {
                    devicenum = item.Devicenum;
                    if (devicenum == "") devicenum = item.Cardnum;
                    //获取数据并写入测量值列表中
                    Share share = new Share();
                    devvalue realvalue = share.GetRealData(devicenum);

                    MeasurementInfo measurementInfo = new MeasurementInfo();
                    measurementInfo.Pointnum = item.Pointnum;
                    measurementInfo.DeviceNum = item.Cardnum;
                    measurementInfo.Description = item.Description;
                    measurementInfo.Measuretime = (realvalue.MEASURETIME=="" || realvalue.MEASURETIME==null) ? DateTime.Now : TypeConverter.ObjectToDateTime(realvalue.MEASURETIME, DateTime.Now);
                    measurementInfo.AfFlowinstant = Convert.ToDecimal(realvalue.AF_FlowInstant);
                    measurementInfo.AtFlow = Convert.ToDecimal(realvalue.AT_Flow);
                    measurementInfo.SwTemperature = Convert.ToDecimal(realvalue.SW_Temperature);
                    measurementInfo.AiDensity = Convert.ToDecimal(realvalue.AI_Density);
                    measurementInfo.SwPressure = Convert.ToDecimal(realvalue.SW_Pressure);

                    measurements.Add(measurementInfo);
                }

                result = javaScriptSerializer.Serialize(measurements);
            }
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