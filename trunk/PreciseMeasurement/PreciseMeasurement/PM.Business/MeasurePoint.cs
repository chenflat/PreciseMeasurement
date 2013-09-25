using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using PM.Entity;
using PM.Data;
using PM.Common;


namespace PM.Business
{
    /// <summary>
    /// 计量点操作业务逻辑操作类
    /// </summary>
    public class MeasurePoint
    {
        public static DataTable FindMeasurePointByCondition(string condition) {
            return Data.MeasurePoint.FindMeasurePointByCondition(condition);
        }

        public static DataTable FindMeasurePointTableByLocation(string location)
        {
            return Data.MeasurePoint.FindMeasurePointTableByLocation(location);
        }

        public static int CreateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            return Data.MeasurePoint.CreateMeasurePoint(measurePointInfo);
        }

        public static bool UpdateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            return Data.MeasurePoint.UpdateMeasurePoint(measurePointInfo);
        }

        public static int DeleteMeasurePoint(string idList)
        {
            return Data.MeasurePoint.DeleteMeasurePoint(idList);
        }

        public static MeasurePointInfo GetMeasurePointInfo(long id) {
            return Data.MeasurePoint.GetMeasurePointInfo(id);
        }

        public static long MeasurePointCount(string condition) {
            return Data.MeasurePoint.MeasurePointCount(condition);
        }

        public static DataTable FindMeasurePointParamByPointNum(string pointnum)
        {
            return Data.MeasurePoint.FindMeasurePointParamByPointNum(pointnum);
        }
        public static IDataReader FindMeasurePointParamById(int id)
        {
            return Data.MeasurePoint.FindMeasurePointParamById(id);
        }

        public static MeasurePointParamInfo GetMeasurePointParamInfo(int id)
        {
            return Data.MeasurePoint.GetMeasurePointParamInfo(id);
        }

        public static int CreateMeasurePointParam(MeasurePointParamInfo paramInfo)
        {
            return Data.MeasurePoint.CreateMeasurePointParam(paramInfo);
        }

        public static bool UpdateMeasurePointParam(MeasurePointParamInfo paramInfo)
        {
            return Data.MeasurePoint.UpdateMeasurePointParam(paramInfo);
        }

        public static int DeleteMeasurePointParam(string idList)
        {
            return Data.MeasurePoint.DeleteMeasurePointParam(idList);
        }
    }
}
