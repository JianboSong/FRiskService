using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class PositionRisk
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

		private bool enable;
		public bool Enable
		{
			get { return enable; }
			set { enable = value; }
		}

		// 向上跳点
		private int buyUpperPoint;
		public int BuyUpperPoint
		{
			get { return buyUpperPoint; }
			set { buyUpperPoint = value; }
		}
		private int sellUpperPoint;
		public int SellUpperPoint
		{
			get { return sellUpperPoint; }
			set { sellUpperPoint = value; }
		}

		// 向下跳点
		private int buyLowerPoint;
		public int BuyLowerPoint
		{
			get { return buyLowerPoint; }
			set { buyLowerPoint = value; }
		}
		private int sellLowerPoint;
		public int SellLowerPoint
		{
			get { return sellLowerPoint; }
			set { sellLowerPoint = value; }
		}

		// 非开仓点数
		private int buyProtectPoint;
		public int BuyProtectPoint
		{
			get { return buyProtectPoint; }
			set { buyProtectPoint = value; }
		}
		private int sellProtectPoint;
		public int SellProtectPoint
		{
			get { return sellProtectPoint; }
			set { sellProtectPoint = value; }
		}

		// 非开仓点数倍数
		private int buyMultiplier;
		public int BuyMultiplier
		{
			get { return buyMultiplier; }
			set { buyMultiplier = value; }
		}
		private int sellMultiplier;
		public int SellMultiplier
		{
			get { return sellMultiplier; }
			set { sellMultiplier = value; }
		}
	}
}
