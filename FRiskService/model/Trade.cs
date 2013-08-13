
namespace FRiskService.model
{
	public class Trade
	{
		private string instrumentID;

		public string InstrumentID
		{
			get { return instrumentID; }
			set { instrumentID = value; }
		}

		private int volumeMultiple;

		public int VolumeMultiple
		{
			get { return volumeMultiple; }
			set { volumeMultiple = value; }
		}

		private double priceTick;

		public double PriceTick
		{
			get { return priceTick; }
			set { priceTick = value; }
		}

		private double openRatioByMoney;

		public double OpenRatioByMoney
		{
			get { return openRatioByMoney; }
			set { openRatioByMoney = value; }
		}

		private double closeRatioByMoney;

		public double CloseRatioByMoney
		{
			get { return closeRatioByMoney; }
			set { closeRatioByMoney = value; }
		}

		private double closeTodayRatioByMoney;

		public double CloseTodayRatioByMoney
		{
			get { return closeTodayRatioByMoney; }
			set { closeTodayRatioByMoney = value; }
		}

		private int defaultVolume;

		public int DefaultVolume
		{
			get { return defaultVolume; }
			set { defaultVolume = value; }
		}

		private int buyStopPoint;

		public int BuyStopPoint
		{
			get { return buyStopPoint; }
			set { buyStopPoint = value; }
		}

		private int buyAddPoint;

		public int BuyAddPoint
		{
			get { return buyAddPoint; }
			set { buyAddPoint = value; }
		}
		private int sellStopPoint;

		public int SellStopPoint
		{
			get { return sellStopPoint; }
			set { sellStopPoint = value; }
		}
		private int sellAddPoint;

		public int SellAddPoint
		{
			get { return sellAddPoint; }
			set { sellAddPoint = value; }
		}
	}
}
