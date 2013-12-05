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

        /// <summary>
        /// 获取计量点和位置信息
        /// </summary>
        /// <returns></returns>
        public static List<MeasurePointInfo> FindMeasurePointAndLocation() {
            List<MeasurePointInfo> list = new List<MeasurePointInfo>();
            using (IDataReader reader = PM.Data.MeasurePoint.FindMeasurePointAndLocation())
            {
                while (reader.Read())
                {
                    MeasurePointInfo measurePointInfo = PM.Data.MeasurePoint.LoadMeasurePointInfo(reader);
                    list.Add(measurePointInfo);
                }
                reader.Close();
            }

            return list;
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

        /// <summary>
        /// 更新计量点坐标位置信息
        /// </summary>
        /// <param name="measurePointInfos">计量点列表</param>
        /// <returns></returns>
        public static bool UpdateMeasurePointCoordinates(List<MeasurePointInfo> measurePointInfos) {
            if (measurePointInfos.Count == 0)
                return false;
            int changes = 0;
            for (int i = 0; i < measurePointInfos.Count; i++)
            {
                changes += Data.MeasurePoint.UpdateMeasurePointCoordinates(measurePointInfos[i]);
            }
            return changes > 0;
        } 

        /// <summary>
        /// 删除计量点信息
        /// </summary>
        /// <param name="idList">ID列表</param>
        /// <returns></returns>
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

        /// <summary>
        /// 获取指定类型的测点
        /// </summary>
        /// <param name="type">类型名称，如：汽，水</param>
        /// <param name="orgid"></param>
        /// <param name="siteid"></param>
        /// <returns></returns>
        public static List<MeasurePointInfo> FindMeasurePointByCarrier(string carrier, string orgid, string siteid) {
            //设置查询条件
            string condition = string.Format(" and [MEASUREPOINT].[CARRIER]='{0}' and ISNULL([MEASUREPOINT].[ORGID],'')='{1}' AND ISNULL([MEASUREPOINT].[siteid],'')='{2}'", carrier, orgid, siteid);
            DataTable table = Data.MeasurePoint.FindMeasurePointByCondition(condition);
            List<MeasurePointInfo> list = new List<MeasurePointInfo>();

            //迭代数据
            using (IDataReader reader = table.CreateDataReader()) {
                while (reader.Read()) {

                    MeasurePointInfo measurePointInfo = PM.Data.MeasurePoint.LoadMeasurePointInfo(reader);
                    list.Add(measurePointInfo);
                }
                reader.Close();
            }


            return list;
        }
    }
}
