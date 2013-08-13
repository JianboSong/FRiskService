using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class WaveRisk
	{
		private double spread;

		public double Spread
		{
			get { return spread; }
			set { spread = value; }
		}

		private int smallEnable;

		public int SmallEnable
		{
			get { return smallEnable; }
			set { smallEnable = value; }
		}

		private int smallRepeat;

		public int SmallRepeat
		{
			get { return smallRepeat; }
			set { smallRepeat = value; }
		}

		private double smallFullAmount;

		public double SmallFullAmount
		{
			get { return smallFullAmount; }
			set { smallFullAmount = value; }
		}

		private int smallFullTimes;

		public int SmallFullTimes
		{
			get { return smallFullTimes; }
			set { smallFullTimes = value; }
		}

		private double smallPartialBuyAmount;

		public double SmallPartialBuyAmount
		{
			get { return smallPartialBuyAmount; }
			set { smallPartialBuyAmount = value; }
		}

		private int smallPartialBuyTimes;

		public int SmallPartialBuyTimes
		{
			get { return smallPartialBuyTimes; }
			set { smallPartialBuyTimes = value; }
		}

		private double smallPartialSellAmount;

		public double SmallPartialSellAmount
		{
			get { return smallPartialSellAmount; }
			set { smallPartialSellAmount = value; }
		}

		private int smallPartialSellTimes;

		public int SmallPartialSellTimes
		{
			get { return smallPartialSellTimes; }
			set { smallPartialSellTimes = value; }
		}

		private double smallUnlockCase1Ratio1;

		public double SmallUnlockCase1Ratio1
		{
			get { return smallUnlockCase1Ratio1; }
			set { smallUnlockCase1Ratio1 = value; }
		}

		private double smallUnlockCase2Ratio2;

		public double SmallUnlockCase2Ratio2
		{
			get { return smallUnlockCase2Ratio2; }
			set { smallUnlockCase2Ratio2 = value; }
		}

		private int smallUnlockCase2Times;

		public int SmallUnlockCase2Times
		{
			get { return smallUnlockCase2Times; }
			set { smallUnlockCase2Times = value; }
		}

		private int smallUnlockCase3NRecord;

		public int SmallUnlockCase3NRecord
		{
			get { return smallUnlockCase3NRecord; }
			set { smallUnlockCase3NRecord = value; }
		}

		private double smallUnlockCase3DiffValue;

		public double SmallUnlockCase3DiffValue
		{
			get { return smallUnlockCase3DiffValue; }
			set { smallUnlockCase3DiffValue = value; }
		}

		private int bigEnable;

		public int BigEnable
		{
			get { return bigEnable; }
			set { bigEnable = value; }
		}

		private int bigRepeat;

		public int BigRepeat
		{
			get { return bigRepeat; }
			set { bigRepeat = value; }
		}

		private double bigFullAmount;

		public double BigFullAmount
		{
			get { return bigFullAmount; }
			set { bigFullAmount = value; }
		}

		private int bigFullTimes;

		public int BigFullTimes
		{
			get { return bigFullTimes; }
			set { bigFullTimes = value; }
		}

		private double bigPartialBuyAmount;

		public double BigPartialBuyAmount
		{
			get { return bigPartialBuyAmount; }
			set { bigPartialBuyAmount = value; }
		}

		private int bigPartialBuyTimes;

		public int BigPartialBuyTimes
		{
			get { return bigPartialBuyTimes; }
			set { bigPartialBuyTimes = value; }
		}

		private double bigPartialSellAmount;

		public double BigPartialSellAmount
		{
			get { return bigPartialSellAmount; }
			set { bigPartialSellAmount = value; }
		}

		private int bigPartialSellTimes;

		public int BigPartialSellTimes
		{
			get { return bigPartialSellTimes; }
			set { bigPartialSellTimes = value; }
		}

		private double bigUnlockCase1DiffPrice;

		public double BigUnlockCase1DiffPrice
		{
			get { return bigUnlockCase1DiffPrice; }
			set { bigUnlockCase1DiffPrice = value; }
		}

		private double bigUnlockCase2Multiple;

		public double BigUnlockCase2Multiple
		{
			get { return bigUnlockCase2Multiple; }
			set { bigUnlockCase2Multiple = value; }
		}

		private double bigUnlockCase2DiffPrice;

		public double BigUnlockCase2DiffPrice
		{
			get { return bigUnlockCase2DiffPrice; }
			set { bigUnlockCase2DiffPrice = value; }
		}
	}
}
