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
using PM.Entity;

namespace DBWinService {
    
    /// <summary>
    /// 数据整理服务
    /// </summary>
    public partial class DataReductionService : ServiceBase {    

        private System.Timers.Timer timer1 = null;    

        /// <summary>
        /// 构造类
        /// </summary>
        public DataReductionService() {
            InitializeComponent();
        }

        /// <summary>
        /// DEBUG调用
        /// </summary>
        public void OnDebug() {
            OnStart(null);  
        }

        /// <summary>
        /// 服务开始执行
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args) {
            EventLog.WriteEntry("Start MeasureSystem Data Service");
            WriteLog("Start MeasureSystem Data Service");
            timer1 = new System.Timers.Timer();
            this.timer1.Interval = Convert.ToDouble(3000); 
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStop() {

            EventLog.WriteEntry("Stop MeasureSystem Data Service");
            WriteLog("Stop MeasureSystem Data Service");  
            timer1.Stop();
        }

        /// <summary>
        /// 定义执行任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e) {

            int intHour = e.SignalTime.Hour;
            int intMinute = e.SignalTime.Minute;

            bool isExecute  = (intHour == 22 && intMinute == 46);

            //定时设置,判断分时秒,每天 定时执行
            if (isExecute)  
            {
                //System.Timers.Timer tt = (System.Timers.Timer)sender;
                timer1.Enabled = false;
                EventLog.WriteEntry("开始定时执行");

                //执行内容
                try {

                    DoMeasurementForHour();

                   // Thread.Sleep(2*60*1000);

                    DoMeasurementForDay();

                    DoMeasurementForMonth();


                   
                } catch (Exception err) {
                    WriteLog(err.ToString());
                }

                timer1.Enabled = true;
            } 

        }

        private void DoMeasurementForHour() {

            WriteLog("整理小时数据开始");

            PM.Business.Measurement.CreateMeasurementStatData(ReportType.Hour);
 
            WriteLog("整理小时数据结束");

        }

        private void DoMeasurementForDay() {

            WriteLog("整理每天数据开始");

            PM.Business.Measurement.CreateMeasurementStatData(ReportType.Day);

            WriteLog("整理每天数据结束");

        }

        private void DoMeasurementForMonth() {

            WriteLog("整理每月数据开始");

            PM.Business.Measurement.CreateMeasurementStatData(ReportType.Month);

            WriteLog("整理每月数据结束");

        }


        /// <summary>
        /// 写入操作日志
        /// </summary>
        /// <param name="content">日志内容</param>
        public void WriteLog(string content) {

            //日志文件保存在安装目录
            string filename = "ServiceLog.txt";
            if (!File.Exists(filename)) {
                File.Create(filename);
            }
            StreamWriter sw = new StreamWriter(filename, true, Encoding.Unicode);
            sw.WriteLine("事件：" + content + ",操作时间：" + System.DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
            sw.Close();
        }  

    }
}
