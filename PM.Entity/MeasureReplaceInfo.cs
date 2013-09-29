using System;
using System.Collections.Generic;
using System.Text;

namespace PM.Entity
{
    public class MeasureReplaceInfo
    {
        private long measuretransid;
        private string pointnum;
        private string measureunitid;
        private string measureunitname;
        private decimal measurementvalue;
        private string enterby;
        private DateTime enterdate = DateTime.Now;
        private string topointnum;
        private decimal tomeasurementvalue;
        private decimal correctedvalue;
        private string fromdept;
        private string fromloc;
        private string replaceperson;
        private DateTime replacedate =  DateTime.Now;
        private string replacetype;
        private string memo;
        private string status;
        private string orgid;
        private string siteid;

        /// <summary>
        /// 唯一标识
        /// </summary>
        public long Measuretransid
        {
            get { return measuretransid; }
            set { measuretransid = value; }
        }
        /// <summary>
        /// 更换的计量点
        /// </summary>
        public string Pointnum
        {
            get { return pointnum; }
            set { pointnum = value; }
        }

        /// <summary>
        /// 参量编号
        /// </summary>
        public string MeasureunitId {
            get { return measureunitid; }
            set { measureunitid = value; }
        }

        /// <summary>
        /// 参量名称
        /// </summary>
        public string MeasureunitName
        {
            get { return measureunitname; }
            set { measureunitname = value; }
        }

        /// <summary>
        /// 换表前读数
        /// </summary>
        public decimal MeasurementValue
        {
            get { return measurementvalue; }
            set { measurementvalue = value; }
        }

       

        /// <summary>
        /// 记录人
        /// </summary>
        public string EnterBy
        {
            get { return enterby; }
            set { enterby = value; }
        }
        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime EnterDate
        {
            get { return enterdate; }
            set { enterdate = value; }
        }
        /// <summary>
        /// 更换后的计量点
        /// </summary>
        public string ToPointnum
        {
            get { return topointnum; }
            set { topointnum = value; }
        }
        /// <summary>
        /// 新表读数
        /// </summary>
        public decimal ToMeasurementValue
        {
            get { return tomeasurementvalue; }
            set { tomeasurementvalue = value; }
        }

        /// <summary>
        /// 修正值
        /// </summary>
        public decimal CorrectedValue {
            get { return correctedvalue; }
            set { correctedvalue = value; }
        }

        /// <summary>
        /// 更换部门
        /// </summary>
        public string FromDept
        {
            get { return fromdept; }
            set { fromdept = value; }
        }
        /// <summary>
        /// 更换的位置
        /// </summary>
        public string FromLoc
        {
            get { return fromloc; }
            set { fromloc = value; }
        }

        /// <summary>
        /// 换表人
        /// </summary>
        public string ReplacePerson {

            get { return replaceperson; }
            set { replaceperson = value; }
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
        /// <summary>
        /// 备注
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        public string Status {
            get { return status; }
            set { status = value; }
        }

        /// <summary>
        /// 机构ID
        /// </summary>
        public string Orgid
        {
            get { return orgid; }
            set { orgid = value; }
        }

        /// <summary>
        /// 站点
        /// </summary>
        public string Siteid
        {
            get { return siteid; }
            set { siteid = value; }
        }
    }
}
