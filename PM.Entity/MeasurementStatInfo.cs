using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    //报表类型
    public enum ReportType { 
        Minute,
        Hour,
        Day,
        Month
    }


    /// <summary>
    /// 测量统计数据
    /// </summary>
    public class MeasurementStatInfo
    {
        private string m_pointnum = "";
        private string m_measureunitid = "";
        private DateTime m_measuretime;
        private decimal m_startValue = 0;
        private decimal m_lastValue = 0;
        private DateTime m_starttime;
        private DateTime m_endtime;
        private decimal m_value = 0;

        public MeasurementStatInfo() { 
        
        }

        public MeasurementStatInfo(DateTime measuretime) {
            this.m_measuretime = measuretime;
        }


        public string Pointnum
        {
            get { return m_pointnum; }
            set { m_pointnum = value; }
        }

        public string Measureunitid
        {
            get { return m_measureunitid; }
            set { m_measureunitid = value; }
        }

        public DateTime Measuretime
        {
            get { return m_measuretime; }
            set { m_measuretime = value; }
        }

        public decimal StartValue
        {
            get { return m_startValue; }
            set { m_startValue = value; }
        }

        public decimal LastValue {
            get { return m_lastValue; }
            set { m_lastValue = value; }
        }

        public DateTime Starttime
        {
            get { return m_starttime; }
            set { m_starttime = value; }
        }

        public DateTime Endtime
        {
            get { return m_endtime; }
            set { m_endtime = value; }
        }


        public decimal Value {
            get { return m_value; }
            set { m_value = value; }
        }

    }
}
