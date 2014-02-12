using PM.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Config {
    public class SystemConfigFileManager : PM.Config.DefaultConfigFileManager {

         private static SystemInfo m_configinfo;

        private static DateTime m_fileoldchange;

        static SystemConfigFileManager()
        {
            if (!Utils.FileExists(ConfigFilePath))
                SerializationHelper.Save(SystemInfo.CreateInstance(), ConfigFilePath);

            m_fileoldchange = System.IO.File.GetLastWriteTime(ConfigFilePath);
            m_configinfo = (SystemInfo)DefaultConfigFileManager.DeserializeInfo(ConfigFilePath, typeof(SystemInfo));
        }

        public new static IConfigInfo ConfigInfo
        {
            get { return m_configinfo; }
            set {
                m_configinfo = (SystemInfo)value;
            }
        }

        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        public static string filename = null;


        /// <summary>
        /// 获取配置文件所在路径
        /// </summary>
        public new static string ConfigFilePath
        {
            get
            {
                if (filename == null)
                {
                    filename = Utils.GetMapPath(BaseConfigs.GetSystemPath + "config/systemsetting.config");
                }

                return filename;
            }
        }

        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public static SystemInfo LoadConfig()
        {
            ConfigInfo = DefaultConfigFileManager.LoadConfig(ref m_fileoldchange, ConfigFilePath, ConfigInfo);
            return ConfigInfo as SystemInfo;
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public override bool SaveConfig()
        {
            return base.SaveConfig(ConfigFilePath, ConfigInfo);
        }


    }
}
