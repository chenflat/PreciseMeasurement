using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    [Serializable]
    public enum AlarmType
    {
        LOWERWARNING = 1, LOWERACTION = 2, UPPERWARNING = 3, UPPERACTION = 4
    }

    /// <summary>
    /// 报警信息
    /// </summary>
    [Serializable()]
    public class AlarmlogInfo
    {
        private long m_logid;

        public long Logid
        {
            get { return m_logid; }
            set { m_logid = value; }
        }

        private DateTime m_logtime;

        public DateTime Logtime
        {
            get { return m_logtime; }
            set { m_logtime = value; }
        }


        private decimal m_measurevalue;

        public decimal Measurevalue
        {
            get { return m_measurevalue; }
            set { m_measurevalue = value; }
        }
        private decimal m_limitvalue;

        public decimal Limitvalue
        {
            get { return m_limitvalue; }
            set { m_limitvalue = value; }
        }
        private AlarmType m_alarmtype;

        public AlarmType Alarmtype
        {
            get { return m_alarmtype; }
            set { m_alarmtype = value; }
        }
        private string m_almcomment;

        public string Almcomment
        {
            get { return m_almcomment; }
            set { m_almcomment = value; }
        }
        private string m_measureunitid;

        public string Measureunitid
        {
            get { return m_measureunitid; }
            set { m_measureunitid = value; }
        }
        private string m_pointnum;

        public string Pointnum
        {
            get { return m_pointnum; }
            set { m_pointnum = value; }
        }
        private int m_almpriority;

        public int Almpriority
        {
            get { return m_almpriority; }
            set { m_almpriority = value; }
        }
        private string m_almoperatorname;

        public string Almoperatorname
        {
            get { return m_almoperatorname; }
            set { m_almoperatorname = value; }
        }
        private DateTime m_acktime;

        public DateTime Acktime
        {
            get { return m_acktime; }
            set { m_acktime = value; }
        }
        private decimal m_ackvalue;

        public decimal Ackvalue
        {
            get { return m_ackvalue; }
            set { m_ackvalue = value; }
        }
        private string m_ackoperatorname;

        public string Ackoperatorname
        {
            get { return m_ackoperatorname; }
            set { m_ackoperatorname = value; }
        }
        private DateTime m_rettime;

        public DateTime Rettime
        {
            get { return m_rettime; }
            set { m_rettime = value; }
        }
        private decimal m_retvalue;

        public decimal Retvalue
        {
            get { return m_retvalue; }
            set { m_retvalue = value; }
        }
        private string m_retoperatorname;

        public string Retoperatorname
        {
            get { return m_retoperatorname; }
            set { m_retoperatorname = value; }
        }

        private DateTime m_reviewtime;

        public DateTime Reviewtime
        {
            get { return m_reviewtime; }
            set { m_reviewtime = value; }
        }

        private string m_reviewcontent;

        public string Reviewcontent
        {
            get { return m_reviewcontent; }
            set { m_reviewcontent = value; }
        }
        private string m_reviewer;

        public string Reviewer
        {
            get { return m_reviewer; }
            set { m_reviewer = value; }
        }
        private int m_status = -1;

        public int Status
        {
            get { return m_status; }
            set { m_status = value; }
        }

        private string m_orgid;

        public string Orgid
        {
            get { return m_orgid; }
            set { m_orgid = value; }
        }


    }
}
