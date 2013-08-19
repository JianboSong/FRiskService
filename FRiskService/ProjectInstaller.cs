using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

// [Installing a managed service multiple times under different names](http://social.msdn.microsoft.com/Forums/vstudio/en-US/523b13d5-4f47-43b7-9dc3-77daef0e775d/installing-a-managed-service-multiple-times-under-different-names)
// http://www.bpsoftware.com/blog/post/2011/08/08/C-Set-ServiceName-using-an-Installation-Parameter.aspx
// [使用程序代码安装/卸载.net服务（不使用InstallUtil.exe）](http://blog.csdn.net/haukwong/article/details/7022961)

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

            //this.serviceInstaller1.ServiceName = "FRiskService";
            //this.serviceInstaller1.DisplayName = "风险控制服务器";
            //this.serviceInstaller1.ServiceName = Context.Parameters["name"];
            //this.serviceInstaller1.DisplayName = Context.Parameters["displayname"];
		}

        protected override void OnBeforeInstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeInstall(savedState);

            // Add steps to perform any actions before the install process.
            string name = Context.Parameters["name"];
            string displayname = Context.Parameters["displayname"];
            if (name != null)
            {
                this.serviceInstaller1.ServiceName = name;
                this.serviceInstaller1.DisplayName = displayname;
            }
            else
            {
                this.serviceInstaller1.ServiceName = "FRiskService";
                this.serviceInstaller1.DisplayName = "风险控制服务器";
            }
        }

        protected override void OnBeforeUninstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            string name = Context.Parameters["name"];
            if (name != null)
            {
                this.serviceInstaller1.ServiceName = name;
            }
            else
            {
                this.serviceInstaller1.ServiceName = "FRiskService";
            }
        }
	}
}
