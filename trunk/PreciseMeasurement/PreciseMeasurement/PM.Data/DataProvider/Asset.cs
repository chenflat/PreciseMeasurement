using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Asset {

        /// <summary>
        /// 创建资产信息
        /// </summary>
        /// <param name="assetInfo">资产信息</param>
        /// <returns></returns>
        public static int CreateAsset(AssetInfo assetInfo) {
            return DatabaseProvider.GetInstance().CreateAsset(assetInfo);
        }

        /// <summary>
        /// 更新资产信息
        /// </summary>
        /// <param name="assetInfo"></param>
        /// <returns></returns>
        public static bool UpdateAsset(AssetInfo assetInfo) {
            return DatabaseProvider.GetInstance().UpdateAsset(assetInfo);
        }

        /// <summary>
        /// 更新资产坐标
        /// </summary>
        /// <param name="assetuid"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static int UpdateAssetCoordinates(long assetuid, string x, string y, string z) {
            return DatabaseProvider.GetInstance().UpdateAssetCoordinates(assetuid, x, y, z);
        }

        /// <summary>
        /// 删除指定的资产信息
        /// </summary>
        /// <param name="idList">资产数据主键ID列表</param>
        /// <returns></returns>
        public static int DeleteAsset(string idList) {
            return DatabaseProvider.GetInstance().DeleteAsset(idList);
        }

        /// <summary>
        /// 查找指定条件的资产信息
        /// </summary>
        /// <param name="condition">查询条件SQL</param>
        /// <returns></returns>
        public static DataTable FindAssetByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindAssetByCondition(condition);
        }

        /// <summary>
        /// 返回指定查询条件的资产信息条数
        /// </summary>
        /// <param name="condition">查询条件SQL</param>
        /// <returns></returns>
        public static int AssetCount(string condition) {
            return DatabaseProvider.GetInstance().AssetCount(condition);
        }


        public static AssetInfo GetAssetInfo(long assetuid) {
            if (assetuid <= 0)
                return new AssetInfo();
            string condition = string.Format(" and ASSETUID='{0}'",assetuid);
            DataTable result = FindAssetByCondition(condition);
            AssetInfo assetInfo = null;
            using (IDataReader reader = result.CreateDataReader()) {
                if (reader.Read()) {
                    assetInfo = LoadAssetInfo(reader);
                }
                reader.Close();
            }
            return assetInfo;
        }

        public static AssetInfo LoadAssetInfo(IDataReader reader) {
            AssetInfo assetInfo = new AssetInfo();
            assetInfo.Ancestor = reader["Ancestor"].ToString();
            assetInfo.Assetnum = reader["Assetnum"].ToString();
            assetInfo.Assettag = reader["Assettag"].ToString();
            assetInfo.Assettype = reader["Assettype"].ToString();
            assetInfo.Specclass = reader["Specclass"].ToString();
            assetInfo.Calnum = reader["Calnum"].ToString();
            assetInfo.Changeby = reader["Changeby"].ToString();
            assetInfo.Changedate = TypeConverter.ObjectToDateTime(reader["Changedate"].ToString());


            return assetInfo;
        }

    }
}
