﻿using System;
using System.Collections.Generic;
using System.Web;
using PM.Entity;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using PM.Common;
using System.Reflection;


namespace PM.Web.services {
    /// <summary>
    /// 获取实时计量数据
    /// </summary>
    public class GetRealtimeMeasurement : IHttpHandler {
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "text/xml";
            context.Response.Charset = "UTF-8";

            string devicenum = context.Request["devicenum"];

            //序列化数据
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = "";
            //如果设备编号不为空设置，返回指定设置的实时数据，否则返回所有计量点的实时数据
            if (devicenum != "") {
                object data = PM.Business.RealtimeData.GetRealtimeData(devicenum);
                result = javaScriptSerializer.Serialize(data);
            }
            else {
                //获取所有测点的实时数据
                List<MeasurePointInfo> points = PM.Business.MeasurePoint.FindMeasurePointAndLocation();
                List<MeasurementInfo> measurements = new List<MeasurementInfo>();
                foreach (var item in points) {
                    devicenum = item.Devicenum;
                    if (devicenum == "") devicenum = item.Cardnum;
                    //获取数据并写入测量值列表中

                    MeasurementInfo measurementInfo = new MeasurementInfo();
                    measurementInfo.Pointnum = item.Pointnum;
                    measurementInfo.DeviceNum = item.Cardnum;
                    measurementInfo.Description = item.Description;


                    try {
                        object obj = PM.Business.RealtimeData.GetRealtimeData(devicenum);
                        Type type = PM.Business.RealtimeDataProvider.GetDevvalueType();

                        object time = type.GetField("MEASURETIME").GetValue(obj);
                        measurementInfo.Measuretime = (time == null) ? DateTime.Now : TypeConverter.ObjectToDateTime(time, DateTime.Now);

                        object afFlowinstant = type.GetField("AF_FlowInstant").GetValue(obj);
                        measurementInfo.AfFlowinstant = afFlowinstant == null ? 0 : Convert.ToDecimal(afFlowinstant);

                        object atFlow = type.GetField("AT_Flow").GetValue(obj);
                        measurementInfo.AtFlow = (atFlow == null) ? 0 : Convert.ToDecimal(atFlow);

                        object swTemperature = type.GetField("SW_Temperature").GetValue(obj);
                        measurementInfo.SwTemperature = (swTemperature == null) ? 0 : Convert.ToDecimal(swTemperature);

                        object aiDensity = type.GetField("AI_Density").GetValue(obj);
                        measurementInfo.AiDensity = (aiDensity == null) ? 0 : Convert.ToDecimal(aiDensity);

                        object swPressure = type.GetField("SW_Pressure").GetValue(obj);
                        measurementInfo.SwPressure = (swPressure == null) ? 0 : Convert.ToDecimal(swPressure);

                    }
                    catch (Exception ex) {
                        //throw ex;
                    }

                    
                    measurements.Add(measurementInfo);
                }

                result = javaScriptSerializer.Serialize(measurements);
            }
            result = Regex.Replace(result, @"\""\\/Date\((\d+)\)\\/\""", "$1");
            context.Response.Write(result);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}