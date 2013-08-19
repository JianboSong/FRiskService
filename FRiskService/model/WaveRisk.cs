using System.Runtime.InteropServices;

namespace FRiskService.model
{
	[StructLayout(LayoutKind.Sequential)]
	public class WaveRisk
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

		[MarshalAs(UnmanagedType.R8)]
		private double spread;
		public double Spread
		{
			get { return spread; }
			set { spread = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallEnable;
		public int SmallEnable
		{
			get { return smallEnable; }
			set { smallEnable = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallRepeat;
		public int SmallRepeat
		{
			get { return smallRepeat; }
			set { smallRepeat = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double smallFullAmount;
		public double SmallFullAmount
		{
			get { return smallFullAmount; }
			set { smallFullAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallFullTimes;
		public int SmallFullTimes
		{
			get { return smallFullTimes; }
			set { smallFullTimes = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double smallPartialBuyAmount;
		public double SmallPartialBuyAmount
		{
			get { return smallPartialBuyAmount; }
			set { smallPartialBuyAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallPartialBuyTimes;
		public int SmallPartialBuyTimes
		{
			get { return smallPartialBuyTimes; }
			set { smallPartialBuyTimes = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double smallPartialSellAmount;
		public double SmallPartialSellAmount
		{
			get { return smallPartialSellAmount; }
			set { smallPartialSellAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallPartialSellTimes;
		public int SmallPartialSellTimes
		{
			get { return smallPartialSellTimes; }
			set { smallPartialSellTimes = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double smallUnlockCase1Ratio1;
		public double SmallUnlockCase1Ratio1
		{
			get { return smallUnlockCase1Ratio1; }
			set { smallUnlockCase1Ratio1 = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double smallUnlockCase2Ratio2;
		public double SmallUnlockCase2Ratio2
		{
			get { return smallUnlockCase2Ratio2; }
			set { smallUnlockCase2Ratio2 = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallUnlockCase2Times;
		public int SmallUnlockCase2Times
		{
			get { return smallUnlockCase2Times; }
			set { smallUnlockCase2Times = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int smallUnlockCase3NRecord;
		public int SmallUnlockCase3NRecord
		{
			get { return smallUnlockCase3NRecord; }
			set { smallUnlockCase3NRecord = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double smallUnlockCase3DiffValue;
		public double SmallUnlockCase3DiffValue
		{
			get { return smallUnlockCase3DiffValue; }
			set { smallUnlockCase3DiffValue = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int bigEnable;
		public int BigEnable
		{
			get { return bigEnable; }
			set { bigEnable = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int bigRepeat;
		public int BigRepeat
		{
			get { return bigRepeat; }
			set { bigRepeat = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double bigFullAmount;
		public double BigFullAmount
		{
			get { return bigFullAmount; }
			set { bigFullAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int bigFullTimes;
		public int BigFullTimes
		{
			get { return bigFullTimes; }
			set { bigFullTimes = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double bigPartialBuyAmount;
		public double BigPartialBuyAmount
		{
			get { return bigPartialBuyAmount; }
			set { bigPartialBuyAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int bigPartialBuyTimes;
		public int BigPartialBuyTimes
		{
			get { return bigPartialBuyTimes; }
			set { bigPartialBuyTimes = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double bigPartialSellAmount;
		public double BigPartialSellAmount
		{
			get { return bigPartialSellAmount; }
			set { bigPartialSellAmount = value; }
		}

		[MarshalAs(UnmanagedType.I4)]
		private int bigPartialSellTimes;
		public int BigPartialSellTimes
		{
			get { return bigPartialSellTimes; }
			set { bigPartialSellTimes = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double bigUnlockCase1DiffPrice;
		public double BigUnlockCase1DiffPrice
		{
			get { return bigUnlockCase1DiffPrice; }
			set { bigUnlockCase1DiffPrice = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double bigUnlockCase2Multiple;
		public double BigUnlockCase2Multiple
		{
			get { return bigUnlockCase2Multiple; }
			set { bigUnlockCase2Multiple = value; }
		}

		[MarshalAs(UnmanagedType.R8)]
		private double bigUnlockCase2DiffPrice;
		public double BigUnlockCase2DiffPrice
		{
			get { return bigUnlockCase2DiffPrice; }
			set { bigUnlockCase2DiffPrice = value; }
		}
	}
}
