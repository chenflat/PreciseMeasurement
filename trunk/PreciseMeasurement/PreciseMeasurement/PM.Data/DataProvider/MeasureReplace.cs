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
    public class MeasureReplace
    {

        /// <summary>
        /// 获取换表记录
        /// </summary>
        /// <param name="condition">查找条件</param>
        /// <returns></returns>
        public static DataTable FindMeasureReplaceTableByCondition(string condition) {
            return DatabaseProvider.GetInstance().FindMeasureReplaceTableByCondition(condition);
        }


        /// <summary>
        /// 获取换表记录信息
        /// </summary>
        /// <param name="id">换表记录ID</param>
        /// <returns></returns>
        public static IDataReader FindMeasureReplaceById(long id) {
            return DatabaseProvider.GetInstance().FindMeasureReplaceById(id);
        }


        /// <summary>
        /// 获取指定ID的换表记录信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static MeasureReplaceInfo GetMeasureReplaceInfo(long id) {
            if (id <= 0)
                return null;
            MeasureReplaceInfo measureReplaceInfo = new MeasureReplaceInfo();
            IDataReader reader = FindMeasureReplaceById(id);
            if (reader.Read())
            {
                measureReplaceInfo = LoadMeasureReplaceInfo(reader);
                reader.Close();
            }
            return measureReplaceInfo;
        }

        /// <summary>
        /// 转换换表记录信息
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MeasureReplaceInfo LoadMeasureReplaceInfo(IDataReader reader)
        {
            MeasureReplaceInfo measureReplaceInfo = new MeasureReplaceInfo();
            measureReplaceInfo.Measuretransid = reader.GetInt64(reader.GetOrdinal("MEASURETRANSID"));
            measureReplaceInfo.Pointnum = reader["POINTNUM"].ToString();
            measureReplaceInfo.MeasureunitId = reader["MEASUREUNITID"].ToString();
            measureReplaceInfo.MeasureunitName = reader["MEASUREUNITNAME"].ToString();
            measureReplaceInfo.MeasurementValue = reader.GetDecimal(reader.GetOrdinal("MEASUREMENTVALUE"));
            measureReplaceInfo.EnterBy = reader["ENTERBY"].ToString();
            measureReplaceInfo.EnterDate = TypeConverter.StrToDateTime(reader["ENTERDATE"].ToString(), DateTime.Parse("1900-01-01"));
            measureReplaceInfo.ToPointnum = reader["TOPOINTNUM"].ToString();
            measureReplaceInfo.ToMeasurementValue = reader.GetDecimal(reader.GetOrdinal("TOMEASUREMENTVALUE"));
            measureReplaceInfo.CorrectedValue = reader.GetDecimal(reader.GetOrdinal("CORRECTEDVALUE"));
            measureReplaceInfo.FromDept = reader["FROMDEPT"].ToString();
            measureReplaceInfo.FromLoc = reader["FROMLOC"].ToString();
            measureReplaceInfo.ReplacePerson = reader["REPLACEPERSON"].ToString();
            measureReplaceInfo.ReplaceDate = TypeConverter.StrToDateTime(reader["REPLACEDATE"].ToString(), DateTime.Parse("1900-01-01"));
            measureReplaceInfo.ReplaceType = reader["REPLACETYPE"].ToString();
            measureReplaceInfo.Memo = reader["MEMO"].ToString();
            measureReplaceInfo.Status = reader["STATUS"].ToString();
            measureReplaceInfo.Orgid = reader["ORGID"].ToString();
            measureReplaceInfo.Siteid = reader["SITEID"].ToString();
            return measureReplaceInfo;
        }


        /// <summary>
        /// 添加换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        public static bool CreateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            return DatabaseProvider.GetInstance().CreateMeasureReplace(measureReplaceInfo);
        }

        /// <summary>
        /// 更新换表记录
        /// </summary>
        /// <param name="measureReplaceInfo"></param>
        /// <returns></returns>
        public static bool UpdateMeasureReplace(MeasureReplaceInfo measureReplaceInfo) {
            return DatabaseProvider.GetInstance().UpdateMeasureReplace(measureReplaceInfo);
        }

        /// <summary>
        /// 删除换表记录
        /// </summary>
        /// <param name="idList">ID列表</param>
        /// <returns></returns>
        public static int DeleteMeasureReplace(string idList) {
            return DatabaseProvider.GetInstance().DeleteMeasureReplace(idList);
        }

        /// <summary>
        /// 换表记录条数
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static bool MeasureReplaceCount(string condition) {
            return DatabaseProvider.GetInstance().MeasureReplaceCount(condition);
        }
    }
}
