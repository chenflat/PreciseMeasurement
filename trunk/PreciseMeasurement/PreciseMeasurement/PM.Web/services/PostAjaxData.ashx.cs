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


        public string SaveAssetCoordinates(HttpContext context, Dictionary<string, object> dictionary) {
            string ret = "";
            if (dictionary.ContainsKey("data")) {

                List<AssetInfo> list = JsonConvert.DeserializeObject<List<AssetInfo>>(dictionary["data"].ToString());
                int count = PM.Data.Asset.UpdateAssetCoordinateList(list);
                ret = count.ToString();
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