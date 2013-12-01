using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using log4net;
using log4net.Config;

namespace PM.Business {

    public class RealtimeData {

        private static readonly ILog log = LogManager.GetLogger(typeof(RealtimeData));

        public static object GetRealtimeData(string devicenum) {
            log.Debug("GetRealtimeData - devicenum:" + devicenum);
            object data = null;
            try {
                Object share = RealtimeDataProvider.GetShareInstance();
                MethodInfo method = RealtimeDataProvider.GetShareType().GetMethod("GetRealData");
                object[] paramters = new object[] { devicenum };
                if (method != null) {
                    data = method.Invoke(share, paramters);
                }
            }
            catch (Exception ex) {
                log.Error(ex);
            }
           
            return data;
        }

    }
}
