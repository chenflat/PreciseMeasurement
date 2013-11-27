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
using System.Threading;
using PM.Data;
using PM.Entity;

namespace DBWinService {
    public partial class DataReductionService : ServiceBase {    

        private System.Timers.Timer timer1 = null;    

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

            if (intHour == 15 && intMinute == 21 && intSecond == 00) ///定时设置,判断分时秒  
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

        private string startdate = "2013-11-19 00:00:00";
        private string endDate = "2013-11-23 00:00:00";
        private void DoMeasurementForHour() {
           
            PM.Data.Measurement measurement = new PM.Data.Measurement();
            measurement.CreateMeasurementStatData(startdate, endDate, ReportType.Hour);
        
        }

        private void DoMeasurementForDay() {
            PM.Data.Measurement measurement = new PM.Data.Measurement();
            measurement.CreateMeasurementStatData(startdate, endDate, ReportType.Day);
        }

        private void DoMeasurementForMonth() {
            PM.Data.Measurement measurement = new PM.Data.Measurement();
            measurement.CreateMeasurementStatData(startdate, endDate, ReportType.Month);
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
            string filename = "ServiceLog.txt";
            if (!File.Exists(filename)) {
                File.Create(filename);
            }

            StreamWriter sw = new StreamWriter(filename, true, Encoding.Unicode);
            sw.WriteLine("事件：" + content + ",操作时间：" + System.DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
            //debug==================================================  
            sw.Close();
        }  

    }
}
