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
        /// 更新资产坐标
        /// </summary>
        /// <param name="coordinates">坐标列表</param>
        /// <returns></returns>
        public static int UpdateAssetCoordinateList(List<AssetInfo> coordinates) {
            int count = 0;
            for (int i = 0; i < coordinates.Count; i++) {
                count += UpdateAssetCoordinates(coordinates[i].Assetuid, coordinates[i].X, coordinates[i].Y, coordinates[i].Z);
            }
            return count;
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
            assetInfo.Classstructureid = reader["Classstructureid"].ToString();
            assetInfo.Description = reader["Description"].ToString();
            assetInfo.Disabled = reader.IsDBNull(reader.GetOrdinal("Disabled")) ? false : Convert.ToBoolean(reader["Disabled"]);
            assetInfo.Externalrefid = reader["Externalrefid"].ToString();
            assetInfo.Failurecode = reader["Failurecode"].ToString();
            assetInfo.Groupname = reader["Groupname"].ToString();
            assetInfo.Haschildren = reader.IsDBNull(reader.GetOrdinal("Haschildren")) ? false : Convert.ToBoolean(reader["Haschildren"]);
            assetInfo.Hasmoredesc = reader.IsDBNull(reader.GetOrdinal("Hasmoredesc")) ? false : Convert.ToBoolean(reader["Hasmoredesc"]);
            assetInfo.Installdate = TypeConverter.ObjectToDateTime(reader["Installdate"].ToString());
            assetInfo.Isrunning = reader.IsDBNull(reader.GetOrdinal("Isrunning")) ? false : Convert.ToBoolean(reader["Isrunning"]);
            assetInfo.Langcode = reader["Langcode"].ToString();
            assetInfo.Location = reader["Location"].ToString();
            assetInfo.Mainthierchy = reader.IsDBNull(reader.GetOrdinal("Mainthierchy")) ? false : Convert.ToBoolean(reader["Mainthierchy"]);
            assetInfo.Manufacturer = reader["Manufacturer"].ToString();
            assetInfo.Moved = reader.IsDBNull(reader.GetOrdinal("Moved")) ? false : Convert.ToBoolean(reader["Moved"]);
            assetInfo.Orgid = reader["Orgid"].ToString();
            assetInfo.Ownersysid = reader["Ownersysid"].ToString();
            assetInfo.Parent = reader["Parent"].ToString();
            assetInfo.Priority = TypeConverter.ObjectToInt(reader["Priority"]);
            assetInfo.Sendersysid = reader["Sendersysid"].ToString();
            assetInfo.Serialnum = reader["Serialnum"].ToString();
            assetInfo.Shiftnum = reader["Shiftnum"].ToString();
            assetInfo.Siteid = reader["Siteid"].ToString();
            assetInfo.Sourcesysid = reader["Sourcesysid"].ToString();
            assetInfo.Status = reader["Status"].ToString();
            assetInfo.Statusdate = TypeConverter.ObjectToDateTime(reader["Statusdate"].ToString());
            assetInfo.Usage = reader["Usage"].ToString();
            assetInfo.Vendor = reader["Vendor"].ToString();
            assetInfo.Warrantyexpdate = TypeConverter.ObjectToDateTime(reader["Warrantyexpdate"].ToString());
            assetInfo.Ec1 = reader["Ec1"].ToString();
            assetInfo.Ec2 = reader["Ec2"].ToString();
            assetInfo.Ec3 = reader["Ec3"].ToString();
            assetInfo.Ec4 = reader["Ec4"].ToString();
            assetInfo.Ec5 = reader.IsDBNull(reader.GetOrdinal("Ec5")) ? 0 : Convert.ToDecimal(reader["Ec5"]);
            assetInfo.Ec6 = TypeConverter.ObjectToDateTime(reader["Ec6"].ToString());
            assetInfo.Ec7 = reader.IsDBNull(reader.GetOrdinal("Ec7")) ? 0 : Convert.ToDecimal(reader["Ec7"]);
            assetInfo.Ec8 = reader["Ec8"].ToString();
            assetInfo.Ec9 = reader["Ec9"].ToString();
            assetInfo.Ec10 = reader["Ec10"].ToString();
            assetInfo.Ec11 = reader["Ec11"].ToString();
            assetInfo.Ec12 = reader.IsDBNull(reader.GetOrdinal("Ec5")) ? 0 : Convert.ToDecimal(reader["Ec12"]);
            assetInfo.Ec13 = TypeConverter.ObjectToDateTime(reader["Ec13"].ToString());
            assetInfo.Ec14 = reader["Ec14"].ToString();
            assetInfo.Ec15 = reader.IsDBNull(reader.GetOrdinal("Ec15")) ? 0 : Convert.ToDecimal(reader["Ec15"]);

            return assetInfo;
        }

    }
}
