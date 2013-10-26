using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using PM.Common;
using PM.Business;
using PM.Entity;
using PM.Business.Pages;

namespace PM.Web.realtime
{
    public partial class MeasurePointBaseInfo : RealtimeBaseControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               setMeasureMeasurePointInfo();
            }


        }

        private void setMeasureMeasurePointInfo()
        {
            if (MeasurePointInfo == null)
                return;
            ltDescription.Text = MeasurePointInfo.Description; ;
            description.Text = MeasurePointInfo.Description;
            pointcode.Text = MeasurePointInfo.PointCode;
            pointnum.Text = MeasurePointInfo.Pointnum;
            carrier.Text = MeasurePointInfo.Carrier;
            supervisor.Text = MeasurePointInfo.Supervisor;
            phone.Text = MeasurePointInfo.Phone;
            ddlOrgid.Text = MeasurePointInfo.Orgid;
            location.Text = MeasurePointInfo.Location;
            ipaddress.Text = MeasurePointInfo.Ipaddress;
            cardnum.Text = MeasurePointInfo.Cardnum;
            devicenum.Text = MeasurePointInfo.Devicenum;
            serverip.Text = MeasurePointInfo.Serverip;
            serverport.Text = MeasurePointInfo.Serverport.ToString();
            displaysequence.Text = MeasurePointInfo.Displaysequence.ToString();


        }



    }
}