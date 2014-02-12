using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Config {

    [Serializable]
    public class SystemInfo : IConfigInfo {

        private bool _enable = false;
        private SystemItemInfoConllection _systemItemInfoCollection = new SystemItemInfoConllection();

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

        /// <summary>
        /// 论坛热点集合
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
            systemItemInfo.Name = "水系统";
            systemItemInfo.Code = "water";
            systemItemInfo.Description = "水系统";
            systemItemInfo.StructImage = "";
            systemItemInfo.StructImageHeight = "";
            systemItemInfo.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo);

            SystemItemInfo systemItemInfo3 = new SystemItemInfo();
            systemItemInfo.Name = "空压系统";
            systemItemInfo.Code = "air";
            systemItemInfo.Description = "空压系统";
            systemItemInfo.StructImage = "";
            systemItemInfo.StructImageHeight = "";
            systemItemInfo.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo);

            SystemItemInfo systemItemInfo4 = new SystemItemInfo();
            systemItemInfo.Name = "电系统";
            systemItemInfo.Code = "electricity";
            systemItemInfo.Description = "电系统";
            systemItemInfo.StructImage = "";
            systemItemInfo.StructImageHeight = "";
            systemItemInfo.StructImageWidth = "";
            systemInfo.SystemItemInfoCollection.Add(systemItemInfo);

            return systemInfo;
        }

    }
}
