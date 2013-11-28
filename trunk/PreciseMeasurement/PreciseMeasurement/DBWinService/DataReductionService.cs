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
using System.Configuration;

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
            EventLog.WriteEntry("启动计量器监测系统数据整理服务");
            timer1 = new System.Timers.Timer();
            this.timer1.Interval = Convert.ToDouble(2000);
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            timer1.AutoReset = true;
            timer1.Enabled = true;
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStop() {

            EventLog.WriteEntry("停止计量器监测系统数据整理服务");
            timer1.Stop();
        }

        /// <summary>
        /// 定义执行任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, System.Timers.ElapsedEventArgs e) {

            //int intHour = e.SignalTime.Hour;
            //int intMinute = e.SignalTime.Minute;
            //bool isExecute = (intHour == 10 && intMinute == 0);

            //从配置文件中读取更新日期
            var updateTime = ConfigurationManager.AppSettings["UpdateTime"].ToString();
            if (updateTime == null || updateTime == "") {
                updateTime = "02:00";
            }
            //当前时间
            string currentTime = e.SignalTime.ToString("HH:mm");

            //比较时间，如果时间相等，则开始定时执行
            bool isExecute = (updateTime == currentTime);
        

            //定时设置,判断分时秒,每天 定时执行
            if (isExecute) {
                //执行内容
                try {
                    System.Timers.Timer tt = (System.Timers.Timer)sender;
                    tt.Enabled = false;
                    EventLog.WriteEntry("开始定时执行计量器监测系统数据整理服务");
                   
                    DoMeasurementForHour();

                    DoMeasurementForDay();

                    DoMeasurementForMonth();

                    System.Threading.Thread.Sleep(3000);
                    tt.Enabled = true;

                } catch (Exception err) {
                    EventLog.WriteEntry("执行计量器监测数据整理服务异常：" + err);
                    WriteLog(err.ToString());
                }
            }

        }

        private void DoMeasurementForHour() {

            try {

                EventLog.WriteEntry("整理小时数据开始");

                PM.Business.Measurement.CreateMeasurementStatData(ReportType.Hour);
                System.Threading.Thread.Sleep(3000);

                EventLog.WriteEntry("整理小时数据结束");

            } catch (Exception err) {
                EventLog.WriteEntry("整理小时数据异常：" + err);

            }
           

        }

        private void DoMeasurementForDay() {

            try {

                EventLog.WriteEntry("整理每天数据开始");

                PM.Business.Measurement.CreateMeasurementStatData(ReportType.Day);

                System.Threading.Thread.Sleep(3000);

                EventLog.WriteEntry("整理每天数据结束");

            } catch (Exception err) {

                EventLog.WriteEntry("整理每天数据开始：" + err);

            }
           

        }

        private void DoMeasurementForMonth() {

            try {

                EventLog.WriteEntry("整理每月数据开始");

                PM.Business.Measurement.CreateMeasurementStatData(ReportType.Month);

                System.Threading.Thread.Sleep(1000 * 2);

                EventLog.WriteEntry("整理每月数据结束");

            } catch (Exception err) {

                EventLog.WriteEntry("整理每月数据结束：" + err);
            }

          

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
            //StreamWriter sw = new StreamWriter(filename, true, Encoding.Unicode);
            //sw.WriteLine("事件：" + content + ",操作时间：" + System.DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
            //sw.Close();
        }

    }
}
