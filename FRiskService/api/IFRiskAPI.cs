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
		[WebInvoke(Method = "GET", UriTemplate = "/account", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		IList<Account> GetAccountList();

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/account/{id}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Account GetAccount(string id);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/account", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Account AddAccount(Account account);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/account", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Account UpdateAccount(Account account);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "/account/{id}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		bool DeleteAccount(string id);

		// -------------------------------------------

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/positionRisk/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		PositionRisk GetPositionRisk(string accountId, string instrumentId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/positionRisk", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		PositionRisk AddPositionRisk(PositionRisk param);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/positionRisk", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		PositionRisk UpdatePositionRisk(PositionRisk param);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "/positionRisk/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		bool DeletePositionRisk(string accountId, string instrumentId);

		// -------------------------------------------

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/trade/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Trade GetTrade(string accountId, string instrumentId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/trade", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Trade AddTrade(Trade param);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/trade", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Trade UpdateTrade(Trade param);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "/trade/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		bool DeleteTrade(string accountId, string instrumentId);

		// -------------------------------------------

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/security/{accountId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Security GetSecurity(string accountId);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/security/{accountId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		Security UpdateSecurity(string accountId, Security security);

		//[OperationContract]
		//[WebInvoke(Method = "GET", UriTemplate = "/dayRisk/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
		//			ResponseFormat = WebMessageFormat.Json)]
		//DayRisk GetDayRisk(string accountId, string instrumentId);

		//[OperationContract]
		//[WebInvoke(Method = "POST", UriTemplate = "/dayRisk", RequestFormat = WebMessageFormat.Json,
		//			ResponseFormat = WebMessageFormat.Json)]
		//DayRisk AddDayRisk(DayRisk param);

		//[OperationContract]
		//[WebInvoke(Method = "PUT", UriTemplate = "/dayRisk", RequestFormat = WebMessageFormat.Json,
		//			ResponseFormat = WebMessageFormat.Json)]
		//DayRisk UpdateDayRisk(DayRisk param);

		//[OperationContract]
		//[WebInvoke(Method = "DELETE", UriTemplate = "/dayRisk/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
		//			ResponseFormat = WebMessageFormat.Json)]
		//bool DeleteDayRisk(string accountId, string instrumentId);

		// -------------------------------------------

		[OperationContract]
		[WebInvoke(Method = "GET", UriTemplate = "/waveRisk/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		WaveRisk GetWaveRisk(string accountId, string instrumentId);

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "/waveRisk", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		WaveRisk AddWaveRisk(WaveRisk param);

		[OperationContract]
		[WebInvoke(Method = "PUT", UriTemplate = "/waveRisk", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		WaveRisk UpdateWaveRisk(WaveRisk param);

		[OperationContract]
		[WebInvoke(Method = "DELETE", UriTemplate = "/waveRisk/{accountId}/{instrumentId}", RequestFormat = WebMessageFormat.Json,
					ResponseFormat = WebMessageFormat.Json)]
		bool DeleteWaveRisk(string accountId, string instrumentId);
	}
}
