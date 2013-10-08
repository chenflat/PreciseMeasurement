using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 用户组信息
    /// </summary>
    [Serializable()]
    public class GroupInfo
    {
        private int groupid;
        private string groupname;
        private string description;

        /// <summary>
        /// 用户组ID
        /// </summary>
        public int GroupId {
            get { return groupid; }
            set { groupid = value; }
        }

        /// <summary>
        /// 用户组名称
        /// </summary>
        public string GroupName {
            get { return groupname; }
            set { groupname = value; }
        }

        /// <summary>
        /// 用户组描述
        /// </summary>
        public string Description {
            get { return description; }
            set { description = value; }
        }



    }
}
