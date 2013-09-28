using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 位置信息
    /// </summary>
    public class LocationInfo
    {
        private long locationsid;
        private string location;
        private string description;
        private string type;
        private bool disabled;
        private string externalrefid;
        private bool isrepairfacility;
        private string x;
        private string y;
        private string z;
        private string orgid;
        private string ownersysid;
        private string sendersysid;
        private string serviceaddresscode;
        private string siteid;
        private string sourcesysid;
        private string status;
        private DateTime statusdate;
        private string changeby;
        private DateTime changedate = DateTime.Now;

        private string parent;
        private bool children;
        private int level;


        public long Locationsid
        {
            get { return locationsid; }
            set { locationsid = value; }
        }
        public string Location
        {
            get { return location; }
            set { location = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        public bool Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }
        public string Externalrefid
        {
            get { return externalrefid; }
            set { externalrefid = value; }
        }
        public bool Isrepairfacility
        {
            get { return isrepairfacility; }
            set { isrepairfacility = value; }
        }

        public string X {
            get { return x; }
            set { x = value; }
        }

        public string Y
        {
            get { return y; }
            set { y = value; }
        }

        public string Z
        {
            get { return z; }
            set { z = value; }
        }

        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }
        public string Ownersysid
        {
            get { return ownersysid; }
            set { ownersysid = value; }
        }
        public string Sendersysid
        {
            get { return sendersysid; }
            set { sendersysid = value; }
        }
        public string Serviceaddresscode
        {
            get { return serviceaddresscode; }
            set { serviceaddresscode = value; }
        }
        public string Siteid
        {
            get { return siteid; }
            set { siteid = value; }
        }
        public string Sourcesysid
        {
            get { return sourcesysid; }
            set { sourcesysid = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        public DateTime Statusdate
        {
            get { return statusdate; }
            set { statusdate = value; }
        }
        public string Changeby
        {
            get { return changeby; }
            set { changeby = value; }
        }
        public DateTime Changedate
        {
            get { return changedate; }
            set { changedate = value; }
        }

        /// <summary>
        /// 本位置的父级
        /// </summary>
        public string Parent {
            get { return parent; }
            set { parent = value; }
        }

        /// <summary>
        /// 是否有有子级
        /// </summary>
        public bool Children {
            get { return children; }
            set { children = value; }
        }

        /// <summary>
        /// 层级
        /// </summary>
        public int Level {
            get { return level; }
            set { level = value; }
        }
    }
}
