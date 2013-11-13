using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    //报表类型
    public enum ReportType { 
        Hour,
        Day,
        Month
    }


    /// <summary>
    /// 测量统计数据
    /// </summary>
    public class MeasurementStatInfo
    {
        private string m_pointnum;
        private string m_measureunitid;
        private DateTime m_measuretime;
        private decimal m_lastValue;
        private decimal m_value;

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

        public decimal LastValue {
            get { return m_lastValue; }
            set { m_lastValue = value; }
        }

        public decimal Value {
            get { return m_value; }
            set { m_value = value; }
        }

    }
}
