using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Reflection;
using PM.Entity;
using PM.Business;
using PM.Data;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace PM.Web.services {
    /// <summary>
    /// 获取AJAX数据
    /// </summary>
    public class GetAjaxData : IHttpHandler {

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
                //组织机构
                string orgid = context.Request["orgid"] == null ? "" : context.Request["orgid"].Trim();
                //地点ID
                string siteid = context.Request["siteid"] == null ? "" : context.Request["siteid"].Trim();


                //全部类型，重置为空
                if (type == "ALL") {
                    type = "";
                }

                List<MeasurePointInfo> list = Business.MeasurePoint.GetMeasurePointByType(type, pointnum, orgid, siteid);

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
               
                List<MeasurementInfo> list = PM.Data.Measurement.GetLastMeasureValueList(carrier);
                
                ret = JsonConvert.SerializeObject(list);

            }
            catch (Exception ex) {
                throw ex;
            }

            return ret;
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