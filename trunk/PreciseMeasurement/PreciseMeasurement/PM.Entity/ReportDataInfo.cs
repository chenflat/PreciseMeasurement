using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 报表数据信息
    /// </summary>
    public class ReportDataInfo
    {

        private int m_RowNumber;
        private string m_Pointnum;
        private string m_description;
        private string m_level;
        private DateTime m_measuretime;
        private DateTime m_starttime;
        private DateTime m_endtime;

        private decimal m_startvalue;
        private decimal m_lastvalue;
        private decimal m_value;

        public int RowNumber {
            get { return m_RowNumber; }
            set { m_RowNumber = value; }
        }

        public string Pointnum {
            get { return m_Pointnum; }
            set { m_Pointnum = value; }
        }

        public string Description {
            get { return m_description; }
            set { m_description = value; }
        }

        public string Level {
            get { return m_level; }
            set { m_level = value; }
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

        public decimal StartValue {
            get { return m_startvalue; }
            set { m_startvalue = value; }
        }

        public decimal LastValue {
            get { return m_lastvalue; }
            set { m_lastvalue = value; }
        }

        public decimal Value {
            get { return m_value; }
            set { m_value = value; }
        }
    }
}
