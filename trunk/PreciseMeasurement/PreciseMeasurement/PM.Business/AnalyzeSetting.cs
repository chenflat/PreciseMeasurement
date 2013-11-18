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
        public string GetUserMeasureUnit(int userid,int orgid) {
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
        public string GetUserMeasurePoint(int userid, int orgid)
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
        public List<AnalyzeSettingInfo> GetUserAnalyzeSettingInfoList(int userid, int orgid)
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

    }
}
