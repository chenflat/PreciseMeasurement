using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using PM.Entity;
using PM.Data;
using PM.Common;
using PM.Config;


namespace PM.Business
{
    public class AnalyzeSetting
    {
        /// <summary>
        /// 获取用户参量设置数值列表，多个用逗号","分隔
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public string GetUserMeasureUnit(int userid,string orgid) {
            StringBuilder sb = new StringBuilder();
            List<AnalyzeSettingInfo> list = GetUserAnalyzeSettingInfoList(userid, orgid);
            foreach (var item in list)
            {
                if (item.Type == SettingType.MEASUREUNIT) {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(item.SettingName);
                }
                
            }
            return sb.ToString();
        }

        /// <summary>
        /// 获取用户测点设置数值列表，多个用逗号","分隔
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="orgid"></param>
        /// <returns></returns>
        public string GetUserMeasurePoint(int userid, string orgid)
        {
            StringBuilder sb = new StringBuilder();
            List<AnalyzeSettingInfo> list = GetUserAnalyzeSettingInfoList(userid, orgid);
            foreach (var item in list)
            {
                if (item.Type == SettingType.MEASUREPOINT)
                {
                    if (sb.Length > 0)
                        sb.Append(",");
                    sb.Append(item.SettingName);
                }

            }
            return sb.ToString();
        }



        /// <summary>
        /// 获取用户设置列表
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public List<AnalyzeSettingInfo> GetUserAnalyzeSettingInfoList(int userid, string orgid)
        {
            if (userid <= 0) {
                return new List<AnalyzeSettingInfo>();
            }
            List<AnalyzeSettingInfo> list = new List<AnalyzeSettingInfo>();
            using (IDataReader reader = PM.Data.AnalyzeSetting.FindAnalyzeSettingInfo(userid,orgid))
            {
                while (reader.Read())
                {
                    AnalyzeSettingInfo analyzeSettingInfo = PM.Data.AnalyzeSetting.LoadAnalyzeSettingInfo(reader);
                    list.Add(analyzeSettingInfo);
                }
                reader.Close();
            }

            return list;
        }


        /// <summary>
        /// 保存设置列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool SaveAnalyzeSettingList(List<AnalyzeSettingInfo> list)
        {
            //获取用户ID
            int userid = 0;
            string orgid = "";

            if (list.Count > 0)
            {
                userid = list[0].UserId;
                orgid = list[0].Orgid;
            }
            //删除该用户设置
            bool ret = PM.Data.AnalyzeSetting.DeleteAnalyzeSettingInfoByUser(userid, orgid);
            //重新保存设置
            foreach (var item in list)
            {
                PM.Data.AnalyzeSetting.CreateAnalyzeSettingInfo(item);
            }
            return true;
        }
    }
}
