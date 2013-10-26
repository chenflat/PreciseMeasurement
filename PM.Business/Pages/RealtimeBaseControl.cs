using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;
using System.Data;

namespace PM.Business.Pages
{


    public class RealtimeBaseControl : System.Web.UI.UserControl
    {

        private MeasurePointInfo measurePointInfo;

        /// <summary>
        /// 计量点基本信息
        /// </summary>
        public MeasurePointInfo MeasurePointInfo
        {
            get { return measurePointInfo; }
            set { measurePointInfo = value; }
        }


       
    }

    public enum QueryType { 
        MINUTE,HOUR,DAY,HISTORY
    }

}
