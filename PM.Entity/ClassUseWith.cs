using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity {

    /// <summary>
    /// 分类结构使用的对象
    /// </summary>
    public class ClassUseWith {

        private long classusewithid;
        private string classstructureid;
        private string description;
        private string objectname;
        private string objectvalue;

        public long ClassUseWithId {
            get { return classusewithid; }
            set { classusewithid = value; }
        }

        public string Classstructureid {
            get { return classstructureid; }
            set { classstructureid = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }
        public string ObjectName {
            get { return objectname; }
            set { objectname = value; }
        }
        public string ObjectValue {
            get { return objectvalue; }
            set { objectvalue = value; }
        }


    }
}
