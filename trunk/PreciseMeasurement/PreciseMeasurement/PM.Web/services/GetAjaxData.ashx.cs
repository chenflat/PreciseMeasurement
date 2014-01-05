﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Reflection;
using PM.Entity;
using PM.Business;
using PM.Data;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using log4net;

namespace PM.Web.services {
    /// <summary>
    /// 获取AJAX数据
    /// </summary>
    public class GetAjaxData : IHttpHandler {

        private static readonly ILog log = LogManager.GetLogger(typeof(GetAjaxData));


        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context) {

            string strReturn = "";
            if ((context.Request["funname"] != null) && (context.Request["funname"].Trim() != "")) {
                string name = context.Request["funname"].Trim();
                strReturn = base.GetType().InvokeMember(name, BindingFlags.InvokeMethod, null, Activator.CreateInstance(base.GetType()), new object[] { context }).ToString();
            }
            this.OutputString(context, strReturn);
        }

        /// <summary>
        /// 获取测试点列表
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetMeasurePointList(HttpContext context) {

            string ret = "";

            try {
                //计量点编号
                string pointnum = context.Request["pointnum"] == null ? "" : context.Request["pointnum"].Trim();
                //计量点类型
                string type = context.Request["type"] == null ? "" : context.Request["type"].Trim();

                //载体
                string carrier = context.Request["carrier"] == null ? "" : context.Request["carrier"].Trim();

                //组织机构
                string orgid = context.Request["orgid"] == null ? "" : context.Request["orgid"].Trim();
                //地点ID
                string siteid = context.Request["siteid"] == null ? "" : context.Request["siteid"].Trim();

                List<MeasurePointInfo> list = Business.MeasurePoint.GetMeasurePointByType(carrier, pointnum, orgid, siteid);

                ret = JsonConvert.SerializeObject(list);

            } catch (Exception ex) {
                throw ex;
            }
            return ret;   
        }

        /// <summary>
        /// 获取实时测量值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetRealtimeMeasureValue(HttpContext context) {
            string ret = "";
            try {
                //计量点载体名称
                string carrier = context.Request["carrier"] == null ? "" : context.Request["carrier"].Trim();
                string pointnum = context.Request["pointnum"] == null ? "" : context.Request["pointnum"].Trim();
                if (carrier != "") {

                    List<MeasurementInfo> list = PM.Data.Measurement.GetLastMeasureValueList(carrier);
                    ret = JsonConvert.SerializeObject(list);

                } else if (pointnum!="") {

                    MeasurementInfo measurementInfo = PM.Data.Measurement.GetLastMeasurement(pointnum);
                    ret = JsonConvert.SerializeObject(measurementInfo);

                }
            }
            catch (Exception ex)  {
                 log.Error(ex);
                throw ex;
               
            }

            return ret;
        }


        /// <summary>
        /// 获取设置实时值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetAsssetRealtimeMeasureValue(HttpContext context) {

            string ret = "";

            try {

                //计量点载体名称
                string specclass = context.Request["specclass"] == null ? "" : context.Request["specclass"].Trim();
                string specsubclass = context.Request["specclass"] == null ? "" : context.Request["specsubclass"].Trim();
                string assetnum = context.Request["assetnum"] == null ? "" : context.Request["assetnum"].Trim();
                List<AssetMeasurementInfo> list = PM.Data.Asset.GetAssetMeasurementValue(specclass, specsubclass, assetnum);

                ret = JsonConvert.SerializeObject(list);
            } catch (Exception ex) {
                log.Error(ex);
                throw ex;

            }

            return ret;
        }

        /// <summary>
        /// 获取分析设置
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetAnalyzeSettings(HttpContext context) {

            int m_userid = PM.Common.Utils.StrToInt(context.Request["userid"].ToString(), 0);
            string m_orgid = context.Request["orgid"].ToString();
            string m_tablename = context.Request["tablename"]==null ? "" : context.Request["tablename"].ToString();

            List<AnalyzeSettingInfo> list = PM.Business.AnalyzeSetting.GetUserAnalyzeSettingInfoList(m_userid, m_orgid, m_tablename);

            string result = JsonConvert.SerializeObject(list);

            return result;
        }

        /// <summary>
        /// 获取资产计量器
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetAssetmeters(HttpContext context) {
            string result = "";
            int assetuid = PM.Common.Utils.StrToInt(context.Request["assetuid"].ToString(), 0);

            string assetnum = PM.Data.Asset.GetAssetInfo(assetuid).Assetnum;
            List<AssetmeterInfo> list = PM.Data.Assetmeter.GetAssetmeterByAssetnum(assetnum);
            
            result = JsonConvert.SerializeObject(list);

            return result;
        }

        /// <summary>
        /// 获取报表设置
        /// </summary>
        /// <returns></returns>
        public string GetReportSetting(HttpContext context) {

            int m_userid = PM.Common.Utils.StrToInt(context.Request["userid"].ToString(), 0);
            string m_orgid = context.Request["orgid"].ToString();
            string m_settingname = context.Request["settingname"].ToString();

            List<ReportSettingInfo> list = PM.Business.ReportSetting.GetReportSettingByUserId(m_settingname, m_userid, m_orgid);
            string result = JsonConvert.SerializeObject(list);

            return result;

        }

        /// <summary>
        /// 获取计量参量信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetMeasurePointParam(HttpContext context) {
            int m_measurepointparamuid = PM.Common.Utils.StrToInt(context.Request["measurepointparamuid"].ToString(), 0);
           MeasurePointParamInfo paramInfo = PM.Data.MeasurePoint.GetMeasurePointParamInfo(m_measurepointparamuid);
           string result = JsonConvert.SerializeObject(paramInfo);
           return result;
        }



        private void OutputString(HttpContext context, string strReturn) {
            try {
                try {
                    context.Response.Clear();
                    context.Response.Charset = "UTF-8";
                    context.Response.ContentEncoding = Encoding.UTF8;
                    context.Response.Expires = 0;
                    context.Response.Write(strReturn);
                    context.Response.End();
                } catch (Exception exception) {
                    throw exception;
                }
            } finally {
            }
        }


        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}