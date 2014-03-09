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
    public class MeasurePoint
    {

        /// <summary>
        /// 获取指定条件的计量点列表
        /// </summary>
        /// <param name="condition">查询条件(可为空，如果有条件必须添加Where关键字)</param>
        /// <returns></returns>
        public static DataTable FindMeasurePointByCondition(string condition)
        {
            return DatabaseProvider.GetInstance().FindMeasurePointByCondition(condition);
        }


        public static MeasurePointInfo GetMeasurePointByPointNum(string pointnum) {
            string condition = string.Format(" and POINTNUM='{0}'",pointnum);
            DataTable dt = FindMeasurePointByCondition(condition);
            MeasurePointInfo measurePointInfo = new MeasurePointInfo();
            using (IDataReader reader = dt.CreateDataReader()) {
                if (reader.Read()) {
                  measurePointInfo =  LoadMeasurePointInfo(reader);
                }
                reader.Close();
            }
            return measurePointInfo;
        }



        /// <summary>
        /// 获取指定位置的计量点列表
        /// </summary>
        /// <param name="location">位置编码</param>
        /// <returns></returns>
        public static DataTable FindMeasurePointTableByLocation(string location)
        {
            return DatabaseProvider.GetInstance().FindMeasurePointTableByLocation(location);
        }

        
        /// <summary>
        /// 获取计量点和位置信息
        /// </summary>
        /// <returns></returns>
        public static IDataReader FindMeasurePointAndLocation()
        {
            return DatabaseProvider.GetInstance().FindMeasurePointAndLocation();
        }

        /// <summary>
        /// 添加计量点
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        public static int CreateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            return DatabaseProvider.GetInstance().CreateMeasurePoint(measurePointInfo);
        }

        /// <summary>
        /// 更新计量点信息
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        public static bool UpdateMeasurePoint(MeasurePointInfo measurePointInfo)
        {
            return DatabaseProvider.GetInstance().UpdateMeasurePoint(measurePointInfo);
        }

        /// <summary>
        /// 删除计量点信息
        /// </summary>
        /// <param name="idList">ID列表，多个ID请用","分隔</param>
        /// <returns></returns>
        public static int DeleteMeasurePoint(string idList)
        {
            return DatabaseProvider.GetInstance().DeleteMeasurePoint(idList);
        }

        /// <summary>
        /// 获取指定ID的计量点信息
        /// </summary>
        /// <param name="id">计量点ID</param>
        /// <returns></returns>
        public static MeasurePointInfo GetMeasurePointInfo(long id)
        {
            if (id <= 0)
                return null;
            MeasurePointInfo measurePointInfo = null;

            IDataReader reader = DatabaseProvider.GetInstance().FindMeasurePointById(id);
            if (reader.Read())
            {
                measurePointInfo = LoadMeasurePointInfo(reader);
                reader.Close();
            }

            return measurePointInfo;
        }

        public static MeasurePointInfo LoadMeasurePointInfo(IDataReader reader)
        {
            MeasurePointInfo measurePointInfo = new MeasurePointInfo();
            measurePointInfo.Measurepointid = reader.GetInt64(reader.GetOrdinal("MEASUREPOINTID"));
            measurePointInfo.Pointnum = reader["POINTNUM"].ToString();
            measurePointInfo.PointCode = reader["POINTCODE"].ToString();
            measurePointInfo.Description = reader["DESCRIPTION"].ToString();
            measurePointInfo.Displaysequence = TypeConverter.ObjectToInt(reader["DISPLAYSEQUENCE"]);
            measurePointInfo.Ipaddress = reader["IPADDRESS"].ToString();
            measurePointInfo.Cardnum = reader["CARDNUM"].ToString();
            measurePointInfo.Devicenum = reader["DEVICENUM"].ToString();
            measurePointInfo.Serverip = reader["SERVERIP"].ToString();
            measurePointInfo.Serverport = TypeConverter.ObjectToInt(reader["SERVERPORT"]);
            measurePointInfo.Metername = reader["METERNAME"].ToString();
            measurePointInfo.Orgid = reader["ORGID"].ToString();
            measurePointInfo.Orgname = reader.GetSchemaTable().Columns["ORGNAME"] == null ? "" : reader["ORGNAME"].ToString();
            measurePointInfo.Siteid = reader["SITEID"].ToString();
            measurePointInfo.Location = reader["LOCATION"].ToString();
            measurePointInfo.Carrier = reader["CARRIER"].ToString();
            measurePointInfo.Supervisor = reader["SUPERVISOR"].ToString();
            measurePointInfo.Phone = reader["PHONE"].ToString();
            measurePointInfo.Level = TypeConverter.ObjectToInt(reader["LEVEL"]);
            measurePointInfo.X = Utils.ContainsField(reader, "X") ? reader["X"].ToString() : "";
            measurePointInfo.Y = Utils.ContainsField(reader, "Y") ? reader["Y"].ToString() : "";
            measurePointInfo.Z = Utils.ContainsField(reader, "Z") ? reader["Z"].ToString() : "";
            measurePointInfo.Classstructureid = Utils.ContainsField(reader,"Classstructureid") ? reader["Classstructureid"].ToString() : "";
            
            return measurePointInfo;
        }

        /// <summary>
        /// 获取计量点统计条数
        /// </summary>
        /// <param name="condition">查询条件(注意：condition中不能包含Where关键字)</param>
        /// <returns></returns>
        public static long MeasurePointCount(string condition)
        {
            return DatabaseProvider.GetInstance().MeasurePointCount(condition);
        }

        /// <summary>
        /// 获取指定计量点的参数信息列表
        /// </summary>
        /// <param name="pointnum">计量点编号</param>
        /// <returns></returns>
        public static DataTable FindMeasurePointParamByPointNum(string pointnum)
        {
            return DatabaseProvider.GetInstance().FindMeasurePointParamByPointNum(pointnum);
        }

        /// <summary>
        /// 获取指定ID的计量点参数信息
        /// </summary>
        /// <param name="id">计量点参数ID</param>
        /// <returns></returns>
        public static IDataReader FindMeasurePointParamById(int id)
        {
            return DatabaseProvider.GetInstance().FindMeasurePointParamById(id);
        }


        /// <summary>
        /// 获取指定ID的参数信息
        /// </summary>
        /// <param name="id">参数ID</param>
        /// <returns></returns>
        public static MeasurePointParamInfo GetMeasurePointParamInfo(int id)
        {
            if (id <= 0)
                return null;
            MeasurePointParamInfo paramInfo = null;
            IDataReader reader = DatabaseProvider.GetInstance().FindMeasurePointParamById(id);
            if (reader.Read())
            {
                paramInfo = LoadMeasurePointParamInfo(reader);
                reader.Close();
            }
            return paramInfo;
        }

        public static MeasurePointParamInfo LoadMeasurePointParamInfo(IDataReader reader) {
            MeasurePointParamInfo paramInfo = new MeasurePointParamInfo();
            paramInfo.Measurepointparamuid = reader.GetInt32(reader.GetOrdinal("MEASUREPOINTPARAMUID"));
            paramInfo.Pointnum = reader["POINTNUM"].ToString();
            paramInfo.PointName =  Utils.ContainsField(reader,"POINTNAME")? reader["POINTNAME"].ToString() : "";
            paramInfo.Measureunitid = reader["MEASUREUNITID"].ToString();
            paramInfo.MeasureUnitName = Utils.ContainsField(reader, "MEASUREUNITNAME") ? reader["MEASUREUNITNAME"].ToString() : "";  
            paramInfo.Lowerwarning =  reader.IsDBNull(reader.GetOrdinal("LOWERWARNING"))? 0 : reader.GetDecimal(reader.GetOrdinal("LOWERWARNING"));
            paramInfo.Loweraction = reader.IsDBNull(reader.GetOrdinal("LOWERACTION")) ? 0 : reader.GetDecimal(reader.GetOrdinal("LOWERACTION"));
            paramInfo.Llpmnum = reader["LLPMNUM"].ToString();
            paramInfo.Llpriority = TypeConverter.ObjectToInt(reader["LLPRIORITY"]);
            paramInfo.Upperwarning = reader.IsDBNull(reader.GetOrdinal("UPPERWARNING")) ? 0 : reader.GetDecimal(reader.GetOrdinal("UPPERWARNING"));
            paramInfo.Upperaction = reader.IsDBNull(reader.GetOrdinal("UPPERACTION")) ? 0 : reader.GetDecimal(reader.GetOrdinal("UPPERACTION"));
            paramInfo.Ulpmnum = reader["ULPMNUM"].ToString();
            paramInfo.Ulpriority = TypeConverter.ObjectToInt(reader["ULPRIORITY"]);
            paramInfo.Abbreviation = reader["Abbreviation"].ToString();
            paramInfo.Displaysequence = reader.IsDBNull(reader.GetOrdinal("Displaysequence")) ? 0 : reader.GetInt32(reader.GetOrdinal("Displaysequence"));
            paramInfo.IsCalculate = reader.IsDBNull(reader.GetOrdinal("IsCalculate")) ? false : Convert.ToBoolean(reader["IsCalculate"]);
            paramInfo.Visabled = reader.IsDBNull(reader.GetOrdinal("Visabled")) ? false : Convert.ToBoolean(reader["Visabled"]);
            paramInfo.IsMainParam = reader.IsDBNull(reader.GetOrdinal("IsMainParam")) ? false : Convert.ToBoolean(reader["IsMainParam"]);

            return paramInfo;
        }



        /// <summary>
        /// 添加计量点参数信息
        /// </summary>
        /// <param name="paramInfo">计量点参数信息</param>
        /// <returns></returns>
        public static bool CreateMeasurePointParam(MeasurePointParamInfo paramInfo)
        {
            return DatabaseProvider.GetInstance().CreateMeasurePointParam(paramInfo);
        }

        /// <summary>
        /// 更新计量点坐标位置信息
        /// </summary>
        /// <param name="measurePointInfo">计量点信息</param>
        /// <returns></returns>
        public static int UpdateMeasurePointCoordinates(MeasurePointInfo measurePointInfo) {
            return DatabaseProvider.GetInstance().UpdateMeasurePointCoordinates(measurePointInfo);
        }

        /// <summary>
        /// 更新计量点参数信息
        /// </summary>
        /// <param name="paramInfo">计量点参数信息</param>
        /// <returns></returns>
        public static bool UpdateMeasurePointParam(MeasurePointParamInfo paramInfo)
        {
            return DatabaseProvider.GetInstance().UpdateMeasurePointParam(paramInfo);
        }

        /// <summary>
        /// 删除指定参数ID的信息
        /// </summary>
        /// <param name="idList">参数ID列表,多个ID用","号分隔</param>
        /// <returns></returns>
        public static int DeleteMeasurePointParam(string idList)
        {
            return DatabaseProvider.GetInstance().DeleteMeasurePointParam(idList);
        }


        /// <summary>
        /// 获取指定层级的计量器列表
        /// </summary>
        /// <param name="carrier">携能载体</param>
        /// <param name="level">层级ID</param>
        /// <param name="orgid">组织机构ID</param>
        /// <param name="siteid">地点ID</param>
        /// <returns></returns>
        public static IDataReader FindMeasurePointsByLevel(string carrier, int level, string orgid, string siteid) {
            return DatabaseProvider.GetInstance().FindMeasurePointsByLevel(carrier,level, orgid, siteid);
        }





        /// <summary>
        /// 更新记量点最后更新日期
        /// </summary>
        /// <param name="pointnum">计量点</param>
        /// <param name="lastsyntime">最后更新时间</param>
        /// <returns></returns>
        public static bool UpdateMeasurePointLastSynTime(string pointnum, DateTime lastsyntime) {
            return DatabaseProvider.GetInstance().UpdateMeasurePointLastSynTime(pointnum, lastsyntime);
        }

    }
}
