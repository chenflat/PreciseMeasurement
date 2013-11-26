using System;
using System.Collections.Generic;
using System.Data;

using PM.Entity;
using PM.Data;
using PM.Common;

namespace PM.Business
{
    /// <summary>
    /// 报表设置操作类
    /// </summary>
    public class ReportSetting
    {
        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static List<ReportSettingInfo> GetReportSettingByUserId(int userid, string orgid) {
            if (userid<=0) {
                return null;
            }
            List<ReportSettingInfo> list = new List<ReportSettingInfo>();
            using (IDataReader reader = PM.Data.ReportSetting.FindReportSettingByUserId(userid,orgid)) {

                while (reader.Read()) {
                    ReportSettingInfo reportSettingInfo = PM.Data.ReportSetting.LoadReportSettingInfo(reader);
                    list.Add(reportSettingInfo);
                }
                reader.Close();
            }

            return list;
        }




    }
}
