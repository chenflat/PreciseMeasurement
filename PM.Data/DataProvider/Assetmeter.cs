using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using PM.Data;
using PM.Config;
using PM.Common;
using PM.Entity;

namespace PM.Data {

    public class Assetmeter {

        /// <summary>
        /// 创建资产计量器
        /// </summary>
        /// <param name="assetmeterInfo">资产计量器对象</param>
        /// <returns></returns>
        public static int CreateAssetmeter(AssetmeterInfo assetmeterInfo) {
            return DatabaseProvider.GetInstance().CreateAssetmeter(assetmeterInfo);
        }

        /// <summary>
        /// 更新资产计量器
        /// </summary>
        /// <param name="assetmeterInfo">资产计量器对象</param>
        /// <returns></returns>
        public static bool UpdateAssetmeter(AssetmeterInfo assetmeterInfo) {
            return DatabaseProvider.GetInstance().UpdateAssetmeter(assetmeterInfo);
        }

        /// <summary>
        /// 删除资产计量器
        /// </summary>
        /// <param name="idList">计量器ID列表</param>
        /// <returns></returns>
        public static int DeleteAssetmeter(string idList) {
            return DatabaseProvider.GetInstance().DeleteAssetmeter(idList);
        }

        /// <summary>
        /// 查找资产对应的计量器
        /// </summary>
        /// <param name="assetnum">资产编号</param>
        /// <returns></returns>
        public static DataTable FindAssetmeterByAssetnum(string assetnum) {
            return DatabaseProvider.GetInstance().FindAssetmeterByAssetnum(assetnum);
        }


        public static List<AssetmeterInfo> GetAssetmeterByAssetnum(string assetnum) {

            List<AssetmeterInfo> list = new List<AssetmeterInfo>();
            using (IDataReader reader = FindAssetmeterByAssetnum(assetnum).CreateDataReader()) {
                while (reader.Read()) {
                    AssetmeterInfo assetmeterInfo = LoadAssetmeterInfo(reader);

                    MeasurePointInfo measurePointInfo = MeasurePoint.GetMeasurePointByPointNum(assetmeterInfo.Metername);
                    assetmeterInfo.PointDescription = measurePointInfo.Description;
                    list.Add(assetmeterInfo);
                }
                reader.Close();
            }

            return list;
        }


        /// <summary>
        /// 查找资产计量器
        /// </summary>
        /// <param name="condition">查询SQL</param>
        /// <returns></returns>
        public static DataTable FindAssetmeterByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindAssetmeterByCondition(condition);
        }

        public static List<AssetmeterInfo> GetAssetmeterByCondition(string condition) {
            List<AssetmeterInfo> list = new List<AssetmeterInfo>();
            using (IDataReader reader = FindAssetmeterByCondition(condition).CreateDataReader()) {
                while (reader.Read()) {
                    AssetmeterInfo assetmeterInfo = LoadAssetmeterInfo(reader);
                    list.Add(assetmeterInfo);
                }
                reader.Close();
            }

            return list;
        }


        public static AssetmeterInfo LoadAssetmeterInfo(IDataReader reader) {
            AssetmeterInfo assetmeterInfo = new AssetmeterInfo();
            assetmeterInfo.Active = reader.IsDBNull(reader.GetOrdinal("Active")) ? true : Convert.ToBoolean(reader["Active"]);
            assetmeterInfo.Assetmeterid = TypeConverter.ObjectToInt(reader["Assetmeterid"]);
            assetmeterInfo.Assetnum = reader["Assetnum"].ToString();
            assetmeterInfo.Average = reader.IsDBNull(reader.GetOrdinal("Average")) ? 0 : Convert.ToDecimal(reader["Average"]);
            assetmeterInfo.Avgcalcmethod = reader["Avgcalcmethod"].ToString();
            assetmeterInfo.Basemeasureunitid = reader["Basemeasureunitid"].ToString();
            assetmeterInfo.Changeby = reader["Changeby"].ToString();
            assetmeterInfo.Changedate = TypeConverter.ObjectToDateTime(reader["Changedate"].ToString());
            assetmeterInfo.Hasld = reader.IsDBNull(reader.GetOrdinal("Hasld")) ? true : Convert.ToBoolean(reader["Hasld"]);
            assetmeterInfo.Langcode = reader["Langcode"].ToString();
            assetmeterInfo.Lastreading = reader["Lastreading"].ToString();
            assetmeterInfo.Lastreadingdate = TypeConverter.ObjectToDateTime(reader["Lastreadingdate"].ToString());
            assetmeterInfo.Lastreadinginspctr = reader["Lastreadinginspctr"].ToString();
            assetmeterInfo.Lifetodate = reader.IsDBNull(reader.GetOrdinal("Lifetodate")) ? 0 : Convert.ToDecimal(reader["Lifetodate"]);
            assetmeterInfo.Measureunitid = reader["Measureunitid"].ToString();
            assetmeterInfo.Metername = reader["Metername"].ToString();
            assetmeterInfo.Orgid = reader["Orgid"].ToString();
            assetmeterInfo.Pointnum = reader["Pointnum"].ToString();
            assetmeterInfo.PointDescription  = Utils.ContainsField(reader,"PointDescription") ? reader["PointDescription"].ToString() : "";
            assetmeterInfo.Readingtype = reader["Readingtype"].ToString();
            assetmeterInfo.Remarks = reader["Remarks"].ToString();
            assetmeterInfo.Rolldownsource = reader["Rolldownsource"].ToString();
            assetmeterInfo.Rollover =  reader.IsDBNull(reader.GetOrdinal("Rollover")) ? 0 : Convert.ToDecimal(reader["Rollover"]);
            assetmeterInfo.Sequence = TypeConverter.ObjectToInt(reader["Sequence"]);
            assetmeterInfo.Sinceinstall =  reader.IsDBNull(reader.GetOrdinal("Sinceinstall")) ? 0 : Convert.ToDecimal(reader["Sinceinstall"]);
            assetmeterInfo.Sincelastinspect =  reader.IsDBNull(reader.GetOrdinal("Sincelastinspect")) ? 0 : Convert.ToDecimal(reader["Sincelastinspect"]);
            assetmeterInfo.Sincelastoverhaul =  reader.IsDBNull(reader.GetOrdinal("Sincelastoverhaul")) ? 0 : Convert.ToDecimal(reader["Sincelastoverhaul"]);
            assetmeterInfo.Sincelastrepair =  reader.IsDBNull(reader.GetOrdinal("Sincelastrepair")) ? 0 : Convert.ToDecimal(reader["Sincelastrepair"]);
            assetmeterInfo.Siteid = reader["Siteid"].ToString();
            assetmeterInfo.Slidingwindowsize = TypeConverter.ObjectToInt(reader["Slidingwindowsize"]);

            return assetmeterInfo;
        }


    }
}
