using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    /// <summary>
    /// 组织机构
    /// </summary>
    public class OrganizationInfo
    {
        [Serializable()]
        private long organizationid = 0;
        private string orgid;
        private string description;
        private string orgtype;
        private int level = 0;
        private string comments;
        private string leader;
        private string phone;
        private string address;
        private string parent;

        public long Organizationid
        {
            get { return organizationid; }
            set { organizationid = value; }
        }

        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Orgtype
        {
            get { return orgtype; }
            set { orgtype = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }
        public string Leader
        {
            get { return leader; }
            set { leader = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Parent
        {
            get { return parent; }
            set { parent = value; }
        }


        public bool isnew {
            get {
                if (organizationid == 0) {
                    return true;
                }
                return false;
            }
        }


    }
}
