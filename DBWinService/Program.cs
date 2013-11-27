using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DBWinService {
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main() {
            #if (!DEBUG)
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] { 
				     new DataReductionService() 
                };
                ServiceBase.Run(ServicesToRun);
            #else
                DataReductionService myservice = new DataReductionService();
                myservice.OnDebug();
                 // Put a breakpoint on the following line to always catch
                // your service when it has finished its work
                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            #endif


        }
    }
}
