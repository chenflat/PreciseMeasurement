using System;

namespace PM.Entity
{
    /// <summary>
    /// 报表设置信息
    /// </summary>
    public class ReportSettingInfo
    {
         private int settingid;

        public int Settingid
        {
            get { return settingid; }
            set { settingid = value; }
        }
        private int userId = 0;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private string orgid = "";

        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }
        private string settingName = "";

        public string SettingName
        {
            get { return settingName; }
            set { settingName = value; }
        }
        private string description = "";

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private bool isItemFormula = false;

        public bool IsItemFormula
        {
            get { return isItemFormula; }
            set { isItemFormula = value; }
        }
        private string pointnum = "";

        public string Pointnum
        {
            get { return pointnum; }
            set { pointnum = value; }
        }
        private string formula = "";

        public string Formula
        {
            get { return formula; }
            set { formula = value; }
        }




    }
}
