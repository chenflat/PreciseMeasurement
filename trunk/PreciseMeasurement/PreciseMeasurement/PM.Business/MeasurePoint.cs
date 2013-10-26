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
            if (measurePointInfo.Status==null || measurePointInfo.Status.Length == 0)
                measurePointInfo.Status = "ACTIVE";
            return Data.MeasurePoint.CreateMeasurePoint(measurePointInfo);
        }

        public static bool UpdateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            if (measurePointInfo.Status==null || measurePointInfo.Status.Length == 0)
                measurePointInfo.Status = "ACTIVE";
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

        /// <summary>
        /// 获取指定测点的参数列表
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <returns></returns>
        public static DataTable FindMeasurePointParamByPointNum(string pointnum)
        {
            if (pointnum == null || pointnum.Length == 0)
                return null;
            DataTable ret = Data.MeasurePoint.FindMeasurePointParamByPointNum(pointnum);
            if(ret.Rows.Count>0) {
                return ret;
            } else {

                foreach (DataRow item in MeasureUnit.FindAllMeasureUnitListDataTable().Rows)
                {
                    string measureunitid = item["MEASUREUNITID"].ToString();
                    MeasurePointParamInfo paramInfo = new MeasurePointParamInfo();
                    paramInfo.Pointnum = pointnum;
                    paramInfo.Measureunitid = measureunitid;
                    paramInfo.MeasureUnitName = item["DESCRIPTION"].ToString();
                    CreateMeasurePointParam(paramInfo);
                }
                return Data.MeasurePoint.FindMeasurePointParamByPointNum(pointnum);
            }
        }
        public static IDataReader FindMeasurePointParamById(int id)
        {
            return Data.MeasurePoint.FindMeasurePointParamById(id);
        }

        public static MeasurePointParamInfo GetMeasurePointParamInfo(int id)
        {
            return Data.MeasurePoint.GetMeasurePointParamInfo(id);
        }

        public static bool CreateMeasurePointParam(MeasurePointParamInfo paramInfo)
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


        /// <summary>
        /// 获取指定层级的计量器列表
        /// </summary>
        /// <param name="level">层级ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        public static List<MeasurePointInfo> FindMeasurePointsByLevel(int level, string orgid, string siteid) {

            if (orgid == null) orgid = "";
            if (siteid == null) siteid = "";

            List<MeasurePointInfo> list = new List<MeasurePointInfo>();

            using (IDataReader reader = Data.MeasurePoint.FindMeasurePointsByLevel(level,orgid,siteid))
            {
                while (reader.Read()) {
                    MeasurePointInfo measurePointInfo = Data.MeasurePoint.LoadMeasurePointInfo(reader);
                    list.Add(measurePointInfo);
                }
                reader.Close();
            }
            return list;
        }
    }
}
