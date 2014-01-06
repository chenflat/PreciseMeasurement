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

using System.Configuration;

namespace DBWinService {

    /// <summary>
    /// 数据整理服务
    /// </summary>
    public partial class DataReductionService : ServiceBase {

        private System.Timers.Timer timer = null;

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
            EventLog.WriteEntry("启动数据整理服务");

            Thread t = new Thread(new ThreadStart(this.InitTimer));
            t.Start();

        }


        private void InitTimer() {

            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(timer_Tick);
           // double timeInSeconds = 5.0;
            //每10分钟整理一次
            timer.Interval = (10 * 60 * 1000);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        /// <summary>
        /// 服务停止
        /// </summary>
        protected override void OnStop() {

           EventLog.WriteEntry("停止计量器监测系统数据整理服务");
           timer.Enabled = false;
           timer.Stop();
        }

        /// <summary>
        /// 定义执行任务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, System.Timers.ElapsedEventArgs e) {


            //从配置文件中读取更新日期
           // var updateTime = ConfigurationManager.AppSettings["UpdateTime"].ToString();
          //  if (updateTime == null || updateTime == "") {
            //    updateTime = "02:00";
            //}
            //当前时间
           // string currentTime = e.SignalTime.ToString("HH:mm");

            //比较时间，如果时间相等，则开始定时执行
            //bool isExecute = (updateTime == currentTime);
        

            //定时设置,判断分时秒,每天 定时执行
           // if (isExecute) {
                //执行内容
                try {
                    System.Timers.Timer tt = (System.Timers.Timer)sender;
                    tt.Enabled = false;
                    EventLog.WriteEntry("开始定时执行数据整理服务");
                   
                    DoMeasurementForHour();

                    DoMeasurementForDay();

                    DoMeasurementForMonth();

                    tt.Enabled = true;

                } catch (Exception err) {
                    EventLog.WriteEntry("执行数据整理服务异常：" + err, EventLogEntryType.Error);
                }
            //}

        }

        private void DoMeasurementForHour() {

            try {

                EventLog.WriteEntry("整理小时数据开始");

                PM.Business.Measurement.CreateMeasurementStatData(PM.Entity.ReportType.Hour);

                System.Threading.Thread.Sleep(3000);

                EventLog.WriteEntry("整理小时数据结束");

            } catch (Exception err) {
                EventLog.WriteEntry("整理小时数据异常：" + err, EventLogEntryType.Error);

            }
           

        }

        private void DoMeasurementForDay() {

            try {

                EventLog.WriteEntry("整理每天数据开始");

                PM.Business.Measurement.CreateMeasurementStatData(PM.Entity.ReportType.Day);

                System.Threading.Thread.Sleep(3000);

                EventLog.WriteEntry("整理每天数据结束");

            } catch (Exception err) {

                EventLog.WriteEntry("整理每天数据开始：" + err, EventLogEntryType.Error);

            }
           

        }

        private void DoMeasurementForMonth() {

            try {

                EventLog.WriteEntry("整理每月数据开始");

                PM.Business.Measurement.CreateMeasurementStatData(PM.Entity.ReportType.Month);

                System.Threading.Thread.Sleep(1000 * 2);

                EventLog.WriteEntry("整理每月数据结束");

            } catch (Exception err) {

                EventLog.WriteEntry("整理每月数据结束：" + err);
            }

          

        }

    }
}
