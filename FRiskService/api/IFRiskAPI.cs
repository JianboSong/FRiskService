using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

using FRiskService.model;

namespace FRiskService.api
{
	[ServiceContract(Name = "Server")]
	public interface IFRiskAPI
	{
		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/servers", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		IList<Server> GetServerList();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/server/{id}", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		Server GetServer(string id);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/server", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		Server AddServer(Server server);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/server", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		Server UpdateServer(Server server);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "/server/{id}", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		bool DeleteServer(string id);


		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/security/{type}", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		string GetPassword(string type);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/security/{type}/{password}", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		string UpdatePassword(string type, string password);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/trade", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		Trade GetTrade();

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/trade", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		Trade UpdateTrade(Trade param);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/accountRisk", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		AccountRisk GetAccountRisk();

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/accountRisk", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		AccountRisk UpdateAccountRisk(AccountRisk param);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/dayRisk", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		DayRisk GetDayRisk();

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/dayRisk", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		DayRisk UpdateDayRisk(DayRisk param);

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/waveRisk", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		WaveRisk GetWaveRisk();

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/waveRisk", RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		WaveRisk UpdateWaveRisk(WaveRisk param);
	}
}
