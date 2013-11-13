using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace DBService
{
    /// <summary>
    /// 数据库整理服务
    /// </summary>
    public partial class DataReductionService : ServiceBase
    {
        public DataReductionService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
