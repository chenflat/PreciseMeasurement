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
    /// 报警信息数据层数据类
    /// </summary>
    public class Alarmlog
    {
        
        /// <summary>
        /// 查找报警信息
        /// </summary>
        /// <param name="orgid">机构ID</param>
        /// <returns></returns>
        public static DataSet FindAlarmlogInfo(string startdate, string enddate, string pointnum, int status, string orgid, int pageindex, int pagesize)
        {
            return DatabaseProvider.GetInstance().FindAlarmlogInfo(startdate, enddate,pointnum, status, orgid, pageindex, pagesize);
        }


        /// <summary>
        /// 返回报警信息对象
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static AlarmlogInfo LoadAlarmlogInfo(IDataReader reader) {
            AlarmlogInfo alarmlogInfo = new AlarmlogInfo();
            alarmlogInfo.Logid = reader.GetInt32(reader.GetOrdinal("LOGID"));
            alarmlogInfo.Logtime = TypeConverter.ObjectToDateTime(reader["LOGTIME"]);
            alarmlogInfo.Measurevalue = reader.GetDecimal(reader.GetOrdinal("MEASUREVALUE"));
            alarmlogInfo.Limitvalue = reader.GetDecimal(reader.GetOrdinal("LIMITVALUE"));
            alarmlogInfo.Alarmtype = (AlarmType)Enum.Parse(typeof(AlarmType), reader["Alarmtype"].ToString());
            alarmlogInfo.Almcomment = reader["ALMCOMMENT"].ToString();
            alarmlogInfo.Measureunitid = reader["MEASUREUNITID"].ToString();
            alarmlogInfo.Pointnum = reader["POINTNUM"].ToString();
            alarmlogInfo.Almpriority = reader.GetInt32(reader.GetOrdinal("ALMPRIORITY"));
            alarmlogInfo.Almoperatorname = reader["ALMOPERATORNAME"].ToString();
            alarmlogInfo.Acktime = TypeConverter.ObjectToDateTime(reader["ACKTIME"]);
            alarmlogInfo.Ackvalue = reader.GetDecimal(reader.GetOrdinal("ACKVALUE"));
            alarmlogInfo.Ackoperatorname = reader["ACKOPERATORNAME"].ToString();
            alarmlogInfo.Rettime= TypeConverter.ObjectToDateTime(reader["RETTIME"]);
            alarmlogInfo.Retvalue = reader.GetDecimal(reader.GetOrdinal("RETVALUE"));
            alarmlogInfo.Retoperatorname = reader["RETOPERATORNAME"].ToString();

            alarmlogInfo.Reviewtime = TypeConverter.ObjectToDateTime(reader["REVIEWTIME"]);
            alarmlogInfo.Reviewcontent = reader["REVIEWCONTENT"].ToString();
            alarmlogInfo.Reviewer = reader["REVIEWER"].ToString();

            alarmlogInfo.Status = reader.GetInt32(reader.GetOrdinal("STATUS"));
            alarmlogInfo.Orgid = reader["ORGID"].ToString();

            return alarmlogInfo;
        }

    }
}
