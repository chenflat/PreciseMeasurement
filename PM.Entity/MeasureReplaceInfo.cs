using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    public class MeasureReplaceInfo
    {
        private long measuretransid;
        private string pointnum;
        private decimal measurementvalue;
        private string enterby;
        private DateTime enterdate = DateTime.Now;
        private string topointnum;
        private decimal tomeasurementvalue;
        private string fromdept;
        private string fromloc;
        private DateTime replacedate;
        private string replacetype;
        private string memo;
        private string orgid;
        private string siteid;

        public long Measuretransid
        {
            get { return measuretransid; }
            set { measuretransid = value; }
        }
        public string Pointnum
        {
            get { return pointnum; }
            set { pointnum = value; }
        }
        public decimal Measurementvalue
        {
            get { return measurementvalue; }
            set { measurementvalue = value; }
        }
        public string EnterBy
        {
            get { return enterby; }
            set { enterby = value; }
        }
        public DateTime EnterDate
        {
            get { return enterdate; }
            set { enterdate = value; }
        }
        public string ToPointnum
        {
            get { return topointnum; }
            set { topointnum = value; }
        }
        public decimal ToMeasurementValue
        {
            get { return tomeasurementvalue; }
            set { tomeasurementvalue = value; }
        }
        public string FromDept
        {
            get { return fromdept; }
            set { fromdept = value; }
        }
        public string FromLoc
        {
            get { return fromloc; }
            set { fromloc = value; }
        }
        public DateTime ReplaceDate
        {
            get { return replacedate; }
            set { replacedate = value; }
        }
        public string ReplaceType
        {
            get { return replacetype; }
            set { replacetype = value; }
        }
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }
        public string Siteid
        {
            get { return siteid; }
            set { siteid = value; }
        }
    }
}
