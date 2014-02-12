using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Config {
   public  class SystemConfigs {


       /// <summary>
       /// 获取配置类实例
       /// </summary>
       /// <returns></returns>
       public static SystemInfo GetConfig() {
           return SystemConfigFileManager.LoadConfig();
       }

       /// <summary>
       /// 保存配置类实例
       /// </summary>
       /// <returns></returns>
       public static bool SaveConfig(SystemInfo systemInfo) {
           SystemConfigFileManager fhcfm = new SystemConfigFileManager();
           SystemConfigFileManager.ConfigInfo = systemInfo;
           return fhcfm.SaveConfig();
       }

    }
}
