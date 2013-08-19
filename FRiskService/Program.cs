using System;
using System.IO;
using System.Reflection;
using System.ServiceProcess;

namespace FRiskService
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			Global.connstr = string.Format(@"Data Source={0}", Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "config"));

			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[] 
			{ 
				new FRiskService() 
			};
			ServiceBase.Run(ServicesToRun);
			
			//IFRiskAPI server = new FRiskAPI();;
			//WebServiceHost _serviceHost = new WebServiceHost(server.GetType(), new Uri(ConfigurationManager.AppSettings["serviceEndPoint"]));
			//try
			//{
			//	_serviceHost.Open();
			//}
			//catch (Exception e)
			//{
			//	throw e;
			//}
			//while (true) ;
		}
	}
}
