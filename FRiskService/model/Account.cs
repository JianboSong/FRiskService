using System.Runtime.InteropServices;

namespace FRiskService.model
{
	[StructLayout(LayoutKind.Sequential)]
	public class Account
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

		private string instrumentId;

		public string InstrumentId
		{
			get { return instrumentId; }
			set { instrumentId = value; }
		}

		private string ownerPassword;

		public string OwnerPassword
		{
			get { return ownerPassword; }
			set { ownerPassword = value; }
		}

		private string teamPassword;

		public string TeamPassword
		{
			get { return teamPassword; }
			set { teamPassword = value; }
		}

		private string adminPassword;

		public string AdminPassword
		{
			get { return adminPassword; }
			set { adminPassword = value; }
		}

		private string operatorPassword;

		public string OperatorPassword
		{
			get { return operatorPassword; }
			set { operatorPassword = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double startMoney;
		public double StartMoney
		{
			get { return startMoney; }
			set { startMoney = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double totalLossRatio;
		public double TotalLossRatio
		{
			get { return totalLossRatio; }
			set { totalLossRatio = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double totalLossAmount;
		public double TotalLossAmount
		{
			get { return totalLossAmount; }
			set { totalLossAmount = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double minimalQuanyi;
		public double MinimalQuanyi
		{
			get { return minimalQuanyi; }
			set { minimalQuanyi = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double dayLossAmount;
		public double DayLossAmount
		{
			get { return dayLossAmount; }
			set { dayLossAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int dayLossTimes;
		public int DayLossTimes
		{
			get { return dayLossTimes; }
			set { dayLossTimes = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int stopMinutes;
		public int StopMinutes
		{
			get { return stopMinutes; }
			set { stopMinutes = value; }
		}

		[MarshalAs(UnmanagedType.LPStr)]
		private string stopTime;
		public string StopTime
		{
			get { return stopTime; }
			set { stopTime = value; }
		}
	}
}
