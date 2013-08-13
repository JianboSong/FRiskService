using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class Server
	{
		private string id;

		public string Id
		{
			get { return id; }
			set { id = value; }
		}

		private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		
		private string exchangeId;

		public string ExchangeId
		{
			get { return exchangeId; }
			set { exchangeId = value; }
		}

		private string brokerId;

		public string BrokerId
		{
			get { return brokerId; }
			set { brokerId = value; }
		}

		private string userId;

		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
		private string password;

		public string Password
		{
			get { return password; }
			set { password = value; }
		}

		private string tradeAddress;

		public string TradeAddress
		{
			get { return tradeAddress; }
			set { tradeAddress = value; }
		}
		private string marketAddress;

		public string MarketAddress
		{
			get { return marketAddress; }
			set { marketAddress = value; }
		}
	}
}
