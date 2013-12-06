using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace PM.Business {
    
    /// <summary>
    /// 实时数据调用
    /// 
    /// </summary>
    public class RealtimeDataInvoke {

        [DllImport("ShareData.dll")]
        public static extern IntPtr GetRealData(string userid);



    }
}
