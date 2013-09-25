using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    public class MeasurePointParamInfo
    {
        private int measurepointparamuid;
        private string pointnum;
        private string measureunitid;
        private decimal lowerwarning;
        private decimal loweraction;
        private string llpmnum;
        private int llpriority;
        private decimal upperwarning;
        private decimal upperaction;
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

        public string Measureunitid
        {
            get { return measureunitid; }
            set { measureunitid = value; }
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
