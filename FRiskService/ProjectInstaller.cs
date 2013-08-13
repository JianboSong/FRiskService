using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace FRiskService
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : System.Configuration.Install.Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();

			//this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalService;
			this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			//this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.User;

			this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;

			this.serviceInstaller1.ServiceName = "FRiskService";
			this.serviceInstaller1.DisplayName = "风险控制服务器";
		}
	}
}
