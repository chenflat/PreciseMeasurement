using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    [Serializable()]
    public class MeasurePointInfo
    {
        private long measurepointid;
        private string pointnum;
        private string pointcode;
        private string description;
        private int displaysequence;
        private string ipaddress;
        private string cardnum;
        private string devicenum;
        private string serverip;
        private int serverport;
        private string metername;
        private string orgid;
        private string orgname;
        private string siteid;
        private string location;
        private string carrier;
        private string supervisor;
        private string phone;
        private string status;
        private int level;

        public long Measurepointid
        {
            get { return measurepointid; }
            set { measurepointid = value; }
        }
        public string Pointnum
        {
            get { return pointnum; }
            set { pointnum = value; }
        }

        public string PointCode {
            get { return pointcode; }
            set { pointcode = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int Displaysequence
        {
            get { return displaysequence; }
            set { displaysequence = value; }
        }
        public string Ipaddress
        {
            get { return ipaddress; }
            set { ipaddress = value; }
        }
        public string Cardnum
        {
            get { return cardnum; }
            set { cardnum = value; }
        }
        public string Devicenum
        {
            get { return devicenum; }
            set { devicenum = value; }
        }
        public string Serverip
        {
            get { return serverip; }
            set { serverip = value; }
        }
        public int Serverport
        {
            get { return serverport; }
            set { serverport = value; }
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
        public string Orgname
        {
            get { return orgname; }
            set { orgname = value; }
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

        public string Carrier {
            get { return carrier; }
            set { carrier = value; }
        }

        public string Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

    }
}
