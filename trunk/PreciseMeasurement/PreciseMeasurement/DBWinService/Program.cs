using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;

namespace DBWinService {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main() {

            try {

#if (!DEBUG)
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { 
				     new DataReductionService() 
                };
                ServiceBase.Run(ServicesToRun);
#else
                DataReductionService myservice = new DataReductionService();
                myservice.OnDebug();
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
#endif


            } catch (Exception ex) {
                EventLog.WriteEntry("Application", ex.ToString(), EventLogEntryType.Error);
            }


        }
    }
}
