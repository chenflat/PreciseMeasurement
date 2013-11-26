using System;
using System.Data;
using PM.Entity;
using System.Collections.Generic;

namespace PM.Data
{
    public class ReportSetting
    {

        /// <summary>
        /// 创建报表设置
        /// </summary>
        /// <param name="reportSettingInfo"></param>
        /// <returns></returns>
        public static bool CreateReportSetting(ReportSettingInfo reportSettingInfo) { 
            return DatabaseProvider.GetInstance().CreateReportSetting(reportSettingInfo);
        }

        /// <summary>
        /// 删除指定用户的报表设置
        /// </summary>
        /// <param name="settingname">设置名称</param>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static bool DeleteReportSettingByUserId(string settingname, int userid, string orgid) {
            return DatabaseProvider.GetInstance().DeleteReportSettingByUserId(settingname, userid, orgid);
        }

        /// <summary>
        /// 删除指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static bool DeleteReportSettingByUserId(int userid, string orgid) {
            return DatabaseProvider.GetInstance().DeleteReportSettingByUserId(userid, orgid);
        }

        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static IDataReader FindReportSettingByUserId(int userid, string orgid) {
            return DatabaseProvider.GetInstance().FindReportSettingByUserId(userid, orgid);
        }

        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static IDataReader FindReportSettingByUserId(string settingname, int userid, string orgid) {
            return DatabaseProvider.GetInstance().FindReportSettingByUserId(settingname,userid, orgid);
        }

        /// <summary>
        /// 获取指定用户报表设置名称列表
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static List<String> GetReportSettingNameList(int userid, string orgid) {
            List<String> settingNameList = new List<string>();
            using (IDataReader reader =DatabaseProvider.GetInstance().GetReportSettingNameList(userid, orgid)) {
                while (reader.Read()) {
                    settingNameList.Add(reader["SETTINGNAME"].ToString());
                }
                reader.Close();
            }
             return settingNameList;
        }

        /// <summary>
        /// 返回报表设置对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ReportSettingInfo LoadReportSettingInfo(IDataReader reader) {
            ReportSettingInfo reportSettingInfo = new ReportSettingInfo();
            reportSettingInfo.Settingid = reader.GetInt32(reader.GetOrdinal("SETTINGID"));
            reportSettingInfo.SettingName = reader["SETTINGNAME"].ToString();
            reportSettingInfo.Description = reader["DESCRIPTION"].ToString();
            reportSettingInfo.Pointnum = reader["POINTNUM"].ToString();
            reportSettingInfo.IsItemFormula = reader.GetInt32(reader.GetOrdinal("ISITEMFORMULA")) == 1; ;
            reportSettingInfo.Formula = reader["FORMULA"].ToString();
            reportSettingInfo.UserId = reader.GetInt32(reader.GetOrdinal("USERID"));
            reportSettingInfo.Orgid = reader["ORGID"].ToString();

            return reportSettingInfo;

        }
    }
}
