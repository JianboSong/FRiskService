using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class AccountRisk
	{
		private double startMoney;

		public double StartMoney
		{
			get { return startMoney; }
			set { startMoney = value; }
		}

		private double totalLossRatio;

		public double TotalLossRatio
		{
			get { return totalLossRatio; }
			set { totalLossRatio = value; }
		}

		private double totalLossAmount;

		public double TotalLossAmount
		{
			get { return totalLossAmount; }
			set { totalLossAmount = value; }
		}

		private double minimalQuanyi;

		public double MinimalQuanyi
		{
			get { return minimalQuanyi; }
			set { minimalQuanyi = value; }
		}
	}
}
