using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    [Serializable()]
    public class MeasurePointParamInfo
    {
        private int measurepointparamuid;
        private string pointnum;
        private string pointname;
        private string measureunitid;
        private string measureunitname;
        private decimal lowerwarning = 0;
        private decimal loweraction = 0;
        private string llpmnum;
        private int llpriority;
        private decimal upperwarning = 0;
        private decimal upperaction = 0;
        private string ulpmnum;
        private int ulpriority;

        public int Measurepointparamuid { 
            get {return measurepointparamuid;}
            set { measurepointparamuid = value; }
        }

        public string Pointnum
        {
            get { return pointnum; }
            set { pointnum = value; }
        }

        public string PointName {
            get { return pointname; }
            set { pointname = value; }
        }

        public string Measureunitid
        {
            get { return measureunitid; }
            set { measureunitid = value; }
        }

        public string MeasureUnitName {
            get { return measureunitname; }
            set { measureunitname = value; }
        }

        public decimal Lowerwarning
        {
            get { return lowerwarning; }
            set { lowerwarning = value; }
        }
        public decimal Loweraction
        {
            get { return loweraction; }
            set { loweraction = value; }
        }
        public string Llpmnum
        {
            get { return llpmnum; }
            set { llpmnum = value; }
        }
        public int Llpriority
        {
            get { return llpriority; }
            set { llpriority = value; }
        }
        public decimal Upperwarning
        {
            get { return upperwarning; }
            set { upperwarning = value; }
        }
        public decimal Upperaction
        {
            get { return upperaction; }
            set { upperaction = value; }
        }
        public string Ulpmnum
        {
            get { return ulpmnum; }
            set { ulpmnum = value; }
        }
        public int Ulpriority
        {
            get { return ulpriority; }
            set { ulpriority = value; }
        }
    }
}
