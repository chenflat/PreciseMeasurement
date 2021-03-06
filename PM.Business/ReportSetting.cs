﻿using System;
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
            return GetReportSettingByUserId("", userid, orgid);
        }


        /// <summary>
        /// 获取指定用户的报表设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static List<ReportSettingInfo> GetReportSettingByUserId(string settingname, int userid, string orgid) {
            if (userid <= 0) {
                return null;
            }
            List<ReportSettingInfo> list = new List<ReportSettingInfo>();
            IDataReader dataReader = null;
            if (settingname == "") {
                dataReader = PM.Data.ReportSetting.FindReportSettingByUserId(userid, orgid);
            }
            else {
                dataReader = PM.Data.ReportSetting.FindReportSettingByUserId(settingname,userid, orgid);
            }
            using (IDataReader reader = dataReader) {

                while (reader.Read()) {
                    ReportSettingInfo reportSettingInfo = PM.Data.ReportSetting.LoadReportSettingInfo(reader);
                    list.Add(reportSettingInfo);
                }
                reader.Close();
            }

            return list;
        }




        /// <summary>
        /// 保存报表设置
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool SaveReportSetting(List<ReportSettingInfo> list) {

            //获取用户ID
            int userid = 0;
            string orgid = "",settingname = "";

            if (list.Count > 0) {
                userid = list[0].UserId;
                orgid = list[0].Orgid;
                settingname = list[0].SettingName;
            }
            //查找设置，判断是否存在，如果已经存在则删除该设置。
           IDataReader reader = PM.Data.ReportSetting.FindReportSettingByUserId(settingname, userid, orgid);
           if (reader.Read()) {
               PM.Data.ReportSetting.DeleteReportSettingByUserId(settingname, userid, orgid);
           }

            //保存报表设置
            bool ret = true;
            foreach (var item in list) {
                ret = PM.Data.ReportSetting.CreateReportSetting(item);
            }
            return ret;
        }


    }
}
