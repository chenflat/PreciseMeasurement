using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 计量信息
    /// </summary>
    public class MeasurementInfo
    {
        private long measurementid;
        private string pointnum;
        private string metername;
        private string orgid;
        private string siteid;
        private string location;
        private string basemeasureunitid;
        private string inspector;
        private DateTime measuretime;
        private decimal measurementvalue;

        public long Measurementid
        {
            get { return measurementid; }
            set { measurementid = value; }
        }
        public string Pointnum
        {
            get { return pointnum; }
            set { pointnum = value; }
        }
        public string Metername
        {
            get { return metername; }
            set { metername = value; }
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
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string Basemeasureunitid
        {
            get { return basemeasureunitid; }
            set { basemeasureunitid = value; }
        }
        public string Inspector
        {
            get { return inspector; }
            set { inspector = value; }
        }
        public DateTime Measuretime
        {
            get { return measuretime; }
            set { measuretime = value; }
        }
        public decimal Measurementvalue
        {
            get { return measurementvalue; }
            set { measurementvalue = value; }
        }
    }
}
