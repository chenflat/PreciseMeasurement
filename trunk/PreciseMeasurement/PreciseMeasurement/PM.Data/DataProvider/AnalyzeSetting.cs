using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data
{
    public class AnalyzeSetting
    {

       
        /// <summary>
        /// 创建分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        public static bool CreateAnalyzeSettingInfo(AnalyzeSettingInfo analyzeSettingInfo) {
            return DatabaseProvider.GetInstance().CreateAnalyzeSettingInfo(analyzeSettingInfo);
        }

        /// <summary>
        /// 更新分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        public static bool UpdateAnalyzeSettingInfo(AnalyzeSettingInfo analyzeSettingInfo) {
            return DatabaseProvider.GetInstance().UpdateAnalyzeSettingInfo(analyzeSettingInfo);
        }

        /// <summary>
        /// 删除分析设置信息
        /// </summary>
        /// <param name="analyzeSettingInfo"></param>
        /// <returns></returns>
        public static bool DeleteAnalyzeSettingInfoBySettingName(SettingType type, string settingname, int userid, string orgid) {
            return DatabaseProvider.GetInstance().DeleteAnalyzeSettingInfoBySettingName(type, settingname, userid, orgid);
        }

        /// <summary>
        /// 删除用户设置
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns></returns>
        public static bool DeleteAnalyzeSettingInfoByUser(int userid, string orgid, string tablename)
        {
            return DatabaseProvider.GetInstance().DeleteAnalyzeSettingInfoByUser(userid, orgid, tablename);
        }


        /// <summary>
        /// 查找分析设置信息
        /// </summary>
        /// <param name="userid">用户ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <returns>分析设置信息</returns>
        public static IDataReader FindAnalyzeSettingInfo(int userid, string orgid,string tablename) {
            return DatabaseProvider.GetInstance().FindAnalyzeSettingInfo(userid, orgid, tablename);
        }

        /// <summary>
        /// 转换IDataReader为对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static AnalyzeSettingInfo LoadAnalyzeSettingInfo(IDataReader reader) {
            AnalyzeSettingInfo analyzeSettingInfo = new AnalyzeSettingInfo();
            analyzeSettingInfo.SettingId = reader.GetInt32(reader.GetOrdinal("SETTINGID"));
            analyzeSettingInfo.Type = (SettingType)Enum.Parse(typeof(SettingType), reader["Type"].ToString());
            analyzeSettingInfo.SettingName = reader["SETTINGNAME"].ToString();
            analyzeSettingInfo.Description = reader["DESCRIPTION"].ToString();
            analyzeSettingInfo.TableName = reader["TABLENAME"].ToString();
            analyzeSettingInfo.UserId = reader.GetInt32(reader.GetOrdinal("USERID"));
            analyzeSettingInfo.Orgid = reader["ORGID"].ToString();
            return analyzeSettingInfo;
        }



    }
}
