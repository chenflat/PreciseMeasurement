using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using ShareData;

namespace PM.Business {
    public class RealtimeDataProvider {

        private static object  _share = null;
        private static object _devvalue = null;
        private static object lockHelper = new object();
        private static Type _shareType = null;
        private static Type _devvalueType = null;
             

        private RealtimeDataProvider() { 
        
        }

        static RealtimeDataProvider()
        {
            GetProvider();
        }

        private static void GetProvider() {
            try {
                string dllPath = System.Configuration.ConfigurationManager.AppSettings["ShareDataDll"].ToString();
                Assembly assembly = Assembly.LoadFrom(dllPath);
                //迭代类型
                Type[] types = assembly.GetTypes();
                foreach (Type type in types) {
                    if (type.FullName == "ShareData.Share") {
                        _share = Activator.CreateInstance(type);
                        _shareType = type;
                    }
                    else if (type.FullName == "ShareData.devvalue") {
                        _devvalue = Activator.CreateInstance(type);
                        _devvalueType = type;
                    }
                }
            }
            catch (Exception) {

                throw;
            }
           
        }

        public static object GetShareInstance() {
            if (_share == null) {
                lock (lockHelper) {
                    if (_share == null) {
                        GetProvider();
                    }
                }
            }
            return _share;
        }

        public static object GetDevvalueInstance() {
            if (_devvalue == null) {
                lock (lockHelper) {
                    if (_devvalue == null) {
                        GetProvider();
                    }
                }
            }
            return _devvalue;
        }

        public static Type GetShareType() {
            if (_shareType == null) {
                lock (lockHelper) {
                    if (_shareType == null) {
                        GetProvider();
                    }
                }
            }
            return _shareType;
        }

        public static Type GetDevvalueType() {
            if (_devvalueType == null) {
                lock (lockHelper) {
                    if (_devvalueType == null) {
                        GetProvider();
                    }
                }
            }
            return _devvalueType;
        }


        public static void ResetRealtimeDataProvider() {
            _share = null;
            _devvalue = null;
        }

    }
}
