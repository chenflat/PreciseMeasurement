using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace DBWinService {
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer {
        public ProjectInstaller() {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState) {
            base.Commit(savedState);
            //Auot start service after the installation is completed
            ServiceController sc = new ServiceController("DataReductionService");
            if (sc.Status.Equals(ServiceControllerStatus.Stopped)) {
                sc.Start();
            }
        }
    }
}
