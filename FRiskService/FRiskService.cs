using System;
using System.Configuration;
using System.ServiceModel.Web;
using System.ServiceProcess;

using FRiskService.api;
using FRiskService.impl;

namespace FRiskService
{
	public partial class FRiskService : ServiceBase
	{
		IFRiskAPI server;

		WebServiceHost _serviceHost;

		public FRiskService()
		{
			InitializeComponent();

			this.CanStop = true;
			this.ExitCode = 0;
		}

		protected override void OnStart(string[] args)
		{
			this.server = new FRiskAPI();
			_serviceHost = new WebServiceHost(this.server.GetType(), new Uri(ConfigurationManager.AppSettings["serviceEndPoint"]));

			try
			{
				_serviceHost.Open();
			}
			catch (Exception e)
			{	
				throw e;
			}
		}

		protected override void OnStop()
		{
			_serviceHost.Close();
		}
	}
}
