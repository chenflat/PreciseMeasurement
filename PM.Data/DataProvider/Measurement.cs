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
    /// <summary>
    /// 计量器读表数
    /// </summary>
    public class Measurement
    {
        /// <summary>
        /// 获取指定计量器的最后记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
        public static IDataReader FindLastMeasurement(string pointnum)
        {
            return DatabaseProvider.GetInstance().FindLastMeasurement(pointnum);
        }

        /// <summary>
        /// 返回指定计量器的最后记录对象
        /// </summary>
        /// <param name="pointnum">计量器编号</param>
        /// <returns></returns>
        public static MeasurementInfo GetLastMeasurement(string pointnum)
        {

            MeasurementInfo measurement = new MeasurementInfo();
            using (IDataReader reader = FindLastMeasurement(pointnum)) {
                if (reader.Read()) {
                    measurement = LoadMeasurementInfo(reader);
                    reader.Close();
                }
            }
            return measurement;

        }

        /// <summary>
        /// 获取所有测点的最后测量值
        /// </summary>
        /// <param name="carrier">携能载体</param>
        /// <returns></returns>
        public static IDataReader GetLastMeasureValueByAllPoint(string carrier) {
            return DatabaseProvider.GetInstance().GetLastMeasureValueByAllPoint(carrier);
        }

        /// <summary>
        /// 获取所有测点的最后测量值
        /// </summary>
        /// <param name="carrier">携能载体</param>
        /// <returns></returns>
        public static IDataReader GetLastMeasureValueByAllPoint() {
            return DatabaseProvider.GetInstance().GetLastMeasureValueByAllPoint();
        }

        /// <summary>
        /// 获取所有测点的最后测量值
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public static List<MeasurementInfo> GetLastMeasureValueList(string carrier) {
            List<MeasurementInfo> list = new List<MeasurementInfo>();
            using (IDataReader reader = GetLastMeasureValueByAllPoint(carrier)) {
                while (reader.Read()) {
                    MeasurementInfo measurementInfo = LoadMeasurementInfo(reader);
                    list.Add(measurementInfo);
                }
                reader.Close();
            }
            return list;
        }

        /// <summary>
        /// 获取所有测点的最后测量值
        /// </summary>
        /// <param name="carrier"></param>
        /// <returns></returns>
        public static List<MeasurementInfo> GetLastMeasureValueList() {
            List<MeasurementInfo> list = new List<MeasurementInfo>();
            using (IDataReader reader = GetLastMeasureValueByAllPoint()) {
                while (reader.Read()) {
                    MeasurementInfo measurementInfo = LoadMeasurementInfo(reader);
                    list.Add(measurementInfo);
                }
                reader.Close();
            }
            return list;
        }


        /// <summary>
        /// 获取指定计量器的第一条记录值
        /// </summary>
        /// <param name="pointnum">记录器编号</param>
        /// <returns></returns>
        public static IDataReader FindFirstMeasurement(string pointnum) {
            return DatabaseProvider.GetInstance().FindFirstMeasurement(pointnum);
        }

        /// <summary>
        /// 获取指定计量器的第一条记录对象
        /// </summary>
        /// <param name="pointnum">计量器编号</param>
        /// <returns></returns>
        public static MeasurementInfo GetFirstMeasurement(string pointnum) {

            MeasurementInfo measurement = new MeasurementInfo();
            using (IDataReader reader = FindFirstMeasurement(pointnum)) {
                if (reader.Read()) {
                    measurement = LoadMeasurementInfo(reader);
                    reader.Close();
                }
            }
            return measurement;

        }



        /// <summary>
        /// 加载读数对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MeasurementInfo LoadMeasurementInfo(IDataReader reader)
        {
            MeasurementInfo measurement = new MeasurementInfo();

            measurement.Measurementid = reader.GetSchemaTable().Columns["MEASUREMENTID"]==null ? 0 : reader.GetInt64(reader.GetOrdinal("MEASUREMENTID"));
            measurement.Pointnum = reader["POINTNUM"].ToString();
            measurement.Description = Utils.ContainsField(reader, "DESCRIPTION") ? reader["DESCRIPTION"].ToString() : "";
            measurement.DeviceNum = reader.GetSchemaTable().Columns["DEVICENUM"] == null ? "" : reader["DEVICENUM"].ToString();
            measurement.Inspector = reader.GetSchemaTable().Columns["INSPECTOR"] == null ? "" : reader["INSPECTOR"].ToString();
            measurement.Measuretime = TypeConverter.StrToDateTime(reader["MEASURETIME"].ToString(), DateTime.Parse("1900-01-01"));
            measurement.AiDensity = reader.IsDBNull(reader.GetOrdinal("AI_DENSITY")) ? 0 : reader.GetDecimal(reader.GetOrdinal("AI_DENSITY"));
            measurement.SwTemperature = reader.IsDBNull(reader.GetOrdinal("SW_TEMPERATURE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("SW_TEMPERATURE"));
            measurement.AfFlowinstant = reader.IsDBNull(reader.GetOrdinal("AF_FLOWINSTANT")) ? 0 : reader.GetDecimal(reader.GetOrdinal("AF_FLOWINSTANT"));
            measurement.SwPressure = reader.IsDBNull(reader.GetOrdinal("SW_PRESSURE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("SW_PRESSURE"));
            measurement.AtFlow = reader.IsDBNull(reader.GetOrdinal("AT_FLOW")) ? 0 : reader.GetDecimal(reader.GetOrdinal("AT_FLOW"));
            measurement.MV1 = reader.GetSchemaTable().Columns["MV1"] == null ? 0 : reader.GetDecimal(reader.GetOrdinal("MV1"));
            measurement.MV2 = reader.GetSchemaTable().Columns["MV2"] == null ? 0 : reader.GetDecimal(reader.GetOrdinal("MV2"));
            measurement.MV3 = reader.GetSchemaTable().Columns["MV3"] == null ? 0 : reader.GetDecimal(reader.GetOrdinal("MV3"));
            measurement.MV4 = reader.GetSchemaTable().Columns["MV4"] == null ? 0 : reader.GetDecimal(reader.GetOrdinal("MV4"));
            measurement.MV5 = reader.GetSchemaTable().Columns["MV5"] == null ? "" : reader.GetOrdinal("MV5").ToString();

            return measurement;
        }


        public static MeasurementInfo LoadStatInfo(IDataReader reader)
        {
            MeasurementInfo measurement = new MeasurementInfo();
            measurement.Pointnum = reader["POINTNUM"].ToString();
            measurement.Measuretime = TypeConverter.StrToDateTime(reader["MEASURETIME"].ToString(), DateTime.Parse("1900-01-01"));
            measurement.AtFlow = reader.IsDBNull(reader.GetOrdinal("AT_FLOW")) ? 0 : reader.GetDecimal(reader.GetOrdinal("AT_FLOW"));
            return measurement;
        }

        /// <summary>
        /// 转换统计对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static MeasurementStatInfo LoadMeasurementStatInfo(IDataReader reader)
        {
            MeasurementStatInfo statInfo = new MeasurementStatInfo();
            statInfo.Pointnum = reader["POINTNUM"].ToString();
            statInfo.Measureunitid = reader.IsDBNull(reader.GetOrdinal("MEASUREUNITID")) ? "AT_FLOW" : reader["MEASUREUNITID"].ToString();
            statInfo.Measuretime = TypeConverter.StrToDateTime(reader["MEASURETIME"].ToString(), DateTime.Parse("1900-01-01"));
            statInfo.Starttime = TypeConverter.StrToDateTime(reader["STARTTIME"].ToString(), DateTime.Parse("1900-01-01"));
            statInfo.Endtime = TypeConverter.StrToDateTime(reader["ENDTIME"].ToString(), DateTime.Parse("1900-01-01"));
            statInfo.StartValue = reader.IsDBNull(reader.GetOrdinal("STARTVALUE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("STARTVALUE"));
            statInfo.LastValue = reader.IsDBNull(reader.GetOrdinal("LASTVALUE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("LASTVALUE"));
            statInfo.Value = reader.IsDBNull(reader.GetOrdinal("VALUE")) ? 0 : reader.GetDecimal(reader.GetOrdinal("VALUE"));
            statInfo.Description = PM.Common.Utils.ContainsField(reader,"DESCRIPTION") ? reader["DESCRIPTION"].ToString() : "";
            statInfo.Level = PM.Common.Utils.ContainsField(reader,"LEVEL") ? reader["LEVEL"].ToString().Trim() : ""; 
            return statInfo;
        }




        /// <summary>
        /// 获取指定查询条件的读表数据
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        public static DataTable FindMeasurementByCondition(string condition, string type, int pageindex, int pagesize, out int recordcount)
        {
            return DatabaseProvider.GetInstance().FindMeasurementByCondition(condition, type, pageindex, pagesize, out recordcount);
        }

        /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        public static IDataReader FindMeasurementHistoryData(string pointnum, string startdate, string enddate, ReportType reportType)
        {
            return DatabaseProvider.GetInstance().FindMeasurementHistoryData(pointnum, startdate, enddate, reportType);
        }

        /// <summary>
        /// 获取指定时间内的测量数据报告
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        public static DataTable GetMeasurementReport(string startdate, string enddate,string level,string orgid,ReportType reportType) {
            return DatabaseProvider.GetInstance().GetMeasurementReport(startdate, enddate,level,orgid, reportType);
        }


        /// <summary>
        /// 获取指定时间内的测量数据自定义报告
        /// </summary>
        /// <param name="pointnum">自定义测点,多测点用半角逗号隔开,如S1,S2,S3</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="reportType">查询方式</param>
        /// <param name="formula">计算公式</param>
        /// <returns></returns>
        public static DataTable GetMeasurementCustomReport(string pointnum, string startdate, string enddate, ReportType reportType, string formula) {
            return DatabaseProvider.GetInstance().GetMeasurementCustomReport(pointnum, startdate, enddate, reportType, formula);
        }


        /// <summary>
        /// 获取指定测点的读表数据
        /// </summary>
        /// <param name="pointnum">测点编号</param>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询类型</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <param name="recordcount">总条数</param>
        /// <returns></returns>
        public static DataSet FindMeasurementByPointnum(string pointnum, string startdate, string enddate, string type, int pageindex, int pagesize)
        {
            return DatabaseProvider.GetInstance().FindMeasurementByPointnum(pointnum, startdate, enddate, type, pageindex, pagesize);
        }

        /// <summary>
        /// 获取指定时间内所有计量器的读表数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询方式： ALL全部 DAY日报 WEEK周报 MONTH月报 </param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        public static DataSet FindMeasurementByAllPoint(string startdate, string enddate,string level, string type, int pageindex, int pagesize)
        {
            return DatabaseProvider.GetInstance().FindMeasurementByAllPoint(startdate, enddate,level, type,"", pageindex, pagesize);
        }

        /// <summary>
        /// 获取指定时间内所有计量器的读表数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <param name="type">查询方式： ALL全部 DAY日报 WEEK周报 MONTH月报 </param>
        /// <param name="pageindex">当前页</param>
        /// <param name="pagesize">每页显示数</param>
        /// <returns></returns>
        public static DataSet FindMeasurementByAllPoint(string startdate, string enddate, string level, string type, string orgid,int pageindex, int pagesize) {
            return DatabaseProvider.GetInstance().FindMeasurementByAllPoint(startdate, enddate, level, type,orgid, pageindex, pagesize);
        }

        /// <summary>
        /// 获取报表数据
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static ReportDataInfo LoadReportDataInfo(IDataReader reader) {
            ReportDataInfo reportDataInfo = new ReportDataInfo();

            reportDataInfo.Pointnum = reader["POINTNUM"].ToString();
            reportDataInfo.Description = reader["Description"].ToString();
            reportDataInfo.Level = reader["Level"].ToString();
           // reportDataInfo.StartDate = reader["StartDate"].ToString();
            //reportDataInfo.EndDate = reader["EndDate"].ToString();
            reportDataInfo.StartValue = reader.IsDBNull(reader.GetOrdinal("StartValue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("StartValue"));
           // reportDataInfo.EndValue = reader.IsDBNull(reader.GetOrdinal("EndValue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("EndValue"));
          //  reportDataInfo.DiffValue = reader.IsDBNull(reader.GetOrdinal("DiffValue")) ? 0 : reader.GetDecimal(reader.GetOrdinal("DiffValue"));

            return reportDataInfo;
        }


        /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        public static IDataReader FindMeasurementByDate(string startdate, string enddate,string pointNum,ReportType reportType) {
            return DatabaseProvider.GetInstance().FindMeasurementByDate(startdate, enddate,pointNum, reportType);
        }

        /// <summary>
        /// 获取指定时间内的的测量数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        /// <param name="enddate">结束时间</param>
        /// <returns></returns>
        public static IDataReader FindMeasurementByDate(string startdate, string enddate, ReportType reportType) {
            return DatabaseProvider.GetInstance().FindMeasurementByDate(startdate, enddate, "", reportType);
        }


        /// <summary>
        /// 获取指定测点的最后计量时间
        /// </summary>
        /// <param name="pointnum">计量点编号</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        public static DateTime GetLastMeasurtimeByPointNum(string pointnum, ReportType reportType) {
           
            IDataReader reader = DatabaseProvider.GetInstance().GetLastMeasurtimeByPointNum(pointnum,reportType);
            DateTime time = new DateTime();
            if (reader.Read()) {
                time = TypeConverter.StrToDateTime(reader["MEASURETIME"].ToString(), DateTime.Parse("1900-01-01"));
                reader.Close();
            }
            return time;
        }



        /// <summary>
        /// 获取指定测点的最后计量时间
        /// </summary>
        /// <param name="pointnum">计量点编号</param>
        /// <param name="reportType">查询方式</param>
        /// <returns></returns>
        public static DateTime GetFirstMeasurtimeByPointNum(string pointnum) {

            IDataReader reader = DatabaseProvider.GetInstance().FindFirstMeasurement(pointnum);
            DateTime time = new DateTime();
            if (reader.Read()) {
                time = TypeConverter.StrToDateTime(reader["MEASURETIME"].ToString(), DateTime.Parse("1900-01-01"));
                reader.Close();
            }
            return time;
        }


       


    }
}
