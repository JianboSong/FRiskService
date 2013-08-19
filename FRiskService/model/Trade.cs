
using System.Runtime.InteropServices;
namespace FRiskService.model
{
	[StructLayout(LayoutKind.Sequential)]
	public class Trade
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 37)]
		private string accountId;
		public string AccountId
		{
			get { return accountId; }
			set { accountId = value; }
		}

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 31)]
		private string instrumentId;
		public string InstrumentId
		{
			get { return instrumentId; }
			set { instrumentId = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int volumeMultiple;
		public int VolumeMultiple
		{
			get { return volumeMultiple; }
			set { volumeMultiple = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double priceTick;
		public double PriceTick
		{
			get { return priceTick; }
			set { priceTick = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double openRatioByMoney;
		public double OpenRatioByMoney
		{
			get { return openRatioByMoney; }
			set { openRatioByMoney = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double closeRatioByMoney;
		public double CloseRatioByMoney
		{
			get { return closeRatioByMoney; }
			set { closeRatioByMoney = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double closeTodayRatioByMoney;
		public double CloseTodayRatioByMoney
		{
			get { return closeTodayRatioByMoney; }
			set { closeTodayRatioByMoney = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int defaultVolume;
		public int DefaultVolume
		{
			get { return defaultVolume; }
			set { defaultVolume = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int buyStopPoint;
		public int BuyStopPoint
		{
			get { return buyStopPoint; }
			set { buyStopPoint = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int buyAddPoint;
		public int BuyAddPoint
		{
			get { return buyAddPoint; }
			set { buyAddPoint = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int sellStopPoint;
		public int SellStopPoint
		{
			get { return sellStopPoint; }
			set { sellStopPoint = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int sellAddPoint;
		public int SellAddPoint
		{
			get { return sellAddPoint; }
			set { sellAddPoint = value; }
		}

		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 9)]
		private string tradingDay;
		public string TradingDay
		{
			get { return tradingDay; }
			set { tradingDay = value; }
		}
	}
}
