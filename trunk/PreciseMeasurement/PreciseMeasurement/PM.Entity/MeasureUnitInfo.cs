using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    public class MeasureUnitInfo
    {
        private long measureunituid;
        private string contentuid;

        private string measureunitid;
        private string description;
        private string abbreviation;
        private int displaysequence;
        private bool isCalculate;
        private bool visabled;
        private bool isMainParam;
        private string type;
        private string orgid;
        private string siteid;

        public long Measureunituid
        {
            get { return measureunituid; }
            set { measureunituid = value; }
        }
        public string Contentuid
        {
            get { return contentuid; }
            set { contentuid = value; }
        }
        public string Measureunitid
        {
            get { return measureunitid; }
            set { measureunitid = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Abbreviation
        {
            get { return abbreviation; }
            set { abbreviation = value; }
        }
        public int Displaysequence
        {
            get { return displaysequence; }
            set { displaysequence = value; }
        }

        public bool IsCalculate
        {
            get { return isCalculate; }
            set { isCalculate = value; }
        }

        public bool Visabled
        {
            get { return visabled; }
            set { visabled = value; }
        }

        public bool IsMainParam
        {
            get { return isMainParam; }
            set { isMainParam = value; }
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

        public string Type {
            get { return type; }
            set { type = value; }
        }
    }
}
