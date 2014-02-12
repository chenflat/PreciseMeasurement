using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PM.Config {

    [Serializable]
    public class SystemItemInfo {

        private string name;
        private string code;
        private string description;
        private string structImage;
        private string structImageWidth;
        private string structImageHeight;

        /// <summary>
        /// 系统名称
        /// </summary>
        public string Name {
            get {
                return this.name;
            }
            set {
                this.name = value;
            }
        }

        public string Code {
            get {
                return this.code;
            }
            set {
                this.code = value;
            }
        }

        /// <summary>
        /// 系统描述
        /// </summary>
        public string Description {
            get {
                return this.description;
            }
            set {

                this.description = value;
            }
            
        }

        /// <summary>
        /// 系统结构图
        /// </summary>
        public string StructImage {
            get {
                return this.structImage;
            }
            set {
                this.structImage = value;
            }
        }

        /// <summary>
        /// 系统结构图显示宽度
        /// </summary>
        public string StructImageWidth {
            get {
                return this.structImageWidth;
            }
            set {
                this.structImageWidth = value;
            }
        
        }

        /// <summary>
        /// 系统结构图显示高度
        /// </summary>
        public string StructImageHeight {
            get {
                return this.structImageHeight;
            }
            set {
                this.structImageHeight = value;
            }
        
        }


    }
}
