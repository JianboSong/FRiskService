using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class DayRisk
	{
		private string accountId;

		public string AccountId
		{
			get { return accountId; }
			set { accountId = value; }
		}

		private string instrumentId;

		public string InstrumentId
		{
			get { return instrumentId; }
			set { instrumentId = value; }
		}

		private double dayLossAmount;

		public double DayLossAmount
		{
			get { return dayLossAmount; }
			set { dayLossAmount = value; }
		}

		private int dayLossTimes;

		public int DayLossTimes
		{
			get { return dayLossTimes; }
			set { dayLossTimes = value; }
		}

		private int stopMinutes;

		public int StopMinutes
		{
			get { return stopMinutes; }
			set { stopMinutes = value; }
		}

		private string stopTimes;

		public string StopTimes
		{
			get { return stopTimes; }
			set { stopTimes = value; }
		}
	}
}
