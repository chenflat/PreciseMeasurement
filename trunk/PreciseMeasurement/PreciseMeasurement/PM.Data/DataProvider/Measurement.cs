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
            IDataReader reader = FindLastMeasurement(pointnum);
            if (reader.Read())
            {
                measurement = LoadMeasurementInfo(reader);
                reader.Close();
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
        public static DataTable GetMeasurementReport(string startdate, string enddate, ReportType reportType) {
            return DatabaseProvider.GetInstance().GetMeasurementReport(startdate, enddate, reportType);
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
        public static DataSet FindMeasurementByAllPoint(string startdate, string enddate, string type, int pageindex, int pagesize)
        {
            return DatabaseProvider.GetInstance().FindMeasurementByAllPoint(startdate, enddate, type, pageindex, pagesize);
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
        public static IDataReader FindMeasurementByDate(string startdate, string enddate,ReportType reportType) {
            return DatabaseProvider.GetInstance().FindMeasurementByDate(startdate, enddate, reportType);
        }


        /// <summary>
        /// 生成统计数据
        /// </summary>
        /// <param name="type">报表类型</param>
        /// <returns></returns>
        public int CreateMeasurementStatData(ReportType type) {
            return CreateMeasurementStatData("", "", type);
        }

        /// <summary>
        /// 生成测试小时数据
        /// </summary>
        /// <param name="startdate">开始时间</param>
        public int CreateMeasurementStatData(string startdate,string enddate, ReportType type)
        {
            //开始时间
            DateTime dtStarttime = DateTime.Parse(startdate);
            DateTime dtEndtime;
            if (enddate == "" || enddate == null)
            {
                enddate = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                dtEndtime = DateTime.Now;
            }
            else {
                dtEndtime = DateTime.Parse(enddate);
            }

            //时间差
            TimeSpan t3 = dtEndtime.Subtract(dtStarttime);

            double totalHours = t3.TotalHours;
            double totalDays = t3.TotalDays;
            double totalMonth = dtEndtime.Month - dtStarttime.Month;


            //时间列表
            List<MeasurementStatInfo> listStatInfo = new List<MeasurementStatInfo>();

            string dateformat = "";
            if (type == ReportType.Hour) {
                dateformat = "yyyy-MM-dd HH";
                for (int h = 0; h < totalHours; h++) {
                    DateTime dh = dtStarttime.AddHours(h);
                    listStatInfo.Add(new MeasurementStatInfo(dh));
                }
            }
            else if (type == ReportType.Day)
            {
                dateformat = "yyyy-MM-dd";
                for (int d = 0; d < totalDays; d++) {
                    DateTime dd = dtStarttime.AddDays(d);
                    listStatInfo.Add(new MeasurementStatInfo(dd));
                }
            }
            else if (type == ReportType.Month) {
                dateformat = "yyyy-MM";
                for (int m = 0; m <= totalMonth; m++)
                {
                    DateTime dd = dtStarttime.AddMonths(m);
                    listStatInfo.Add(new MeasurementStatInfo(dd));
                }
            }

            //获取指定时间段内的测量数据
            List<MeasurementInfo> measurements = new List<MeasurementInfo>();
            using (IDataReader reader = FindMeasurementByDate(startdate, enddate, type))
            {
                while (reader.Read())
                {
                    MeasurementInfo measurementInfo = Data.Measurement.LoadStatInfo(reader);
                    measurements.Add(measurementInfo);
                }
                reader.Close();
            }

            //比较时间
            foreach (var item in listStatInfo)
            {
                List<MeasurementInfo> tempList = new List<MeasurementInfo>();

                for (int i = 0; i < measurements.Count; i++)
                {
                    if (measurements[i].Measuretime.ToString(dateformat) == item.Measuretime.ToString(dateformat))
                    {
                        tempList.Add(measurements[i]);
                        measurements.Remove(measurements[i]);
                    }
                }

                //获取最后一条记录
                if (tempList.Count > 0)
                {
                    MeasurementInfo lastMeasurement = tempList[tempList.Count - 1];
                    item.LastValue = lastMeasurement.AtFlow;
                    item.Pointnum = lastMeasurement.Pointnum;
                    item.Measureunitid = "AT_Flow";
                    item.Value = 0;
                }
            }
     
            bool ret;
            try
            {
                //计算用量差值
                for (int i = 0; i < listStatInfo.Count; i++)
                {
                    string pointnum = listStatInfo[i].Pointnum;
                 
                    if (i + 1 < listStatInfo.Count)
                    {
                        listStatInfo[i + 1].Value = listStatInfo[i + 1].LastValue - listStatInfo[i].LastValue;

                        MeasurementStatInfo statInfo = listStatInfo[i + 1];
                        statInfo.Starttime = listStatInfo[i].Measuretime;
                        statInfo.StartValue = listStatInfo[i].LastValue;
                        statInfo.Endtime = statInfo.Measuretime;
                        if (statInfo.Pointnum.Length > 0) {
                            if (type==ReportType.Hour)
                            {
                                ret = DatabaseProvider.GetInstance().CreateMeasurementHourData(statInfo);
                            }
                            else if (type==ReportType.Day)
                            {
                                ret = DatabaseProvider.GetInstance().CreateMeasurementDayData(statInfo);                                
                            }
                            else if (type == ReportType.Month)
                            {
                                ret = DatabaseProvider.GetInstance().CreateMeasurementMonthData(statInfo);
                            }

                        } 
                        PM.Data.MeasurePoint.UpdateMeasurePointLastSynTime(pointnum, statInfo.Measuretime);
                    }
                }

             // 
            }
            catch (Exception e)
            {
                throw e;
            }
           



            return listStatInfo.Count;
        }



    }
}
