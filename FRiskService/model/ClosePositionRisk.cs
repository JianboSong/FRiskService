using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class ClosePositionRisk
	{
		// 一段时间(分钟)内
		private int duration;

		// 比较点位
		private double price;

		// 产生差值
		private double diffValue;

		// 自动平仓比例
		private double closeRatio;
	}
}
