using System;
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
using System.IO;
using PM.Common;
using PM.Config;

namespace PM.Web.services {
    /// <summary>
    /// PostAjaxData 的摘要说明
    /// </summary>
    public class PostAjaxData : IHttpHandler {

        public void ProcessRequest(HttpContext context) {

            string strReturn = "";

            var data = context.Request;
            var sr = new StreamReader(data.InputStream);
            var stream = sr.ReadToEnd();

            ////反序列化
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(stream);

            if (dictionary.ContainsKey("funname")) {
               string name = dictionary["funname"].ToString();
               strReturn = base.GetType().InvokeMember(name, BindingFlags.InvokeMethod, null, Activator.CreateInstance(base.GetType()), new object[] { context, dictionary }).ToString();
            }

           this.OutputString(context, strReturn);
        }


        /// <summary>
        /// 保存资产坐标
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string SaveAssetCoordinates(HttpContext context, Dictionary<string, object> dictionary) {
            string ret = "";
            if (dictionary.ContainsKey("data")) {

                List<AssetInfo> list = JsonConvert.DeserializeObject<List<AssetInfo>>(dictionary["data"].ToString());
                int count = PM.Data.Asset.UpdateAssetCoordinateList(list);
                ret = count.ToString();
            }
            return ret;

        }

        /// <summary>
        /// 删除报表设置
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string DeleteReportSetting(HttpContext context, Dictionary<string, object> dictionary) {
            bool ret = false;
            if (dictionary.ContainsKey("settingname")) {
                string settingname = dictionary["settingname"].ToString();
                int userid = Utils.StrToInt(dictionary["userid"].ToString(), 0);
                string orgid = dictionary["orgid"].ToString();
               ret = PM.Data.ReportSetting.DeleteReportSettingByUserId(settingname, userid, orgid);
            }


            return ret.ToString();
        }


        /// <summary>
        /// 保存报表设置
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string SaveReportSetting(HttpContext context, Dictionary<string, object> dictionary) {

            bool ret = false;
            if (dictionary.ContainsKey("data")) {

                List<ReportSettingInfo> list = JsonConvert.DeserializeObject<List<ReportSettingInfo>>(dictionary["data"].ToString());
                ret = PM.Business.ReportSetting.SaveReportSetting(list);
            }
            return ret.ToString();
        }

        /// <summary>
        /// 保存计量点坐标位置
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string SaveMeasurePointCoordinates(HttpContext context, Dictionary<string, object> dictionary) {
            bool ret = false;
            if (dictionary.ContainsKey("data")) {

                List<MeasurePointInfo> list = JsonConvert.DeserializeObject<List<MeasurePointInfo>>(dictionary["data"].ToString());
                ret = PM.Business.MeasurePoint.UpdateMeasurePointCoordinates(list);
            }
            return ret.ToString();
        }

        public string SaveSystemConfig(HttpContext context, Dictionary<string, object> dictionary) {

            bool ret = false;
            if (dictionary.ContainsKey("data")) {
                SystemItemInfo systemItemInfo =   JsonConvert.DeserializeObject<SystemItemInfo>(dictionary["data"].ToString());
                SystemInfo systemInfo = SystemConfigs.GetConfig();
                if (systemInfo.SystemItemInfoCollection.Contains(systemItemInfo)) {
                    systemInfo.SystemItemInfoCollection.Remove(systemItemInfo);
                }
                systemInfo.SystemItemInfoCollection.Add(systemItemInfo);
                ret = SystemConfigs.SaveConfig(systemInfo);
            }
            
            return ret.ToString();
        }


        /// <summary>
        /// 删除计量点参量
        /// </summary>
        /// <param name="context"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public string DeleteMeasurepointparam(HttpContext context, Dictionary<string, object> dictionary) {
            int count = 0;
            if (dictionary.ContainsKey("data")) {
                StringBuilder sb = new StringBuilder();
                List<MeasurePointParamInfo> list = JsonConvert.DeserializeObject<List<MeasurePointParamInfo>>(dictionary["data"].ToString());
                foreach (var item in list) {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(item.Measurepointparamuid);
                }
                count = PM.Data.MeasurePoint.DeleteMeasurePointParam(sb.ToString());
            }
            return (count > 0).ToString();
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

    public class PostData<T> {
        private string _funname;
        private List<T> _data;

        public string funname {
            get { return _funname; }
            set { _funname = value; }
        }

        public List<T> data {
            get { return _data; }
            set { _data = value; }
        }

    }

}