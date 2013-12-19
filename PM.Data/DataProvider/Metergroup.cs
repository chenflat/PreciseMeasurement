using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Metergroup {

        /// <summary>
        /// 创建计量器组信息
        /// </summary>
        /// <param name="metergroupInfo">计量器组对象</param>
        /// <returns></returns>
        public static int CreateMetergroup(MetergroupInfo metergroupInfo) {
            return DatabaseProvider.GetInstance().CreateMetergroup(metergroupInfo);
        }

        /// <summary>
        /// 更新计量器组信息
        /// </summary>
        /// <param name="metergroupInfo">计量器组对象</param>
        /// <returns></returns>
        public static bool UpdateMetergroup(MetergroupInfo metergroupInfo) {
            return DatabaseProvider.GetInstance().UpdateMetergroup(metergroupInfo);
        }

        /// <summary>
        /// 删除计量器组信息
        /// </summary>
        /// <param name="idList">数据ID</param>
        /// <returns></returns>
        public static int DeleteMetergroup(string idList) {
            return DatabaseProvider.GetInstance().DeleteMetergroup(idList);
        }

        /// <summary>
        /// 查找计量器组信息
        /// </summary>
        /// <param name="condition">查询条件SQL,以 and 开头</param>
        /// <returns></returns>
        public static DataTable FindMetergroupByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindMetergroupByCondition(condition);
        }

        /// <summary>
        /// 获取计量器组信息
        /// </summary>
        /// <param name="metergroupid">计量器ID</param>
        /// <returns></returns>
        public static MetergroupInfo GetMetergroupInfo(long metergroupid) {
            if (metergroupid <= 0)
                return null;

            MetergroupInfo metergroupInfo = null;
            string condition = string.Format(" and METERGROUPID={0}",metergroupid);
            DataTable result = FindMetergroupByCondition(condition);
            using (IDataReader reader = result.CreateDataReader()) {
                if (reader.Read()) {
                    metergroupInfo = LoadMetergroupInfo(reader);
                    reader.Close();
                }
            }

            return metergroupInfo;
        }

        public static MetergroupInfo LoadMetergroupInfo(IDataReader reader) {

            MetergroupInfo metergroupInfo = new MetergroupInfo();

            metergroupInfo.Metergroupid = reader.GetInt64(reader.GetOrdinal("METERGROUPID"));
            metergroupInfo.Description = reader["DESCRIPTION"].ToString();
            metergroupInfo.Groupname = reader["GROUPNAME"].ToString();
            metergroupInfo.Langcode = reader["LANGCODE"].ToString();
            metergroupInfo.Hasld = reader.GetBoolean(reader.GetOrdinal("HASLD"));

            return metergroupInfo;

        }


    }
}
