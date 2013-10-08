using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    [Serializable()]
    public class UserInfo
    {
        private int userid;
        private string username;
        private string password;
        private bool enabled;
        private DateTime createddate;
        private DateTime modifieddate;
        private int passwordencrypted;
        private DateTime passwordmodifieddate;
        private string realname;
        private string displayname;
        private string digest;
        private string emailaddress;
        private string reminderqueryquestion;
        private string reminderqueryanswer;
        private string timezone;
        private string language;
        private string greeting;
        private string website;
        private string jobtitle;
        private string comments;
        private string significantother;
        private DateTime birthday = DateTime.Now;
        private DateTime anniversary;
        private DateTime logindate = DateTime.Now;
        private string loginip;
        private DateTime lastlogindate;
        private string lastloginip;
        private bool issuperuser;
        private string orgid;
        private string orgname;
        private string sex;
        private string workphone;
        private string workmobile;
        private string phone;
        private string mobile;
        private string address;
        private string status = "ACTIVE";

        public int UserId
        {
            get { return userid; }
            set { userid = value; }
        }


        public string UserName {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }


        public DateTime CreatedDate
        {
            get { return createddate; }
            set { createddate = value; }
        }

        public DateTime ModifiedDate
        {
            get { return modifieddate; }
            set { modifieddate = value; }
        }

        public int PasswordEncrypted
        {
            get { return passwordencrypted; }
            set { passwordencrypted = value; }
        }

        public DateTime PasswordModifiedDate
        {
            get { return passwordmodifieddate; }
            set { passwordmodifieddate = value; }
        }


        public string Realname
        {
            get { return realname; }
            set { realname = value; }
        }

        public string Displayname
        {
            get { return displayname; }
            set { displayname = value; }
        }

        public string Digest
        {
            get { return digest; }
            set { digest = value; }
        }

        public string EmailAddress
        {
            get { return emailaddress; }
            set { emailaddress = value; }
        }

        public string ReminderQueryQuestion
        {
            get { return reminderqueryquestion; }
            set { reminderqueryquestion = value; }
        }


        public string ReminderQueryAnswer
        {
            get { return reminderqueryanswer; }
            set { reminderqueryanswer = value; }
        }

        public string TimeZone
        {
            get { return timezone; }
            set { timezone = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public string Greeting
        {
            get { return greeting; }
            set { greeting = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public string Jobtitle
        {
            get { return jobtitle; }
            set { jobtitle = value; }
        }

        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        public string Significantother
        {
            get { return significantother; }
            set { significantother = value; }
        }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        /// <summary>
        /// 纪念日
        /// </summary>
        public DateTime Anniversary
        {
            get { return anniversary; }
            set { anniversary = value; }
        }

        /// <summary>
        /// 首次登陆
        /// </summary>
        public DateTime LoginDate
        {
            get { return logindate; }
            set { logindate = value; }
        }
        /// <summary>
        /// 首次登陆
        /// </summary>
        public string LoginIp
        {
            get { return loginip; }
            set { loginip = value; }
        }


        /// <summary>
        /// 最后登陆日期
        /// </summary>
        public DateTime LastLoginDate
        {
            get { return lastlogindate; }
            set { lastlogindate = value; }
        }
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        public string LastLoginIp
        {
            get { return lastloginip; }
            set { lastloginip = value; }
        }

        /// <summary>
        /// 是否超级用户
        /// </summary>
        public bool IsSuperuser
        {
            get { return issuperuser; }
            set { issuperuser = value; }

        }

        /// <summary>
        /// 组织机构
        /// </summary>
        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }

        /// <summary>
        /// 组织机构名称
        /// </summary>
        public string OrgName {
            get { return orgname; }
            set { orgname = value; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// 办公电话
        /// </summary>
        public string WorkPhone
        {
            get { return workphone; }
            set { workphone = value; }
        }

        /// <summary>
        /// 办公移动电话
        /// </summary>
        public string WorkMobile
        {
            get { return workmobile; }
            set { workmobile = value; }
        }


        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        /// <summary>
        /// 状态  ACTIVE\INACTIVE\DELETED
        /// </summary>
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


    }
}
