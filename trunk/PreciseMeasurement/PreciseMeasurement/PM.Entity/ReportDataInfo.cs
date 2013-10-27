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
        private string m_startdate;
        private string m_enddate;
        private decimal m_startvalue;
        private decimal m_endvalue;
        private decimal m_diffvalue;

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

        public string StartDate
        {
            get { return m_startdate; }
            set { m_startdate = value; }
        }

        public string EndDate
        {
            get { return m_enddate; }
            set { m_enddate = value; }
        }

        public decimal StartValue {
            get { return m_startvalue; }
            set { m_startvalue = value; }
        }

        public decimal EndValue {
            get { return m_endvalue; }
            set { m_endvalue = value; }
        }

        public decimal DiffValue {
            get { return m_diffvalue; }
            set { m_diffvalue = value; }
        }
    }
}
