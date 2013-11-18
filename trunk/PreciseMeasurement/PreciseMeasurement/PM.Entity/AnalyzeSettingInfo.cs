using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 设置类型
    /// </summary>
    public enum SettingType {
        MEASUREUNIT, MEASUREPOINT
    }

    /// <summary>
    /// 分析设置
    /// </summary>
    [Serializable()]
    public class AnalyzeSettingInfo
    {
        private int m_settingid;
        private SettingType m_type;
        private string m_settingname;
        private string m_description;
        private string m_tablename;
        private int m_userid;
        private int m_orgid;

        public int SettingId {
            get { return m_settingid; }
            set { m_settingid = value; }
        }

        /// <summary>
        /// 设置类型 
        /// </summary>
        public SettingType Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        /// <summary>
        /// 设置编码
        /// </summary>
        public string SettingName {
            get { return m_settingname; }
            set { m_settingname = value; }
        }

        /// <summary>
        /// 设置描述
        /// </summary>
        public string Description {
            get { return m_description; }
            set { m_description = value; }
        }
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName {
            get { return m_tablename; }
            set { m_tablename = value; }
        }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId {
            get { return m_userid; }
            set { m_userid = value; }
        }

        /// <summary>
        /// 组织ID
        /// </summary>
        public int Orgid {
            get { return m_orgid; }
            set { m_orgid = value; }
        }
    }
}
