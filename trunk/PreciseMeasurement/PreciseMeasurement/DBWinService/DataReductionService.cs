using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.IO;
using PM.Data;
using PM.Entity;
using System.Threading;

namespace DBWinService {
    public partial class DataReductionService : ServiceBase {    //declaration

        private System.Timers.Timer timer1 = null;    //declaration

        public DataReductionService() {
            InitializeComponent();
        }

        public void OnDebug() {
            OnStart(null);  
        }

        protected override void OnStart(string[] args) {
            EventLog.WriteEntry("Start MeasureSystem Data Service");
            WriteLog("Start MeasureSystem Data Service");
            timer1 = new System.Timers.Timer();
            this.timer1.Interval = Convert.ToDouble(3*1000); 
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }

        protected override void OnStop() {

            EventLog.WriteEntry("Stop MeasureSystem Data Service");
            WriteLog("Stop MeasureSystem Data Service");  
            timer1.Stop();
        }


        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e) {

            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;
            int intSecond = e.SignalTime.Second;

            if (intHour == 14 && intMinute == 06 && intSecond == 00) ///定时设置,判断分时秒  
            {
                try {
                    System.Timers.Timer tt = (System.Timers.Timer)sender;
                    tt.Enabled = false;

                    DoMeasurementForHour();

                    Thread.Sleep(10000);

                    DoMeasurementForDay();

                    Thread.Sleep(10000);

                    DoMeasurementForMonth();

                    Thread.Sleep(10000);
     
                    tt.Enabled = true;
                } catch (Exception err) {
                    
                }
            } 

        }


        private void DoMeasurementForHour() {
            string endDate = "";
            PM.Data.Measurement measurement = new PM.Data.Measurement();
            measurement.CreateMeasurementStatData("2013-11-24 00:00:00", endDate, ReportType.Hour);
        
        }

        private void DoMeasurementForDay() {
            //string startDate = "2013-09-07 00:00:00";
            string endDate = "";
            PM.Data.Measurement measurement = new PM.Data.Measurement();
            measurement.CreateMeasurementStatData("2013-11-24 00:00:00", endDate, ReportType.Day);
        }

        private void DoMeasurementForMonth() {
            string endDate = "";
            PM.Data.Measurement measurement = new PM.Data.Measurement();
            measurement.CreateMeasurementStatData("2013-11-24 00:00:00", endDate, ReportType.Month);
        }

        public static void SetTimeout(double interval, Action action) {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e) {
                timer.Enabled = false;
                action();
            };
            timer.Enabled = true;
        }  

        public void WriteLog(string content) {
            //debug==================================================  
            //StreamWriter dout = new StreamWriter(@"c:/" + System.DateTime.Now.ToString("yyyMMddHHmmss") + ".txt");  
            StreamWriter dout = new StreamWriter(@"c:/" + "MeasureSystemWindowServiceLog.txt", true);
            dout.Write("/r/n事件：" + content + "/r/n操作时间：" + System.DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
            //debug==================================================  
            dout.Close();
        }  

    }
}
