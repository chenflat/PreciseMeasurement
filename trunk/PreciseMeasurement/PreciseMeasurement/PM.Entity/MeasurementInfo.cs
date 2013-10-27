using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 计量信息
    /// </summary>
    [Serializable()]
    public class MeasurementInfo
    {
        private long measurementid;
        private string pointnum;
        private string devicenum;
        private string orgid;
        private string siteid;
        private string location;
        private string basemeasureunitid;
        private string inspector;
        private DateTime measuretime;
        private decimal ai_density;
        private decimal sw_temperature;
        private decimal af_flowinstant;
        private decimal sw_pressure;
        private decimal at_flow;
        private decimal mv1;
        private decimal mv2;
        private decimal mv3;
        private decimal mv4;
        private string mv5;

        private string time;

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
        public string DeviceNum
        {
            get { return devicenum; }
            set { devicenum = value; }
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
        public decimal AiDensity
        {
            get { return ai_density; }
            set { ai_density = value; }
        }
        public decimal SwTemperature
        {
            get { return sw_temperature; }
            set { sw_temperature = value; }
        }
        public decimal AfFlowinstant
        {
            get { return af_flowinstant; }
            set { af_flowinstant = value; }
        }
        public decimal SwPressure
        {
            get { return sw_pressure; }
            set { sw_pressure = value; }
        }
        public decimal AtFlow
        {
            get { return at_flow; }
            set { at_flow = value; }
        }

        public decimal MV1
        {
            get { return mv1; }
            set { mv1 = value; }
        }
        public decimal MV2
        {
            get { return mv2; }
            set { mv2 = value; }
        }
        public decimal MV3
        {
            get { return mv3; }
            set { mv3 = value; }
        }
        public decimal MV4
        {
            get { return mv4; }
            set { mv4 = value; }
        }
        public string MV5
        {
            get { return mv5; }
            set { mv5 = value; }
        }


        public string Time {
            get { return Measuretime.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

    }
}
