using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Config {

    [Serializable]
    public class SystemInfo : IConfigInfo {

        private bool _enable = false;
        private SystemItemInfoConllection _systemItemInfoCollection = new SystemItemInfoConllection();
        private string _sysname = "";
        private string _version = "";
        private string _copyright = "";
        private string _sysinfo = "";

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enable {
            get {
                return _enable;
            }
            set {
                _enable = value;
            }
        }

        public string Sysname {
            get {
                return this._sysname;
            }
            set {
                this._sysname = value;
            }
        }

        /// <summary>
        /// 版本
        /// </summary>
        public string Version {
            get {
                return _version;            
            }
            set {
                _version = value;
            }
        }

        /// <summary>
        /// 版权
        /// </summary>
        public string Copyright {
            get {
                return _copyright;
            }
            set {
                _copyright = value;
            }
        }

        public string Sysinfo {
            get {
                return this._sysinfo;
            }
            set {
                this._sysinfo = value;
                
            }
        }

        /// <summary>
        /// 子系统集合
        /// </summary>
        public SystemItemInfoConllection SystemItemInfoCollection {
            get {
                return _systemItemInfoCollection;
            }
            set {
                _systemItemInfoCollection = value;
            }
        }

        public static SystemInfo CreateInstance() {
            SystemInfo systemInfo = new SystemInfo();
            systemInfo.Enable = true;

            SystemItemInfo systemItemInfo = new SystemItemInfo();
            systemItemInfo.Name = "蒸汽系统";
            systemItemInfo.Code = "steam";
            systemItemInfo.Description = "蒸汽系统";
            systemItemInfo.StructImage = "";
            systemItemInfo.StructImageHeight = "";
            systemItemInfo.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo);

            SystemItemInfo systemItemInfo2 = new SystemItemInfo();
            systemItemInfo2.Name = "水系统";
            systemItemInfo2.Code = "water";
            systemItemInfo2.Description = "水系统";
            systemItemInfo2.StructImage = "";
            systemItemInfo2.StructImageHeight = "";
            systemItemInfo2.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo2);

            SystemItemInfo systemItemInfo3 = new SystemItemInfo();
            systemItemInfo3.Name = "空压系统";
            systemItemInfo3.Code = "air";
            systemItemInfo3.Description = "空压系统";
            systemItemInfo3.StructImage = "";
            systemItemInfo3.StructImageHeight = "";
            systemItemInfo3.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo3);

            SystemItemInfo systemItemInfo4 = new SystemItemInfo();
            systemItemInfo4.Name = "电系统";
            systemItemInfo4.Code = "electricity";
            systemItemInfo4.Description = "电系统";
            systemItemInfo4.StructImage = "";
            systemItemInfo4.StructImageHeight = "";
            systemItemInfo4.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo4);

            return systemInfo;
        }

    }
}
