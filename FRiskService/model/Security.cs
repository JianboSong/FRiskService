using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRiskService.model
{
	public class Security
	{
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
	}
}
